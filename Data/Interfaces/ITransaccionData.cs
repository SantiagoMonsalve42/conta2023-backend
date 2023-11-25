using Data.Common;
using Data.Models;

namespace Data.Interfaces
{
    public interface ITransaccionData: IBaseCrud<TblTransaction>
    {
        Task<TblTransaction> getById(int id);
        Task<ICollection<TblTransaction>> getByAccount(int id);
        Task<bool> Delete(int id);
    }
}
