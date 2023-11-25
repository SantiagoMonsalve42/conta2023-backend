
using Microsoft.AspNetCore.Http;

namespace DTO.request
{
    public class TransactionCreateDTO
    {
        public int IdAccount { get; set; }
        public string Description { get; set; } = null!;
        public double Value { get; set; }
        public IFormFile? Adjunto { get; set; }
    }
}
