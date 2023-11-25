using Data.Common;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class TransaccionData : BaseCrud<TblTransaction>, ITransaccionData
    {
        private IRepository<TblTransaction> _repo;
        public TransaccionData(IRepository<TblTransaction> repo) : base(repo)
        {
            _repo = repo;
        }

        public async Task<ICollection<TblTransaction>> getByAccount(int id)
        {
            var existe = await (from s in _repo.Entity
                                where s.IdAccount == id
                                select s).ToListAsync();
            return existe;
        }

        public async Task<TblTransaction> getById(int id)
        {
            var existe = await (from s in _repo.Entity
                                where s.IdTransaction == id
                                select s).FirstOrDefaultAsync();
            return existe;
        }
        public async Task<bool> Delete(int id)
        {
            var existe = await (from s in _repo.Entity
                               where s.IdTransaction == id
                               select s).FirstOrDefaultAsync();
            await _repo.Delete(existe);
            return true;
        }
    }
}
