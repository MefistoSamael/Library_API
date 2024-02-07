using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Identity
{
    public static class AuthOptions
    {
        public static readonly string Issuer = "Library API";

        public static readonly string Audience = "Also library API";

        const string KEY = "awesome_super_secret_key_brilliant_thing";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
