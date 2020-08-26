using JWT.API.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.API.Models.DomainUsers
{
    public class Admin
    {
        public int AdminId { get; set; }

        //foreign keys
        public string ApplicationUserFk { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
