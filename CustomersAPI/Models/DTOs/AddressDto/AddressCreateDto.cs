namespace CustomersAPI.Models.DTOs.AddressDto
{
    public class AddressCreateDto
    {
        public int CustomerId { get; set; }
        public int NeighborhoodId { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string? Observations { get; set; }
    }
}
