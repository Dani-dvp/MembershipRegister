using Microsoft.EntityFrameworkCore;

namespace MembershipRegister.Domain
{
    public class MembershipDbContext : DbContext
    {
        public MembershipDbContext(DbContextOptions<MembershipDbContext> options) : base(options)
        {
        }

        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
