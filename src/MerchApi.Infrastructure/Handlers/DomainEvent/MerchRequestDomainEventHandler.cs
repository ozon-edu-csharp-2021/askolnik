using System.Threading;
using System.Threading.Tasks;

using MediatR;

using MerchApi.Domain.Events;

namespace MerchApi.Infrastructure.Handlers.DomainEvent
{
    public class MerchRequestDomainEventHandler : INotificationHandler<MerchRequestDomainEvent>
    {
        public Task Handle(MerchRequestDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}