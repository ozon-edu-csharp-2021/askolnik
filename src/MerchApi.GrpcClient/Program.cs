using System;

using Grpc.Core;
using Grpc.Net.Client;

using MerchApi.Grpc;

using var channel = GrpcChannel.ForAddress("https://localhost:5001");
var client = new MerchApiGrpc.MerchApiGrpcClient(channel);

try
{
    var response = await client.GetMerchAvailabilityAsync(new MerchApi.Grpc.GetMerchAvailabilityRequest
    {
        Id = 1
    });

    Console.WriteLine(response?.MerchAvailabilityInfo);
}
catch (RpcException e)
{
    Console.WriteLine(e);
}


try
{
    var response = await client.GiveOutMerchAsync(new MerchApi.Grpc.GiveOutMerchRequest
    {
        Id = 1
    });

    Console.WriteLine(response?.Merch);
}
catch (RpcException e)
{
    Console.WriteLine(e);
}

Console.ReadKey();