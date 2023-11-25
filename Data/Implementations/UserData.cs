using Data.Common;
using Data.Interfaces;
using Data.Models;
using DTO.common;
using DTO.response;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using Util;

namespace Data.Implementations
{
    public class UserData : BaseCrud<TblUser>, IUserData
    {
        private readonly IRepository<TblUser> _repo;
        private readonly ExecuteSp _sp;
        public UserData(IRepository<TblUser> repo, ExecuteSp sp) : base(repo)
        {
            _repo = repo;
            _sp = sp;
        }
        public SpGenericResult Createuser(TblUser entity)
        {
            List<SpParamGeneric> paramGenerics = new List<SpParamGeneric>
            {
                new SpParamGeneric { Name= "@User", Size = 200, Type= System.Data.SqlDbType.VarChar,Value=entity.Username},
                new SpParamGeneric { Name= "@Document", Size = 200, Type= System.Data.SqlDbType.VarChar,Value=entity.Document},
                new SpParamGeneric { Name= "@Mail", Size = 250, Type= System.Data.SqlDbType.VarChar,Value=entity.Email},
                new SpParamGeneric { Name= "@Password", Size = 500, Type= System.Data.SqlDbType.VarChar,Value=entity.Password},
                new SpParamGeneric { Name= "@Id_document_type", Size = 1, Type= System.Data.SqlDbType.Int,Value=entity.IdDocumentType}
            };
            SpGenericResult resultado=_sp.ExecuteStoredProcedure("[dbo].[CREATE_USER]", paramGenerics);
            return resultado;
        }
        public DataTable GetTotalByAccounts(string usuario)
        {
            List<SpParamGeneric> paramGenerics = new List<SpParamGeneric>
            {
                new SpParamGeneric { Name= "@User", Size = 200, Type= System.Data.SqlDbType.VarChar,Value=usuario}
            };
            DataTable result= _sp.ExecuteStoredProcedureList("[dbo].[GET_TOTAL_CUENTAS_POR_USUARIO]", paramGenerics);
            return result;
        }
        public DataTable GetTotal(string usuario)
        {
            List<SpParamGeneric> paramGenerics = new List<SpParamGeneric>
            {
                new SpParamGeneric { Name= "@User", Size = 200, Type= System.Data.SqlDbType.VarChar,Value=usuario}
            };
            DataTable result = _sp.ExecuteStoredProcedureList("[dbo].[GET_TOTAL_POR_USUARIO]", paramGenerics);
            return result;
        }

        public async Task<TblUser> getByUserMail(string userName)
        {
            var existe = await (from s in _repo.Entity 
                                        where s.Email.ToLower() == userName.ToLower() 
                                                || s.Username.ToLower() == userName.ToLower() 
                                select s).FirstOrDefaultAsync();
            return existe;
        }

        public SpGenericResult Login(string user, string pass)
        {
            List<SpParamGeneric> paramGenerics = new List<SpParamGeneric>
            {
                new SpParamGeneric { Name= "@User", Size = 200, Type= System.Data.SqlDbType.VarChar,Value=user},
                new SpParamGeneric { Name= "@Password", Size = 500, Type= System.Data.SqlDbType.VarChar,Value=pass},
            };
            SpGenericResult resultado = _sp.ExecuteStoredProcedure("[dbo].[LOGIN_USER]", paramGenerics);
            return resultado;
        }
    }
}
