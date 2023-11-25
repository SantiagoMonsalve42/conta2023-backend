
namespace DTO.request
{
    public class UserAccountCreateDTO
    {
        public int IdAccountType { get; set; }
        public string? Description { get; set; }
        public string Name { get; set; } = null!;
    }
}
