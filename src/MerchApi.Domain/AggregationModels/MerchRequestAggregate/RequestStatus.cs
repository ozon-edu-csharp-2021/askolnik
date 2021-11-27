using MerchApi.Domain.SharedKernel.Models;

namespace MerchApi.Domain.AggregationModels.MerchRequestAggregate
{
    /// <summary>
    /// Статус заявки на выдачу мерча сотруднику
    /// </summary>
    public class RequestStatus : Enumeration
    {
        /// <summary>
        /// Черновик
        /// </summary>
        public static RequestStatus Draft = new(0, "Draft");

        /// <summary>
        /// Новая заявка
        /// </summary>
        public static RequestStatus Created = new(1, "Created");

        /// <summary>
        /// Заявка в работе
        /// </summary>
        public static RequestStatus InWork = new(2, "InWork");

        /// <summary>
        /// Заявка обработана
        /// </summary>
        public static RequestStatus Done = new(3, "Done");

        /// <summary>
        /// Заявка отклонена
        /// </summary>
        public static RequestStatus Decline = new(4, "Decline");

        public RequestStatus(int id, string name) : base(id, name)
        {
        }
    }
}