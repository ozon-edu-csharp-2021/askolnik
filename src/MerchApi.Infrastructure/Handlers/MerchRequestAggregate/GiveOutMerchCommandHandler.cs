using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using MerchApi.Domain.AggregationModels.MerchPackAggregate;
using MerchApi.Domain.AggregationModels.MerchRequestAggregate;
using MerchApi.Domain.SharedKernel.Interfaces;
using MerchApi.Infrastructure.Commands.MerchRequestAggregate;

using Microsoft.Extensions.Logging;

namespace MerchApi.Infrastructure.Handlers.MerchRequestAggregate
{
    public class GiveOutMerchCommandHandler : IRequestHandler<GiveOutMerchCommand>
    {
        private readonly ILogger<GiveOutMerchCommandHandler> _logger;
        private readonly IGiveOutMerchRequestRepository _giveOutMerchRepository;
        private readonly IMerchPackRepository _merchPackRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GiveOutMerchCommandHandler(
            ILogger<GiveOutMerchCommandHandler> logger,
            IGiveOutMerchRequestRepository merchRepository,
            IMerchPackRepository merchPackRepository,
            IUnitOfWork unitOfWork)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _giveOutMerchRepository = merchRepository ?? throw new ArgumentNullException(nameof(merchRepository));
            _merchPackRepository = merchPackRepository ?? throw new ArgumentNullException(nameof(merchPackRepository));
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
            await _unitOfWork.StartTransaction(cancellationToken);

            var issuedMerches = await _giveOutMerchRepository.FindByEmployeeEmailAsync(command.Request.EmployeeEmail, cancellationToken);
            var merchType = GetMerchType(command.Request.MerchType);

            foreach (var issuedMerch in issuedMerches)
            {
                CheckMerchRequest(merchType, issuedMerch);
            }

            var merhPack = await _merchPackRepository.GetMerchPackByMerchType(merchType, cancellationToken);

            var newGiveOutMerchRequest =
                GiveOutMerchRequest.Create(
                    0,
                    Employee.Create(Email.Create(command.Request.EmployeeEmail)),
                    RequestStatus.Created,
                    merhPack,
                    DateTime.UtcNow);

            await _giveOutMerchRepository.CreateAsync(newGiveOutMerchRequest, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            // Забронировать мерч в stockAPI
            // Выдать мерч
            // Обновить заявку в БД
            // Отправить письмо

            return Unit.Value;
        }

        private static void CheckMerchRequest(MerchType merchType, GiveOutMerchRequest issuedMerch)
        {
            if (Equals(merchType, issuedMerch.MerchPack.MerchType)
                && Equals(issuedMerch.Status, RequestStatus.Done)
                && issuedMerch.MerchPack.CanBeReissued
                && issuedMerch.MerchPack.CanBeReissuedAfterDays < (int)(issuedMerch.IssueDate.Value - DateTime.UtcNow).TotalDays)
            {
                throw new ArgumentException($"Невозможно повторно выдать мерч типа = '{merchType.Name}'");
            }
        }

        private static MerchType GetMerchType(Http.Enums.MerchType merchType)
        {
            return merchType switch
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