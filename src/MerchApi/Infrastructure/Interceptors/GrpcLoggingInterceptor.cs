using System.Text.Json;
using System.Threading.Tasks;

using Grpc.Core;
using Grpc.Core.Interceptors;

using Microsoft.Extensions.Logging;

namespace MerchApi.Infrastructure.Interceptors
{
    /// <summary>
    /// 
    /// </summary>
    public class GrpcLoggingInterceptor : Interceptor
    {
        private readonly ILogger<GrpcLoggingInterceptor> _logger;

        public GrpcLoggingInterceptor(ILogger<GrpcLoggingInterceptor> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Логирование request и response unary вызовов
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <param name="continuation"></param>
        /// <returns></returns>
        public override Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
            TRequest request,
            ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation)
        {
            var requestJson = JsonSerializer.Serialize(request);
            _logger.LogInformation(requestJson);

            var response = base.UnaryServerHandler(request, context, continuation);

            var responseJson = JsonSerializer.Serialize(response);
            _logger.LogInformation(responseJson);

            return response;
        }
    }
}
