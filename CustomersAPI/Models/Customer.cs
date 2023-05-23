namespace CustomersAPI.Models
{
    public enum Gender { Male, Female}

    public class Customer : BaseModel
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public List<Address> Addresses { get; set; }

    }
}
