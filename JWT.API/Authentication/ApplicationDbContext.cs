using JWT.API.Models.DomainUsers;
using JWT.API.Schematics;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JWT.API.Authentication
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public const string DEFAULT_SCHEMA = "TrainYourEyes";

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<EndUser> EndUsers { get; set; }
        public DbSet<Project> Projects { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AdminEntitySchemaDefinition());
            builder.ApplyConfiguration(new CustomerEntitySchemaDefinition());
            builder.ApplyConfiguration(new EndUserEntitySchemaDefinition());
            builder.ApplyConfiguration(new ProjectEntitySchemaDefinition());
            base.OnModelCreating(builder);
        }
    }
}
