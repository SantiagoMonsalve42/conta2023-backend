using Bussines.Interfaces;
using DTO.common;
using DTO.request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace contabilidadAPI.Controllers
{
    public class UserController: BaseController
    {
        public readonly IUserBussines _bussines;

        public UserController(IUserBussines bussines)
        {
            _bussines = bussines;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ObjectResult> crear(CreateUserDTO request)
        {
            SpGenericResult result = await _bussines.Crear(request, Ip, User);
            switch (result.Status)
            {
                case "400":
                    return await base.GetReponseAnswer(result,HttpStatusCode.BadRequest);
                case "0":
                    return await base.GetReponseAnswer(result, HttpStatusCode.Created);
                default:
                    return await base.GetReponseAnswer(result, HttpStatusCode.BadRequest);
            }
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ObjectResult> login(LoginDTO request)
        {
            return await base.GetReponseAnswer(await _bussines.Login(request, Ip, User));
        }

        
        [HttpPost]
        public async Task<ObjectResult> refreshToken(UpdateTokenDTO request)
        {
            return await base.GetReponseAnswer(await _bussines.UpdateToken(request, Ip, User));
        }

        [HttpPost]
        public async Task<ObjectResult> getTotalByAccounts()
        {
            return await base.GetReponseAnswer(await _bussines.GetTotalByAccounts(Ip, User));
        }
        [HttpPost]
        public async Task<ObjectResult> getTotal()
        {
            return await base.GetReponseAnswer(await _bussines.GetTotal(Ip, User));
        }
    }
}
