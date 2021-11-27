using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using MerchApi.Domain.SharedKernel.Interfaces;

namespace MerchApi.Domain.AggregationModels.MerchRequestAggregate
{
    /// <summary>
    /// Репозиторий для управления заявками
    /// </summary>
    public interface IGiveOutMerchRequestRepository : IRepository<GiveOutMerchRequest>
    {
        /// <summary>
        /// Создать заявку на выдачу мерча сотруднику
        /// </summary>
        /// <param name="itemToCreate">Заявка</param>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        /// <returns>Возвращает id заявки</returns>
        Task<int> CreateAsync(GiveOutMerchRequest itemToCreate, CancellationToken cancellationToken);

        /// <summary>
        /// Найти выданные мерчи по сотруднику
        /// </summary>
        /// <param name="employeeEmail">Идентификатор/Email сотрудника</param>
        /// <param name="cancellationToken">Токен для отмены операции. <see cref="CancellationToken"/></param>
        /// <returns>Возвращает список выданных мерчей сотруднику</returns>
        Task<IReadOnlyList<GiveOutMerchRequest>> FindByEmployeeEmailAsync(string employeeEmail, CancellationToken cancellationToken = default);
    }
}