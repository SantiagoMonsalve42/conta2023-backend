namespace DTO.request
{
    public class CreateUserDTO
    {
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Document { get; set; } = null!;
        public int IdDocumentType { get; set; }
    }
}
