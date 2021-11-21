using System;

using MerchApi.Http.Enums;

namespace MerchApi.Http.Models
{
    public class MerchIssueInfo
    {
        public DateTime? IssueDate { get; }
        public MerchType MerchType { get; }

        public MerchIssueInfo(DateTime? issueDate, MerchType merchType)
        {
            IssueDate = issueDate;
            MerchType = merchType;
        }
    }
}