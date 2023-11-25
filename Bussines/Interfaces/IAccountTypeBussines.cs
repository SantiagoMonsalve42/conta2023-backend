using DTO.response;

namespace Bussines.Interfaces
{
    public interface IAccountTypeBussines
    {
        public Task<ICollection<AccountTypeDTO>> get(string ip,string usuario);
    }
}
