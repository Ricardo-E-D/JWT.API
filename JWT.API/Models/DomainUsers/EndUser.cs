using JWT.API.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.API.Models.DomainUsers
{
    public class EndUser
    {
        public int EndUserId { get; set; }

        //foreign keys
        public string ApplicationUserFk { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int CustomerFk { get; set; }
        public Customer Customer { get; set; }

        public int ProjectFk { get; set; }
        public Project Project { get; set; }
    }
}
