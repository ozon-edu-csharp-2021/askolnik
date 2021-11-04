using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using MerchApi.Domain.AggregationModels.EmployeeAggregate;
using MerchApi.Domain.AggregationModels.GetMerchIssueAggregate;
using MerchApi.Domain.SharedKernel.Interfaces;

namespace MerchApi.Infrastructure.Stubs
{
    public class MerchIssueRepository : IMerchIssueRepository
    {
        private readonly DateTime _startDate = new(2021, 11, 04);
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public Task<MerchIssue> CreateAsync(MerchIssue itemToCreate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<MerchIssue>> FindByEmployeeAsync(Employee employee, CancellationToken cancellationToken = default)
        {
            var response = new List<MerchIssue>();

            switch (employee.Id)
            {
                case 1:
                    response.Add(new MerchIssue(employee.Id, MerchType.WelcomePack, _startDate));
                    break;

                case 2:
                    response.Add(new MerchIssue(employee.Id, MerchType.WelcomePack, _startDate.AddDays(-90)));
                    response.Add(new MerchIssue(employee.Id, MerchType.ProbationPeriodEndingPack, _startDate));
                    break;

                case 3:
                    response.Add(new MerchIssue(employee.Id, MerchType.WelcomePack, _startDate.AddYears(-5)));
                    response.Add(new MerchIssue(employee.Id, MerchType.ProbationPeriodEndingPack, _startDate.AddYears(-5).AddDays(90)));
                    response.Add(new MerchIssue(employee.Id, MerchType.VeteranPack, _startDate));
                    break;
            }

            return await Task.FromResult<IList<MerchIssue>>(response);
        }

        public Task<MerchIssue> UpdateAsync(MerchIssue itemToUpdate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
