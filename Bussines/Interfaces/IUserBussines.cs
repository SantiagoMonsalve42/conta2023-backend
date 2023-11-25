using DTO.common;
using DTO.request;
using DTO.response;
using System.Data;

namespace Bussines.Interfaces
{
    public interface IUserBussines
    {
        Task<SpGenericResult> Crear(CreateUserDTO request, string Ip, string User);
        Task<LoginResponseDTO> Login(LoginDTO request, string Ip, string User);
        Task<LoginResponseDTO> UpdateToken(UpdateTokenDTO request, string Ip, string User);
        Task<DataTable> GetTotalByAccounts(string Ip, string User);
        Task<DataTable> GetTotal(string Ip, string User);
    }
}
