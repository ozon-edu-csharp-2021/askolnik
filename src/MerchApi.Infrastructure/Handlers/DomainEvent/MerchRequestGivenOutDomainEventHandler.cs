using System.Threading;
using System.Threading.Tasks;

using MediatR;

using MerchApi.Domain.Events;

namespace MerchApi.Infrastructure.Handlers.DomainEvent
{
    public class MerchRequestGivenOutDomainEventHandler : INotificationHandler<MerchRequestGivenOutDomainEvent>
    {
        public Task Handle(MerchRequestGivenOutDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}