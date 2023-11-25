using Bussines.Interfaces;
using Data.Implementations;
using Data.Models;
using DTO.response;
using Util;

namespace Bussines.implementations
{
    public class AccountTypeBussines : IAccountTypeBussines
    {
        private readonly AccountTypeData _data;
        private readonly ILogBussines _audit;

        public AccountTypeBussines(AccountTypeData data, ILogBussines audit)
        {
            _data = data;
            _audit = audit;
        }

        public async Task<ICollection<AccountTypeDTO>> get(string ip, string usuario)
        {
            var audit = await _audit.crearAuditoria("Consultar tipos de cuenta",ip,usuario);
            try
            {
                var result = await _data.Get();
                await _audit.exitoAuditoria((int)audit.IdLog, "Correcto");
                return result.Clone<TblAccountType, AccountTypeDTO>();
            }
            catch (Exception ex)
            {
                await _audit.falloAuditoria((int)audit.IdLog, "error:"+ex.Message);
            }
            return null;
        }
    }
}
