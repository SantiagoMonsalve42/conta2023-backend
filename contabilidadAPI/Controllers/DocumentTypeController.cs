using Bussines.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace contabilidadAPI.Controllers
{
    public class DocumentTypeController: BaseController
    {
        public readonly IDocumentTypeBussines _bussines;

        public DocumentTypeController(IDocumentTypeBussines bussines)
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
