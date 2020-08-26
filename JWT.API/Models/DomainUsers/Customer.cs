using JWT.API.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.API.Models.DomainUsers
{
    public class Customer
    {
        public int CustomerId { get; set; }

        //foreign keys
        public string ApplicationUserFk { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        //outgoing relations
        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<EndUser> EndUsers { get; set; }
    }
}
