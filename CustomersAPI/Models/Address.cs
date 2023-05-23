namespace CustomersAPI.Models
{
    public class Address : BaseModel
    {
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int NeighborhoodId { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public int CustomerId { get; set; }
        public string? Observations { get; set; }
        public Neighborhood? Neighborhood { get; set; }
        public City? City { get; set; }
        public Country? Country { get; set; }
        public Customer? Customer { get; set; }
    }
}
