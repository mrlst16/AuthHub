using Microsoft.AspNetCore.Authorization;

namespace AuthHub.SDK
{
    public class JWTTokenAttribute : AuthorizeAttribute
    {
        public JWTTokenAttribute()
            : base()
        {
        }
    }
}