using System.Threading.Tasks;

using Grpc.Core;

using MerchApi.Grpc;

namespace MerchApi.GrpcServices
{
    public class MerchApiGrpService : MerchApiGrpc.MerchApiGrpcBase
    {
        public MerchApiGrpService()
        {
        }

        public override async Task<GetMerchAvailabilityResponse> GetMerchAvailability(GetMerchAvailabilityRequest request, ServerCallContext context) =>
            await base.GetMerchAvailability(request, context);

        public override async Task<GiveOutMerchResponse> GiveOutMerch(GiveOutMerchRequest request, ServerCallContext context) =>
            await base.GiveOutMerch(request, context);
    }
}