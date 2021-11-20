using System;

using MerchApi.Http.Enums;

namespace MerchApi.Http.Models
{
    public class MerchIssueInfo
    {
        public long Id { get; }
        public DateTime? IssueDate { get; }
        public MerchType MerchType { get; }

        public MerchIssueInfo(long id, DateTime? issueDate, MerchType merchType)
        {
            Id = id;
            IssueDate = issueDate;
            MerchType = merchType;
        }
    }
}