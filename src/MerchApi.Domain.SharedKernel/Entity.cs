using System.Collections.Generic;

using MediatR;

namespace MerchApi.Domain.SharedKernel
{
    // COMPATIBLE WITH ENTITY FRAMEWORK CORE (1.1 and later)
    public abstract class Entity
    {
        int? _requestedHashCode;
        int _Id;
        private List<INotification> _domainEvents;
        public virtual int Id
        {
            get
            {
                return _Id;
            }
            protected set
            {
                _Id = value;
            }
        }

        public List<INotification> DomainEvents => _domainEvents;
        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents ??= new List<INotification>();
            _domainEvents.Add(eventItem);
        }
        public void RemoveDomainEvent(INotification eventItem)
        {
            if (_domainEvents is null) return;
            _domainEvents.Remove(eventItem);
        }

        public bool IsTransient()
        {
            return Id == default;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj is not Entity)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (GetType() != GetType())
                return false;
            
            if (IsTransient() || IsTransient())
                return false;
            else
                return Id == Id;
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = Id.GetHashCode() ^ 31;
                // XOR for random distribution. See:
                // https://docs.microsoft.com/archive/blogs/ericlippert/guidelines-and-rules-for-gethashcode
                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();
        }
        public static bool operator ==(Entity left, Entity right)
        {
            if (Equals(left, null))
                return (Equals(right, null));
            else
                return left.Equals(right);
        }
        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }
    }
}
