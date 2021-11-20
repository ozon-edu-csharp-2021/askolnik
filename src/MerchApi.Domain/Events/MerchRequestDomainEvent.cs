using MerchApi.Domain.AggregationModels.MerchPackAggregate;
using MerchApi.Domain.SharedKernel.Models;

namespace MerchApi.Domain.Events
{
    public class MerchRequestGivenOutDomainEvent : BaseDomainEvent
    {
        public MerchRequestGivenOutDomainEvent(int employeeId, MerchPack merchPack)
        {
            EmployeeId = employeeId;
            MerchPack = merchPack;
        }

        public int EmployeeId { get; }
        public MerchPack MerchPack { get; }
    }
}