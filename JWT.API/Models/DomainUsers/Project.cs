using JWT.API.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.API.Models.DomainUsers
{
    public class Project
    {
        public int ProjectId { get; set; }

        //foreign keys
        public string ApplicationUserFk { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int CustomerFk { get; set; }
        public Customer Customer { get; set; }

        //outgoing relations
        public IEnumerable<EndUser> EndUsers { get; set; }
    }
}
