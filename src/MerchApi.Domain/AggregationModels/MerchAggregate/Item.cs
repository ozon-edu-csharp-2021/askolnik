using MerchApi.Domain.SharedKernel.Models;

namespace MerchApi.Domain.AggregationModels.MerchAggregate
{
    /// <summary>
    /// Товар
    /// </summary>
    public class Item : Entity
    {
        /// <summary>
        /// К какому типу мерча относится товар
        /// </summary>
        public int MerchTypeId { get; }

        /// <summary>
        /// Наименование товара 
        /// </summary>
        public string Name { get; }

        public Item(int merchTypeId, string name)
        {
            MerchTypeId = merchTypeId;
            Name = name;
        }
    }
}