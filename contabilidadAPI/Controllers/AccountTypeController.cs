using Bussines.Interfaces;
using DTO.request;
using DTO.response;
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
        [HttpGet]
        [Authorize(Policy = "isAdmin")]
        public async Task<ObjectResult> getById(int id)
        {
            return await base.GetReponseAnswer(await _bussines.get(id,Ip, User));
        }
        [HttpPost]
        [Authorize(Policy = "isAdmin")]
        public async Task<ObjectResult> Create([FromBody] CreateAccountTypeDTO id)
        {
            return await base.GetReponseAnswer(await _bussines.create(id, Ip, User));
        }
        [HttpPut]
        [Authorize(Policy = "isAdmin")]
        public async Task<ObjectResult> Update([FromBody] CreateAccountTypeDTO id)
        {
            return await base.GetReponseAnswer(await _bussines.update(id, Ip, User));
        }
        [HttpDelete]
        [Authorize(Policy = "isAdmin")]
        public async Task<ObjectResult> Delete(int id)
        {
            return await base.GetReponseAnswer(await _bussines.delete(id, Ip, User));
        }
    }
}
