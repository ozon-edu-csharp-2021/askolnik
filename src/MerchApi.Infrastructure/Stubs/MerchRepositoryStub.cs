using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using MerchApi.Domain.AggregationModels.EmployeeAggregate;
using MerchApi.Domain.AggregationModels.MerchAggregate;
using MerchApi.Domain.SharedKernel.Interfaces;

namespace MerchApi.Infrastructure.Stubs
{
    public class MerchRepositoryStub : IMerchRepository
    {
        public IUnitOfWork UnitOfWork => new UnitOfWorkStub();

        public async Task<GiveOutMerchRequest> CreateAsync(GiveOutMerchRequest itemToCreate, CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(itemToCreate);
        }

        public async Task<IList<GiveOutMerchRequest>> FindByEmployeeAsync(Employee employee, CancellationToken cancellationToken = default)
        {
            var response = new List<GiveOutMerchRequest>();

            switch (employee.Id)
            {
                case 1:
                    response.Add(new GiveOutMerchRequest(employee.Id, MerchType.WelcomePack));
                    break;

                case 2:
                    response.Add(new GiveOutMerchRequest(employee.Id, MerchType.WelcomePack));
                    response.Add(new GiveOutMerchRequest(employee.Id, MerchType.ProbationPeriodEndingPack));
                    break;

                case 3:
                    response.Add(new GiveOutMerchRequest(employee.Id, MerchType.WelcomePack));
                    response.Add(new GiveOutMerchRequest(employee.Id, MerchType.ProbationPeriodEndingPack));
                    response.Add(new GiveOutMerchRequest(employee.Id, MerchType.VeteranPack));
                    break;
            }

            return await Task.FromResult<IList<GiveOutMerchRequest>>(response);
        }

        public async Task<GiveOutMerchRequest> UpdateAsync(GiveOutMerchRequest itemToUpdate, CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(itemToUpdate);
        }
    }
}
