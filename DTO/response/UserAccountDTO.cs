
namespace DTO.response
{
    public class UserAccountDTO
    {
        public int IdAccount { get; set; }
        public int IdAccountType { get; set; }
        public string? Description { get; set; }
        public string Name { get; set; } = null!;
        public bool? Enabled { get; set; }
    }
}
