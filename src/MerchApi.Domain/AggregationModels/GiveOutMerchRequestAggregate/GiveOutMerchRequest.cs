using MerchApi.Domain.SharedKernel.Models;

namespace MerchApi.Domain.AggregationModels.GiveOutMerchRequestAggregate
{
    /// <summary>
    /// Запрос на выдачу мерча
    /// </summary>
    public class GiveOutMerchRequest : Entity
    {
        /// <summary>
        /// Номер заявки
        /// </summary>
        public RequestNumber RequestNumber { get; private set; }

        public GiveOutMerchRequest(RequestNumber requestNumber)
        {
            RequestNumber = requestNumber;
        }
    }
}
