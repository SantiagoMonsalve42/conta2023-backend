
using Data.Common;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class LogData : BaseCrud<TblLog>,ILogData
    {
        private IRepository<TblLog> _repo;
        public LogData(IRepository<TblLog> repo) :base(repo)
        {
            _repo = repo;
        }

        public async Task<TblLog> getById(int id)
        {
            var result = await(from row in _repo.Entity where row.IdLog == id select row).FirstOrDefaultAsync();
            return result;
        }
    }
}
