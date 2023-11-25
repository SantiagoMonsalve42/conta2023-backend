using Microsoft.AspNetCore.Http;

namespace DTO.request
{
    public class subirArchivoDTO
    {
        public string? ruta { get; set; }
        public IFormFile archivo { get; set; }
    }
}
