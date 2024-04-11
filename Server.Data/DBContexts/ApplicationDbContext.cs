using Microsoft.EntityFrameworkCore;
using Server.Core.Entities;

namespace Server.Data.DBContexts
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Profile)
                .WithOne(p => p.Customer)
                .HasForeignKey<Customer>(c => c.ProfileId)
                .OnDelete(DeleteBehavior.Cascade);
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Profile> Profiles { get; set; }
    }
}
