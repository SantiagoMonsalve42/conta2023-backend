using Data.Common;
using Data.Models;

namespace Data.Interfaces
{
    public interface IUserAccountData: IBaseCrud<TblUserAccount >
    {
        Task<TblUserAccount> getById(int id);
        Task<ICollection<TblUserAccount>> getByOwner(int id);
    }
}
