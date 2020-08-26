//using JWT.API.Authentication;
//using JWT.API.Models.DomainUsers;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace JWT.API.Schematics
//{
//    public class EndUserEntitySchemaDefinition : IEntityTypeConfiguration<EndUser>
//    {
//        public void Configure(EntityTypeBuilder<EndUser> builder)
//        {
//            builder.ToTable("EndUsers", ApplicationDbContext.DEFAULT_SCHEMA);
//            builder.HasKey(k => k.EndUserId);

//            builder.HasOne(a => a.IdentityUser)
//                .WithOne(a => a.EndUser)
//                .HasForeignKey<EndUser>(k => k.ApplicationUserFk);

//            builder.HasOne(c => c.Customer)
//                .WithMany(e => e.EndUsers)
//                .HasForeignKey(k => k.CustomerFk);

//            builder.HasOne(c => c.Project)
//                .WithMany(e => e.EndUsers)
//                .HasForeignKey(k => k.ProjectFk);
//        }
//    }
//}
