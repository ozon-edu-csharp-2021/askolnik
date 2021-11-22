using System.ComponentModel.DataAnnotations;

using MerchApi.Http.Enums;

namespace MerchApi.Http.Requests
{
    /// <summary>
    /// Запрос от Админки на выдачу мерча сотруднику
    /// </summary>
    public record GiveOutMerchRequest
    {
        [EmailAddress]
        [Required]
        public string EmployeeEmail { get; init; }

        [Required]
        public MerchType MerchType { get; init; }
    }
}