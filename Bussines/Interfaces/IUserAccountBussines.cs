using Data.Models;
using DTO.request;
using DTO.response;
using System.Xml.Linq;

namespace Bussines.Interfaces
{
    public interface IUserAccountBussines
    {
        public Task<bool> Update(UserAccountUpdateDTO request, string ip, string user);
        public Task<bool> Create(UserAccountCreateDTO request, string ip, string user);
        public Task<bool> ChangeStatus(int id, string ip, string user);
        public Task<UserAccountDTO> getById(int id, string ip, string user);
        public Task<ICollection<UserAccountDTO>> getByUser(string ip, string user);
    }
}
