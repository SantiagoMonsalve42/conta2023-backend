
namespace DTO.request
{
    public class UserAccountUpdateDTO
    {
        public int IdAccount { get; set; }
        public string? Description { get; set; }
        public string Name { get; set; } = null!;
    }
}
