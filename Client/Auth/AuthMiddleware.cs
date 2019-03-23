using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace TestApi.Auth
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var result = await httpContext.AuthenticateAsync(JwtBearerDefaults.AuthenticationScheme);

            if (!result.Succeeded)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await httpContext.Response.WriteAsync("Unauthorized");
            }
            else
            {
                httpContext.User = result.Principal;
                await _next.Invoke(httpContext);
            }
        }
    }
}
