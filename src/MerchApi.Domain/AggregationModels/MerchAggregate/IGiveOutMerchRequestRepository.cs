using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using MerchApi.Domain.AggregationModels.EmployeeAggregate;
using MerchApi.Domain.SharedKernel.Interfaces;

namespace MerchApi.Domain.AggregationModels.MerchAggregate
{
    /// <summary>
    /// Репозиторий для управления
    /// </summary>
    public interface IGiveOutMerchRequestRepository : IRepository<GiveOutMerchRequest>
    {
        /// <summary>
        /// Найти выданные мерчи по сотруднику
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        /// <param name="cancellationToken">Токен для отмены операции. <see cref="CancellationToken"/></param>
        /// <returns>Возвращает список выданных мерчей сотруднику</returns>
        Task<IList<GiveOutMerchRequest>> FindByEmployeeAsync(Employee employee, CancellationToken cancellationToken = default);
    }
}