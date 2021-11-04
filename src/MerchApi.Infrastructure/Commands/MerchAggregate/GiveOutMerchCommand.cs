﻿using MediatR;

using MerchApi.Http.Requests;

namespace MerchApi.Infrastructure.Commands.MerchAggregate
{
    public class GiveOutMerchCommand : IRequest<int>
    {
        public GiveOutMerchRequest Request { get; }

        public GiveOutMerchCommand(GiveOutMerchRequest request)
        {
            Request = request;
        }
    }
}
