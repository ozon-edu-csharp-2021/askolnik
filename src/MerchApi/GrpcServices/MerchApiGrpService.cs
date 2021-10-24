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

        public override async Task<GetMerchDeliveryInfoResponse> GetMerchDeliveryInfo(GetMerchDeliveryInfoRequest request, ServerCallContext context)
        {
            var response = await _merchService.GetMerchDeliveryInfo(request.Id);

            return response.HasValue
                ? new GetMerchDeliveryInfoResponse()
                {
                    MerchDeliveryInfo = new GetMerchDeliveryInfoResponseUnit
                    {
                        Id = response.Value.MerchDeliveryInfo.Id,
                        DeliveryDate = new Google.Protobuf.WellKnownTypes.Timestamp()
                        {
                            Seconds = response.Value.MerchDeliveryInfo.DeliveryDate.ToBinary()
                        }
                    }
                }
                : await base.GetMerchDeliveryInfo(request, context);
        }

        public override Task<GetMerchPackResponse> GetMerchPack(GetMerchPackRequest request, ServerCallContext context)
        {

            return base.GetMerchPack(request, context);
        }
    }
}
