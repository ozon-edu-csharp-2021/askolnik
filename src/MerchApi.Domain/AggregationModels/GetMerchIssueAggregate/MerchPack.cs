using System.Collections.Generic;

using MerchApi.Domain.SharedKernel.Models;

namespace MerchApi.Domain.AggregationModels.GetMerchIssueAggregate
{
    public class MerchPack : ValueObject
    {
        /// <summary>
        /// Категория товара
        /// </summary>
        public IList<Item> Value { get; }

        public MerchPack()
        {
            Value = new List<Item>();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            foreach (var item in Value)
            {
                yield return item;
            }
        }
    }
}
