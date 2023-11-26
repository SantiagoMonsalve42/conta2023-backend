using Bussines.Interfaces;
using DTO.request;
using Microsoft.AspNetCore.Mvc;

namespace contabilidadAPI.Controllers
{
    public class TransaccionController : BaseController
    {
        private readonly ITransactionBussines _bussines;
        public TransaccionController(ITransactionBussines bussines)
        {
            _bussines = bussines;
        }
        [HttpPost]
        public async Task<ObjectResult> create([FromForm]TransactionCreateDTO request)
        {
            var create = await _bussines.Create(request, Ip, User);
            return await GetReponseAnswer(create);
        }
        [HttpPut]
        public async Task<ObjectResult> put([FromForm] TransactionUpdateDTO request)
        {
            var create = await _bussines.Update(request, Ip, User);
            return await GetReponseAnswer(create);
        }
        [HttpDelete]
        public async Task<ObjectResult> delete(int id)
        {
            var create = await _bussines.Delete(id, Ip, User);
            return await GetReponseAnswer(create);
        }

        [HttpGet]
        public async Task<ObjectResult> get(int id)
        {
            var create = await _bussines.getById(id, Ip, User);
            return await GetReponseAnswer(create);
        }

        [HttpGet]
        public async Task<ObjectResult> getByAccount(int idAccount)
        {
            var create = await _bussines.getByAccount(idAccount,Ip, User);
            return await GetReponseAnswer(create);
        }
    }
}
