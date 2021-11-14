using System.Collections.Concurrent;
using System.Collections.Generic;

using MerchApi.Infrastructure.Repositories.Infrastructure.Interfaces;

using OzonEdu.StockApi.Domain.Models;

namespace MerchApi.Infrastructure.Repositories.Infrastructure
{
    public class ChangeTracker : IChangeTracker
    {
        public IEnumerable<Entity> TrackedEntities => _usedEntitiesBackingField.ToArray();

        // Можно заменить на любую другую имплементацию. Не только через ConcurrentBag
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