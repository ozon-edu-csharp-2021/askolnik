using System.Collections.Concurrent;
using System.Collections.Generic;

using MerchApi.Domain.SharedKernel.Models;
using MerchApi.Infrastructure.Repositories.Infrastructure.Interfaces;

namespace MerchApi.Infrastructure.Repositories.Infrastructure
{
    public class ChangeTracker : IChangeTracker
    {
        public IEnumerable<Entity> TrackedEntities => _usedEntitiesBackingField.ToArray();

        private readonly ConcurrentBag<Entity> _usedEntitiesBackingField;

        public ChangeTracker()
        {
            _usedEntitiesBackingField = new ConcurrentBag<Entity>();
        }

        public void Track(Entity entity)
        {
            _usedEntitiesBackingField.Add(entity);
        }
    }
}