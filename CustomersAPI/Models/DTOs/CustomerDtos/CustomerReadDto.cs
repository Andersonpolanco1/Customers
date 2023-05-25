namespace CustomersAPI.Models.DTOs.CustomerDtos
{
    public class CustomerReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
