using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.API.Models.DomainUsers
{
    public class ProjectEndUser
    {
        [Key]
        public int ProjectEndUserId { get; set; }

        //foreign keys
        [ForeignKey("IdentityUser")]
        public string Id { get; set; }
        public IdentityUser IdentityUser { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
