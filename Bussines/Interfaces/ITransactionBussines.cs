using DTO.request;
using DTO.response;

namespace Bussines.Interfaces
{
    public interface ITransactionBussines
    {
        public Task<bool> Update(TransactionUpdateDTO request, string ip, string user);
        public Task<bool> Create(TransactionCreateDTO request, string ip, string user);
        public Task<bool> Delete(int id, string ip, string user);
        public Task<TransactionDTO> getById(int id, string ip, string user);
        public Task<ICollection<TransactionDTO>> getByAccount(int id,string ip, string user);
    }
}
