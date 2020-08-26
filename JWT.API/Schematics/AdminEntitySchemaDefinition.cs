using JWT.API.Authentication;
using JWT.API.Models.DomainUsers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.API.Schematics
{
    public class AdminEntitySchemaDefinition : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.ToTable("Admins", ApplicationDbContext.DEFAULT_SCHEMA);
            builder.HasKey(k => k.AdminId);

            builder.HasOne(a => a.ApplicationUser)
                .WithOne(a => a.Admin)
                .HasForeignKey<Admin>(k => k.ApplicationUserFk);
        }
    }
}
