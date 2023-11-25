
using Microsoft.AspNetCore.Http;

namespace DTO.request
{
    public class TransactionUpdateDTO
    {
        public int IdTransaction { get; set; }
        public string Description { get; set; } = null!;
        public double Value { get; set; }
        public IFormFile? Adjunto { get; set; }
    }
}
