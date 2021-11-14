using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using MerchApi.Domain.SharedKernel.Interfaces;

namespace MerchApi.Domain.AggregationModels.MerchAggregate
{
    /// <summary>
    /// Репозиторий для управления заявками
    /// </summary>
    public interface IGiveOutMerchRequestRepository : IRepository<GiveOutMerchRequest>
    {
        /// <summary>
        /// Создать заявку на выдачу мерча сотруднику
        /// </summary>
        /// <param name="request">Модель запроса</param>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        /// <returns>Возвращает созданную заявку</returns>
        Task<GiveOutMerchRequest> CreateAsync(GiveOutMerchRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Найти выданные мерчи по сотруднику
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника</param>
        /// <param name="cancellationToken">Токен для отмены операции. <see cref="CancellationToken"/></param>
        /// <returns>Возвращает список выданных мерчей сотруднику</returns>
        Task<IReadOnlyList<GiveOutMerchRequest>> FindByEmployeeIdAsync(int employeeId, CancellationToken cancellationToken = default);
    }
}