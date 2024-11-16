using System.Net;
using System.Security.Claims;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AuthHub.SDK.Attributes
{
    public class RequireClaim: ActionFilterAttribute
    {
        private readonly string _name;
        private readonly string _value;

        public RequireClaim(
            string name
            )
        {
            _name = name;
        }

        public RequireClaim(
            string name,
            string value
            )
            :this(name)
        {
            _value = value;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {   
            Claim claim = context.HttpContext.User.Claims.FirstOrDefault(x=> x.Type == _name);
            if (claim == null)
                context.Result = new UnauthorizedResult();
            if (!string.IsNullOrWhiteSpace(_value) && claim.Value != _value)
                context.Result = new UnauthorizedResult();
            await base.OnActionExecutionAsync(context, next);
        }
    }
}