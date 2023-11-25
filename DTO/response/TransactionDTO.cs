
namespace DTO.response
{
    public class TransactionDTO
    {
        public int IdTransaction { get; set; }
        public string Description { get; set; } = null!;
        public string? UrlAttach { get; set; }
        public double Value { get; set; }
    }
}
