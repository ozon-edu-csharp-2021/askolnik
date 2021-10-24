using System;

using Grpc.Core;
using Grpc.Net.Client;

using MerchApi.Grpc;

using var channel = GrpcChannel.ForAddress("https://localhost:5001");
var client = new MerchApiGrpc.MerchApiGrpcClient(channel);

try
{
    var response = await client.GetMerchPackAsync(new GetMerchPackRequest
    {
        Id = 1,
    });

    Console.WriteLine(response?.MerchPack);
}
catch (RpcException e)
{
    Console.WriteLine(e);
}


try
{
    var response = await client.GetMerchDeliveryInfoAsync(new GetMerchDeliveryInfoRequest
    {
        Id = 1
    });

    Console.WriteLine(response?.MerchDeliveryInfo);
}
catch (RpcException e)
{
    Console.WriteLine(e);
}

Console.ReadKey();