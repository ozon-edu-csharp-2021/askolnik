namespace MerchApi.Infrastructure.Repositories.Models
{
    public class MerchPack
    {
        public int Id { get; set; }

        public int MerchTypeId { get; set; }

        public bool CanBeReissued { get; set; }

        public int? CanBeReissuedAfterDays { get; private set; }
    }
}