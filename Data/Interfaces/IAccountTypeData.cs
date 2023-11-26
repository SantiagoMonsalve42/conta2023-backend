using Data.Models;

namespace Data.Interfaces
{
    public interface IAccountTypeData
    {
        Task<TblAccountType> get(int id);
        Task<bool> delete(int id);
    }
}
