
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

            //Act
          //  request.IncreaseQuantity(valueToIncrease);

            //Assert
          //  Assert.Equal(20, request.Quantity.Value);
        }

    }
}
