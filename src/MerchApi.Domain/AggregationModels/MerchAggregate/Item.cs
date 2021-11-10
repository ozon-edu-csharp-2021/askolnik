using System.Collections.Generic;

using MerchApi.Domain.SharedKernel.Models;

namespace MerchApi.Domain.AggregationModels.MerchAggregate
{
    /// <summary>
    /// Товар
    /// </summary>
    public class Item : ValueObject
    {
        /// <summary>
        /// Категория товара
        /// </summary>
        public int Category { get; }

        /// <summary>
        /// Наименование товара 
        /// </summary>
        public string Name { get; }

        public Item(int category, string name)
        {
            Category = category;
            Name = name;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Category;
            yield return Name;
        }
    }
}