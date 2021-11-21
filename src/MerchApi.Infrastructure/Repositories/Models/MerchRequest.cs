using System;

namespace MerchApi.Infrastructure.Repositories.Models
{
    public class MerchRequest
    {
        public int Id { get; set; }

        public int RequestStatusId { get; set; }

        public string EmployeeEmail { get; set; }

        public int MerchPackId { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? IssueDate { get; set; }
    }
}