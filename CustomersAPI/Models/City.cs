namespace CustomersAPI.Models
{
    public class City : BaseModel
    {
        public string Description { get; set; }
        public int CountryId { get; set; }
        public Country? Country { get; set; }
        public List<Neighborhood> neighborhoods { get; set; } = new List<Neighborhood>();
    }
}
