using System.Threading;
using System.Threading.Tasks;

using MediatR;

using MerchApi.Domain.Events;

namespace MerchApi.Infrastructure.Handlers.DomainEvent
{
    public class SupplyArrivedDomainEventHandler : INotificationHandler<SupplyArrivedDomainEvent>
    {
        public Task Handle(SupplyArrivedDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}