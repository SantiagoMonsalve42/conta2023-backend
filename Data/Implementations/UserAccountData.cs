using Data.Common;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class UserAccountData : BaseCrud<TblUserAccount>, IUserAccountData
    {
        private IRepository<TblUserAccount> _repo;
        public UserAccountData(IRepository<TblUserAccount> repo) : base(repo)
        {
            _repo = repo;
        }

        public async Task<ICollection<TblUserAccount>> getByOwner(int id)
        {
            var existe = await(from s in _repo.Entity
                               where s.IdUser == id
                               select s).ToListAsync();
            return existe;
        }

        public async Task<TblUserAccount> getById(int id)
        {
            var existe = await(from s in _repo.Entity
                               where s.IdAccount == id
                               select s).FirstOrDefaultAsync();
            return existe;
        }
    }
}
