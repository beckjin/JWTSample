using TestApi.Auth;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public ValuesController(IIdentityService identityService)
        {
            _identityService = identityService;
        }


        [HttpGet]
        [Authorize]
        public async Task<string> Get()
        {
            await Task.CompletedTask;

            return $"{_identityService.GetUserId()}:{_identityService.GetUserName()}";
        }
    }
}
