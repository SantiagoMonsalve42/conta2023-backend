namespace DTO.response
{
    public class LoginResponseDTO
    {
        public string Token { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public bool Status { get; set; } = false;
        public LoginResponseDTO(string token,bool status,string message) {
            Token = token;
            Status = status;
            Message = message;
        }
    }
}
