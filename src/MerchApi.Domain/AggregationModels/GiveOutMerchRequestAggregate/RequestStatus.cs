﻿using MerchApi.Domain.SharedKernel.Models;

namespace MerchApi.Domain.AggregationModels.GiveOutMerchRequestAggregate
{
    public class RequestStatus : Enumeration
    {
        public static RequestStatus InWork = new(1, "InWork");
        public static RequestStatus Done = new(2, "Done");

        public RequestStatus(int id, string name) : base(id, name)
        {
        }
    }
}