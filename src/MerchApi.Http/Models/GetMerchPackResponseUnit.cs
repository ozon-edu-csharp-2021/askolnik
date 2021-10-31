namespace MerchApi.Http.Models
{
    public class GetMerchPackResponseUnit
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public GetMerchPackResponseUnit(string name, long id)
        {
            Name = name;
            Id = id;
        }
    }
}
