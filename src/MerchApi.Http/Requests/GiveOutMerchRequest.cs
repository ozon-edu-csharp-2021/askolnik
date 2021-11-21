using MerchApi.Http.Enums;

namespace MerchApi.Http.Requests
{
    /// <summary>
    /// Запрос от Админки на выдачу мерча сотруднику
    /// </summary>
    public record GiveOutMerchRequest
    {
        public int EmployeeId { get; init; }

        public string EmployeeEmail { get; init; }

        public MerchType MerchType { get; init; }
    }
}