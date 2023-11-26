using DTO.request;
using DTO.response;

namespace Bussines.Interfaces
{
    public interface IAccountTypeBussines
    {
        public Task<ICollection<AccountTypeDTO>> get(string ip,string usuario);
        public Task<CreateAccountTypeDTO> get(int id,string ip, string usuario);
        public Task<CreateAccountTypeDTO> create(CreateAccountTypeDTO request, string ip, string usuario);
        public Task<CreateAccountTypeDTO> update(CreateAccountTypeDTO request, string ip, string usuario);
        public Task<bool> delete(int id, string ip, string usuario);
    }
}
