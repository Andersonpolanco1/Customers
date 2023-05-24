namespace CustomersAPI.Models
{
    public class Country : BaseModel
    {
        public string Description { get; set; }
        public List<City> Cities { get; set; } = new List<City>();
    }
}
