using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using MerchApi.Domain.AggregationModels.MerchAggregate;

namespace MerchApi.Infrastructure.Stubs
{
    public class GiveOutMerchRequestRepositoryStub : IGiveOutMerchRequestRepository
    {
        public Task<GiveOutMerchRequest> CreateAsync(GiveOutMerchRequest itemToCreate, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(itemToCreate);
        }

        public Task<IReadOnlyList<GiveOutMerchRequest>> FindByEmployeeIdAsync(int employeeId, CancellationToken cancellationToken = default)
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

            return Task.FromResult<IReadOnlyList<GiveOutMerchRequest>>(response);
        }

        public Task<GiveOutMerchRequest> UpdateAsync(GiveOutMerchRequest itemToUpdate, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(itemToUpdate);
        }
    }
}