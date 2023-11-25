using DTO.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace contabilidadAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BaseController : Controller
    {

        protected async Task<ObjectResult> GetReponseAnswer(object response,HttpStatusCode status=HttpStatusCode.OK)
        {
            return await Task.Run(
                () =>
                {
                    return new ObjectResult(new HttpResponseDto { Data = response })
                    { StatusCode = (int)status };
                });
        }
        public string? Ip {
            get
            {
                
                return Request.HttpContext.Connection.RemoteIpAddress?.ToString();
            }
        }
        public string? User
        {
            get
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claim = identity.Claims;
                var usernameClaim = claim
                                    .Where(x => x.Type == ClaimTypes.Email)
                                    .FirstOrDefault();
                return usernameClaim?.Value ?? "PUBLIC ENDPOINT";
            }
        }
    }
}
