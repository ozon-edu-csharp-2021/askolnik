using System;

namespace MerchApi.Infrastructure.Repositories.Models
{
    public class MerchRequest
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public int MerchTypeId { get; set; }

        public int MerchStatusId { get; set; }

        public DateTime? IssueDate { get; set; }
    }
}