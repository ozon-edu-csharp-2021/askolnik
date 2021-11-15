using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using MerchApi.Domain.AggregationModels.MerchAggregate;
using MerchApi.Domain.SharedKernel.Interfaces;
using MerchApi.Infrastructure.Commands.MerchAggregate;

using Microsoft.Extensions.Logging;

namespace MerchApi.Infrastructure.Handlers.MerchAggregate
{
    public class GiveOutMerchCommandHandler : IRequestHandler<GiveOutMerchCommand>
    {
        private readonly ILogger<GiveOutMerchCommandHandler> _logger;
        private readonly IGiveOutMerchRequestRepository _merchRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GiveOutMerchCommandHandler(
            ILogger<GiveOutMerchCommandHandler> logger,
            IGiveOutMerchRequestRepository merchRepository,
            IUnitOfWork unitOfWork)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _merchRepository = merchRepository ?? throw new ArgumentNullException(nameof(merchRepository));
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Обработка запроса на выдачу мерча
        /// </summary>
        /// <param name="command">Команда выдчи мерча</param>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        /// <returns>Возвращает id созданного мерча</returns>
        public async Task<Unit> Handle(GiveOutMerchCommand command, CancellationToken cancellationToken)
        {
            _logger.LogDebug($"[{nameof(GiveOutMerchCommandHandler)}] Обработка запроса на выдачу мерча");

            var issuedMerches = await _merchRepository.FindByEmployeeIdAsync(command.Request.EmployeeId, cancellationToken);
            var merchType = GetMerchType(command.Request);

            if (issuedMerches.Select(x => x.MerchType).Contains(merchType))
            {
                throw new ArgumentException($"Невозможно повторно выдать мерч типа = '{merchType.Name}'");
            }

            var giveOutMerchRequest = new GiveOutMerchRequest(command.Request.EmployeeId, merchType);

            await _merchRepository.CreateAsync(giveOutMerchRequest, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            giveOutMerchRequest.ChangeStatus(RequestStatus.Created);
            return Unit.Value;
        }

        private static MerchType GetMerchType(Http.Requests.GiveOutMerchRequest request)
        {
            return request.MerchType switch
            {
                Http.Enums.MerchType.WelcomePack => MerchType.WelcomePack,
                Http.Enums.MerchType.ConferenceListenerPack => MerchType.ConferenceListenerPack,
                Http.Enums.MerchType.ConferenceSpeakerPack => MerchType.ConferenceSpeakerPack,
                Http.Enums.MerchType.ProbationPeriodEndingPack => MerchType.ProbationPeriodEndingPack,
                Http.Enums.MerchType.VeteranPack => MerchType.VeteranPack,
                _ => new MerchType(0, "Unknown")
            };
        }
    }
}