using Microsoft.EntityFrameworkCore;
using TestOrionTek.Data.Models;

namespace TestOrionTek.Data
{
    public class TestOrionTek_apiContext : DbContext
    {
        public TestOrionTek_apiContext(DbContextOptions<TestOrionTek_apiContext> options) : base(options) { }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerDetails> CustomerDetails { get; set; }

    }
}
