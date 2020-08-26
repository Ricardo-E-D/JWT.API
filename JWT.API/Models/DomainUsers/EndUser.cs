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
    public class EndUser
    {
        [Key]
        public int EndUserId { get; set; }

        //foreign keys
        [ForeignKey("IdentityUser")]
        public string Id { get; set; }
        public IdentityUser IdentityUser { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
