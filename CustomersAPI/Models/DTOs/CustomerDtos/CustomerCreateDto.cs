namespace CustomersAPI.Models.DTOs.CustomerDtos
{
    public class CustomerCreateDto
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
