using System;

using MerchApi.Domain.AggregationModels.MerchAggregate;

using Xunit;

namespace MerchApi.Domain.Tests
{
    public class GiveOutMerchRequestTests
    {
        [Fact]
        public void Create_GiveOutMerchRequest_Success()
        {
            //Arrange 
            var request = new GiveOutMerchRequest(1, MerchType.WelcomePack);

            //Assert
            Assert.Equal(1, request.EmployeeId);
            Assert.Equal(MerchType.WelcomePack, request.MerchType);
            Assert.Equal(RequestStatus.Draft, request.Status);
        }

        [Fact]
        public void Register_GiveOutMerchRequest_Success()
        {
            //Arrange 
            var request = new GiveOutMerchRequest(1, MerchType.WelcomePack);

            // Act
            request.Register();

            //Assert
            Assert.Equal(RequestStatus.Created, request.Status);
        }

        [Fact]
        public void DoubleRegister_GiveOutMerchRequest_Fail()
        {
            //Arrange 
            var request = new GiveOutMerchRequest(1, MerchType.WelcomePack);

            // Act
            request.Register();

            //Assert
            Assert.Throws<Exception>(() => request.Register());
        }

        [Fact]
        public void Create_GiveOutMerchRequest_WithInvalidEmployeeId_Fail()
        {
            Assert.Throws<Exception>(() => new GiveOutMerchRequest(-1, MerchType.WelcomePack));
        }

        [Fact]
        public void Create_GiveOutMerchRequest_WithInvalidMerchType_Fail()
        {
            Assert.Throws<Exception>(() => new GiveOutMerchRequest(1, null));
        }
    }
}