using CustomersAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomersAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
