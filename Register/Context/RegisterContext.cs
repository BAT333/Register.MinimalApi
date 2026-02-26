using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Register.Model;

namespace Register.Context
{
    public class RegisterContext : IdentityDbContext<CustomerAccessAuth,CustomerAccessProfile,int>
    {
        public RegisterContext(DbContextOptions<RegisterContext> options) : base(options) { }

        public DbSet<Customer> customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
