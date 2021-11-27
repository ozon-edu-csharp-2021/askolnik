using System.Collections.Generic;

using MerchApi.Http.Models;

namespace MerchApi.Http.Responses
{
    public class GetMerchRequestInfoResponse
    {
        public IList<MerchIssueInfo> IssuedMerchs { get; } = new List<MerchIssueInfo>();
    }
}