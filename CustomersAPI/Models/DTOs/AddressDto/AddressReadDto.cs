namespace CustomersAPI.Models.DTOs.AddressDto
{
    public class AddressReadDto
    {
        public int CustomerId { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public string NeighborhoodName { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string? Observations { get; set; }
    }
}
