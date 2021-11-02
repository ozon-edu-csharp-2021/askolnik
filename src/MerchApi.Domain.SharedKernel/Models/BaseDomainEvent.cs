using System;

using MediatR;

namespace MerchApi.Domain.SharedKernel.Models
{
    public abstract class BaseDomainEvent : INotification
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}
