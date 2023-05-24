namespace CustomersAPI.Models
{
    public class Address : BaseModel
    {
        public int NeighborhoodId { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string? Observations { get; set; }
        public int CustomerId { get; set; }
        public Neighborhood? Neighborhood { get; set; }
        public Customer? Customer { get; set; }
    }
}
