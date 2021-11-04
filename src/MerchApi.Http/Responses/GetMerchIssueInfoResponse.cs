﻿using System.Collections.Generic;

using MerchApi.Http.Models;

namespace MerchApi.Http.Responses
{
    public class GetMerchIssueInfoResponse
    {
        public IList<MerchIssueInfo> IssuedMerchs { get; set; } = new List<MerchIssueInfo>();
    }
}
