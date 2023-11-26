using Data.Common;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class AccountTypeData : BaseCrud<TblAccountType>, IAccountTypeData
    {
        public AccountTypeData(IRepository<TblAccountType> repo) : base(repo)
        {
        }

        public async Task<bool> delete(int id)
        {
            var existe = await (from s in _repo.Entity
                                where s.IdAccountType == id
                                select s).FirstOrDefaultAsync();
            await _repo.Delete(existe);
            return true;
        }

        public async Task<TblAccountType> get(int id)
        {
            var existe = await (from s in _repo.Entity
                                where s.IdAccountType == id
                                select s).FirstOrDefaultAsync();
            return existe;
        }

    }
}
