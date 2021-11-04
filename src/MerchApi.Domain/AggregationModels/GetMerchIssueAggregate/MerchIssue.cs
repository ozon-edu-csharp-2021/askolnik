using System;

using MerchApi.Domain.SharedKernel.Models;

namespace MerchApi.Domain.AggregationModels.GetMerchIssueAggregate
{
    /// <summary>
    /// Мерч, который выдавался сотруднику
    /// </summary>
    public class MerchIssue : Entity
    {
        /// <summary>
        /// Сотрудник
        /// </summary>
        public int EmployeeId { get; }

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

        public MerchIssue(int employeeId, MerchType merchType, DateTime issueDate)
        {
            EmployeeId = employeeId;
            MerchType = merchType;
            IssueDate = issueDate;
        }
    }
}
