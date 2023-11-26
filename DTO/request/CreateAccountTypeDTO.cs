namespace DTO.request
{
    public class CreateAccountTypeDTO
    {
        public int IdAccountType { get; set; }
        public string AccountType { get; set; } = null!;
        public bool Positive { get; set; }
    }
}
