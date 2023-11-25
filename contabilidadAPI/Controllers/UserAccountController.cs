using Bussines.Interfaces;
using DTO.request;
using Microsoft.AspNetCore.Mvc;

namespace contabilidadAPI.Controllers
{
    public class UserAccountController: BaseController
    {
        private readonly IUserAccountBussines _bussines;

        public UserAccountController(IUserAccountBussines bussines)
        {
            _bussines = bussines;
        }

        [HttpPost]
        public async Task<ObjectResult> create(UserAccountCreateDTO request)
        {
            var create =await _bussines.Create(request,Ip,User);
            return await GetReponseAnswer(create);
        }
        [HttpPut]
        public async Task<ObjectResult> put(UserAccountUpdateDTO request)
        {
            var create = await _bussines.Update(request, Ip, User);
            return await GetReponseAnswer(create);
        }
        [HttpPut]
        public async Task<ObjectResult> changeStatus(int id)
        {
            var create = await _bussines.ChangeStatus(id, Ip, User);
            return await GetReponseAnswer(create);
        }

        [HttpGet]
        public async Task<ObjectResult> get(int id)
        {
            var create = await _bussines.getById(id, Ip, User);
            return await GetReponseAnswer(create);
        }

        [HttpGet]
        public async Task<ObjectResult> getByOwner()
        {
            var create = await _bussines.getByUser( Ip, User);
            return await GetReponseAnswer(create);
        }
    }
}
