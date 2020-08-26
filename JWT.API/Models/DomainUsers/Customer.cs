using JWT.API.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.API.Models.DomainUsers
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        //foreign keys
        [ForeignKey("IdentityUser")]
        public string Id { get; set; }
        public IdentityUser IdentityUser { get; set; }

        //outgoing relations
        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<EndUser> EndUsers { get; set; }
    }
}
