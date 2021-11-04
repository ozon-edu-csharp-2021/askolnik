using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using MerchApi.Domain.AggregationModels.EmployeeAggregate;
using MerchApi.Domain.SharedKernel.Interfaces;

namespace MerchApi.Domain.AggregationModels.GetMerchIssueAggregate
{
    /// <summary>
    /// Репозиторий для управления <see cref="MerchIssue"/>
    /// </summary>
    public interface IMerchIssueRepository : IRepository<MerchIssue>
    {
        /// <summary>
        /// Найти выданные мерчи по сотруднику
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IList<MerchIssue>> FindByEmployeeAsync(Employee employee, CancellationToken cancellationToken = default);
    }
}
