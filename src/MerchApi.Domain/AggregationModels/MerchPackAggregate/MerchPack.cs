using System.Collections.Generic;

using MerchApi.Domain.SharedKernel.Models;

namespace MerchApi.Domain.AggregationModels.MerchPackAggregate
{
    /// <summary>
    /// Набор товаров для сотрудника
    /// </summary>
    public class MerchPack : Entity
    {
        /// <summary>
        /// Тип мерча
        /// </summary>
        public MerchType MerchType { get; private set; }

        /// <summary>
        /// Может ли выдаваться повторно
        /// </summary>
        public bool CanBeReissued { get; private set; }

        /// <summary>
        /// Количество дней с последней выдачи, после которого пак может быть выдан повторно
        /// </summary>
        public int? CanBeReissuedAfterDays { get; private set; }

        /// <summary>
        /// Список товарных позиций в мерче
        /// </summary>
        public IReadOnlyCollection<Sku> SkuCollection { get; private set; }

        public MerchPack(
            MerchType merchType,
            IReadOnlyCollection<Sku> items,
            bool canBeReissued = false,
            int? canBeReissuedAfterDays = null)
        {
            MerchType = merchType;
            SkuCollection = items;
            CanBeReissued = canBeReissued;

            if (canBeReissued)
            {
                CanBeReissuedAfterDays = canBeReissuedAfterDays;
            }
        }
    }
}