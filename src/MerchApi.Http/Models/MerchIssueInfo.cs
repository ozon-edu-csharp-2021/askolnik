using System;

using MerchApi.Http.Enums;

namespace MerchApi.Http.Models
{
    public class MerchIssueInfo
    {
        public DateTime CreateDate { get; }
        public DateTime? IssueDate { get; }
        public MerchType MerchType { get; }
        public object MerchPackInfo { get; }

        public MerchIssueInfo(DateTime createDate, MerchType merchType, object merchPackInfo, DateTime? issueDate = null)
        {
            IssueDate = issueDate;
            MerchType = merchType;
            CreateDate = createDate;
            MerchPackInfo = merchPackInfo;
        }
    }
}