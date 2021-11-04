using MerchApi.Http.Enums;

namespace MerchApi.Http.Requests
{
    /// <summary>
    /// Запрос от Админки на выдачу мерча сотруднику
    /// </summary>
    public class GiveOutMerchRequest
    {
        public int EmployeeId { get; init; }

        public MerchType MerchType { get; init; }
    }
}
