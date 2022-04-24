using System.Net;
using Dominisoft.Nokates.Common.Infrastructure.Attributes;
using Dominisoft.Nokates.Identity.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dominisoft.Nokates.Identity.Controllers
{
    [Route("Authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [NoAuth]
        public ActionResult<string> Authenticate([FromBody] creds credentials)
        {
            var password = credentials.EncryptedPassword;
            var username = credentials.Username;
            var token = _authenticationService.Authenticate(username, password);
            return new JsonResult(token);
        }

        [HttpPost("Logout")]
        [EndpointGroup("AuthorizedUsers")]
        public ActionResult Logout()
        {
            var key = Request.Headers["AuthorizationKey"];
            return Ok(new { LogOut = true });
        }
    }

    public class creds
    {
        public string Username { get; set; }
        public string EncryptedPassword { get; set; }
    }
}
