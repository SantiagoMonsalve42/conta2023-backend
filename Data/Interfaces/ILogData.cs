using Data.Common;
using Data.Models;

namespace Data.Interfaces
{
    public interface ILogData: IBaseCrud<TblLog>
    {
        Task<TblLog> getById(int id);
    }
}
