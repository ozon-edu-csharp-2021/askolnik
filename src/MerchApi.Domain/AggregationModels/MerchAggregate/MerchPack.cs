using System.Collections;
using System.Collections.Generic;

using MerchApi.Domain.SharedKernel.Models;

namespace MerchApi.Domain.AggregationModels.MerchAggregate
{
    public class MerchPack : ValueObject, IEnumerable<Item>
    {
        private List<Item> Items { get; }

        public MerchPack(IEnumerable<Item> items) => Items = new List<Item>(items);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            foreach (var item in Items)
            {
                yield return item;
            }
        }

        public IEnumerator<Item> GetEnumerator()
            => Items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}