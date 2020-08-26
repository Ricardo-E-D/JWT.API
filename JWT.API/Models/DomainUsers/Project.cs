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
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        //foreign keys
        [ForeignKey("IdentityUser")]
        public string Id { get; set; }
        public IdentityUser IdentityUser { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        //outgoing relations
        [ForeignKey("ProjectId")]
        public IEnumerable<EndUser> EndUsers { get; set; }
    }
}
