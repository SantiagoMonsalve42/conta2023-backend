using Bussines.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace contabilidadAPI.Controllers
{
    public class AccountTypeController : BaseController
    {
        public readonly IAccountTypeBussines _bussines;

        public AccountTypeController(IAccountTypeBussines bussines)
        {
            _bussines = bussines;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ObjectResult> get()
        {
            return await base.GetReponseAnswer(await _bussines.get(Ip,User));
        }
    }
}
