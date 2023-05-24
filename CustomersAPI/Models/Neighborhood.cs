namespace CustomersAPI.Models
{
    public class Neighborhood : BaseModel
    {
        public string Description { get; set; }
        public int CityId { get; set; }
        public City? City { get; set; }
    }
}
