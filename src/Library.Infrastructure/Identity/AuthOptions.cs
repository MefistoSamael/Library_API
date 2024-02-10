using Microsoft.IdentityModel.Tokens;
using System.Text;

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
