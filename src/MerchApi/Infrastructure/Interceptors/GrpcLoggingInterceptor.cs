using System.Text.Json;
using System.Threading.Tasks;

using Grpc.Core;
using Grpc.Core.Interceptors;

using Microsoft.Extensions.Logging;

namespace MerchApi.Infrastructure.Interceptors
{
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
            _logger.LogInformation($"[{nameof(GrpcLoggingInterceptor)}] -> {JsonSerializer.Serialize(request)}");

            var response = base.UnaryServerHandler(request, context, continuation);

            _logger.LogInformation($"[{nameof(GrpcLoggingInterceptor)}] -> {JsonSerializer.Serialize(response)}");

            return response;
        }
    }
}
