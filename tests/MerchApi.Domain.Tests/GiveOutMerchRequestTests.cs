using System;
using System.Collections.Generic;

using MerchApi.Domain.AggregationModels.MerchPackAggregate;
using MerchApi.Domain.AggregationModels.MerchRequestAggregate;

using Xunit;

namespace MerchApi.Domain.Tests
{
    public class GiveOutMerchRequestTests
    {
        [Fact]
        public void Create_GiveOutMerchRequest_Success()
        {
            //Arrange 
            var employee = new Employee(Email.Create("test@test.ru"));
            var merchType = MerchType.WelcomePack;
            var request = GiveOutMerchRequest.Create(
             employee,
             RequestStatus.Created,
             new MerchPack(merchType, GetSkus(merchType)),
             DateTime.UtcNow);

            //Assert
            Assert.Equal(employee, request.Employee);
            Assert.Equal(MerchType.WelcomePack, request.MerchPack.MerchType);
            Assert.Equal(RequestStatus.Created, request.Status);
        }

        private static List<Sku> GetSkus(MerchType merchType)
        {
            var skus = new List<Sku>();

            if (merchType == MerchType.WelcomePack)
            {
                skus.AddRange(new List<Sku>() { Sku.Create(1), Sku.Create(2) });
            }

            if (merchType == MerchType.ProbationPeriodEndingPack)
            {
                skus.AddRange(new List<Sku>() { Sku.Create(3) });
            }

            if (merchType == MerchType.ConferenceListenerPack)
            {
                skus.AddRange(new List<Sku>() { Sku.Create(4), Sku.Create(5) });
            }

            if (merchType == MerchType.ConferenceSpeakerPack)
            {
                skus.AddRange(new List<Sku>() { Sku.Create(6), Sku.Create(7), Sku.Create(8) });
            }

            if (merchType == MerchType.VeteranPack)
            {
                skus.AddRange(new List<Sku>() { Sku.Create(9), Sku.Create(10) });
            }

            return skus;
        }
    }
}