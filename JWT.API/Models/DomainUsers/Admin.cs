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
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        //foreign keys
        [ForeignKey("IdentityUser")]
        public string Id { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }
    }
}
