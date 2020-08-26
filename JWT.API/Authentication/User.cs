using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.API.Authentication
{
    public class User
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string JwtToken { get; set; }
    }
}
