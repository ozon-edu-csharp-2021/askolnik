using MerchApi.Domain.AggregationModels.MerchPackAggregate;
using MerchApi.Domain.AggregationModels.MerchRequestAggregate;
using MerchApi.Domain.SharedKernel.Models;

namespace MerchApi.Domain.Events
{
    public class MerchRequestGivenOutDomainEvent : BaseDomainEvent
    {
        public MerchRequestGivenOutDomainEvent(Employee employee, MerchPack merchPack)
        {
            Employee = employee;
            MerchPack = merchPack;
        }

        public Employee Employee { get; }
        public MerchPack MerchPack { get; }
    }
}