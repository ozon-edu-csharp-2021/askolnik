using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using MerchApi.Domain.SharedKernel.Interfaces;

namespace MerchApi.Domain.AggregationModels.GetMerchIssueInfoAggregate
{
    /// <summary>
    /// Репозиторий для управления <see cref="IssuedMerch"/>
    /// </summary>
    public interface IIssuedMerchRepository : IRepository<IssuedMerch>
    {
        /// <summary>
        /// Найти выданный мерч по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IssuedMerch> FindByIdAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Найти выданные мерчи по идентификатору сотрудника
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IList<IssuedMerch>> FindByEmployeeIdAsync(int employeeId, CancellationToken cancellationToken = default);
    }
}
