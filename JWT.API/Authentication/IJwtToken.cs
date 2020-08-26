using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.API.Authentication
{
    public interface IJwtToken
    {
        SecurityTokenDescriptor CreateToken(IdentityUser user, IList<string> userRoles);
    }
}
