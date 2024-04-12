using Microsoft.EntityFrameworkCore;
using Server.Core.Entities;

namespace Server.Data.DBContexts
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<AdminRefreshTokenInfo> AdminRefreshTokenInfos { get; set; }
        public DbSet<CustomerRefreshTokenInfo> CustomerRefreshTokenInfos { get; set; }
    }
}
