using Data.Common;
using Data.Models;
using DTO.common;
using DTO.response;
using System.Data;

namespace Data.Interfaces
{
    public interface IUserData: IBaseCrud<TblUser>
    {
        public SpGenericResult Createuser(TblUser entity);
        public DataTable GetTotalByAccounts(string usuario);
        public DataTable GetTotal(string usuario);
        public SpGenericResult Login(string user,string pass);
        public Task<TblUser> getByUserMail(string userName);
    }
}
