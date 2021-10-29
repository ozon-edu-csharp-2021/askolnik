using System.Threading.Tasks;

using Google.Protobuf.WellKnownTypes;

using Grpc.Core;

using MerchApi.Grpc;
using MerchApi.Services;

namespace MerchApi.GrpcServices
{
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
                    MerchDeliveryInfo = new()
                    {
                        Id = response.Value.MerchDeliveryInfo.Id,
                        DeliveryDate = response.Value.MerchDeliveryInfo.DeliveryDate.ToTimestamp()
                    }
                }
                : await base.GetMerchDeliveryInfo(request, context);
        }

        public override async Task<GetMerchPackResponse> GetMerchPack(GetMerchPackRequest request, ServerCallContext context)
        {
            var response = await _merchService.GetMerchPack(request.Id);

            return response.HasValue
                ? new GetMerchPackResponse()
                {
                    MerchPack = new()
                    {
                        Id = response.Value.MerchPack.Id,
                        Name = response.Value.MerchPack.Name
                    }
                }
                : await base.GetMerchPack(request, context);
        }
    }
}
