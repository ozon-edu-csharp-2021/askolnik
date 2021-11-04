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

        /// <summary>
        /// Статус заявки
        /// </summary>
        public RequestStatus RequestStatus { get; private set; }

        public GiveOutMerchRequest(
            RequestNumber requestNumber,
            RequestStatus requestStatus)
        {
            RequestNumber = requestNumber;
            RequestStatus = requestStatus;
        }
    }
}
