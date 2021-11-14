using MerchApi.Domain.AggregationModels.EmployeeAggregate;
using MerchApi.Domain.AggregationModels.MerchAggregate;
using MerchApi.Domain.SharedKernel.Interfaces;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MerchApi.Infrastructure.Stubs
{
    public class GiveOutMerchRequestRepositoryStub : IGiveOutMerchRequestRepository
    {
        public IUnitOfWork UnitOfWork => new UnitOfWorkStub();

        public Task<GiveOutMerchRequest> CreateAsync(GiveOutMerchRequest itemToCreate, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(itemToCreate);
        }

        public Task<IList<GiveOutMerchRequest>> FindByEmployeeIdAsync(int employeeId, CancellationToken cancellationToken = default)
        {
            var response = new List<GiveOutMerchRequest>();

            switch (employeeId)
            {
                case 1:
                    response.Add(new GiveOutMerchRequest(employeeId, MerchType.WelcomePack));
                    break;

                case 2:
                    response.Add(new GiveOutMerchRequest(employeeId, MerchType.WelcomePack));
                    response.Add(new GiveOutMerchRequest(employeeId, MerchType.ProbationPeriodEndingPack));
                    break;

                case 3:
                    response.Add(new GiveOutMerchRequest(employeeId, MerchType.WelcomePack));
                    response.Add(new GiveOutMerchRequest(employeeId, MerchType.ProbationPeriodEndingPack));
                    response.Add(new GiveOutMerchRequest(employeeId, MerchType.VeteranPack));
                    break;
            }

            return Task.FromResult<IList<GiveOutMerchRequest>>(response);
        }

        public Task<GiveOutMerchRequest> UpdateAsync(GiveOutMerchRequest itemToUpdate, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(itemToUpdate);
        }
    }
}