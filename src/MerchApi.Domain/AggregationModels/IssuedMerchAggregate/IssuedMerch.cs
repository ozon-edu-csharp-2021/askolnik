using System;

using MerchApi.Domain.SharedKernel.Models;

namespace MerchApi.Domain.AggregationModels.MerchAggregate
{
    /// <summary>
    /// Мерч, который выдавался сотруднику
    /// </summary>
    public class IssuedMerch : Entity
    {
        /// <summary>
        /// Идентификатор сотрудника, которому выдавался мерч
        /// </summary>
        public long EmployeeId { get; }

        /// <summary>
        /// Тип выданного мерча
        /// </summary>
        public MerchType MerchType { get; private set; }

        /// <summary>
        /// Дата выдачи мерча
        /// </summary>
        public DateTime IssueDate { get; }

        /// <summary>
        /// Набор товаров (Item), выданных сотруднику
        /// </summary>
        public int MerchPack { get; set; }

        public IssuedMerch(long employeeId, MerchType merchType, DateTime issueDate)
        {
            EmployeeId = employeeId;
            MerchType = merchType;
            IssueDate = issueDate;
        }
    }
}
