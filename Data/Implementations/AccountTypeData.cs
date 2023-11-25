using Data.Common;
using Data.Models;

namespace Data.Implementations
{
    public class AccountTypeData : BaseCrud<TblAccountType>
    {
        public AccountTypeData(IRepository<TblAccountType> repo) : base(repo)
        {
        }
    }
}
