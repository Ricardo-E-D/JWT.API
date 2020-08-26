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
    public class ProjectEntitySchemaDefinition : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects", ApplicationDbContext.DEFAULT_SCHEMA);
            builder.HasKey(k => k.ProjectId);

            builder.HasOne(a => a.ApplicationUser)
                .WithOne(a => a.Project)
                .HasForeignKey<Project>(k => k.ApplicationUserFk);

            builder.HasOne(c => c.Customer)
                .WithMany(p => p.Projects)
                .HasForeignKey(k => k.CustomerFk);
        }
    }
}
