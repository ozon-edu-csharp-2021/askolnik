using System;

using MerchApi.Http.Enums;

namespace MerchApi.Http.Models
{
    public class MerchIssueInfo
    {
        public DateTime CreateDate { get; }
        public DateTime? IssueDate { get; }
        public MerchType MerchType { get; }
        public object MerchPack { get; }

        public MerchIssueInfo(DateTime createDate, MerchType merchType, object merchPack, DateTime? issueDate = null)
        {
            IssueDate = issueDate;
            MerchType = merchType;
            CreateDate = createDate;
            MerchPack = merchPack;
        }
    }
}