using System.Threading.Tasks;

using Grpc.Core;

using MerchApi.Grpc;
using MerchApi.Services;

namespace MerchApi.GrpcServices
{
    /// <summary>
    /// 
    /// </summary>
    public class MerchApiGrpService : MerchApiGrpc.MerchApiGrpcBase
    {
        private readonly IMerchService _merchService;

        public MerchApiGrpService(IMerchService merchService)
        {
            _merchService = merchService;
        }

        public override Task<GetMerchDeliveryInfoResponse> GetMerchDeliveryInfo(GetMerchDeliveryInfoRequest request, ServerCallContext context)
        {
            return base.GetMerchDeliveryInfo(request, context);
        }

        public override Task<GetMerchPackResponse> GetMerchPack(GetMerchPackRequest request, ServerCallContext context)
        {
            return base.GetMerchPack(request, context);
        }
    }
}
