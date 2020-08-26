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
//    public class CustomerEntitySchemaDefinition : IEntityTypeConfiguration<Customer>
//    {
//        public void Configure(EntityTypeBuilder<Customer> builder)
//        {
//            builder.ToTable("Customers", ApplicationDbContext.DEFAULT_SCHEMA);
//            builder.HasKey(k => k.CustomerId);

//            builder.HasOne(a => a.IdentityUser)
//                .WithOne(a => a.Customer)
//                .HasForeignKey<Customer>(k => k.ApplicationUserFk);
//        }
//    }
//}
