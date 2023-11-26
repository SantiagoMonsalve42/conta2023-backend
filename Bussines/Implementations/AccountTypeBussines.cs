using Azure.Core;
using Bussines.Interfaces;
using Data.Implementations;
using Data.Models;
using DTO.request;
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

        public async Task<CreateAccountTypeDTO> create(CreateAccountTypeDTO request, string ip, string usuario)
        {
            var audit = await _audit.crearAuditoria("Crear tipos de cuenta", usuario, ip);
            try
            {
                var result = await _data.Add(request.Clone<CreateAccountTypeDTO, TblAccountType>());
                await _audit.exitoAuditoria((int)audit.IdLog, "Correcto");
                return result.Clone<TblAccountType, CreateAccountTypeDTO>();
            }
            catch (Exception ex)
            {
                await _audit.falloAuditoria((int)audit.IdLog, "error:" + ex.Message);
            }
            return null;
        }

        public async Task<bool> delete(int id, string ip, string usuario)
        {
            var audit = await _audit.crearAuditoria("Eliminar tipos de cuenta", usuario, ip);
            try
            {
                var deleted = await _data.delete(id);
                await _audit.exitoAuditoria((int)audit.IdLog, "Correcto");
                return deleted;
            }
            catch (Exception ex)
            {
                await _audit.falloAuditoria((int)audit.IdLog, "error:" + ex.Message);
            }
            return false;
        }

        public async Task<ICollection<AccountTypeDTO>> get(string ip, string usuario)
        {
            var audit = await _audit.crearAuditoria("Consultar tipos de cuenta",usuario,ip);
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

        public async Task<CreateAccountTypeDTO> get(int id, string ip, string usuario)
        {
            var audit = await _audit.crearAuditoria("Consultar tipos de cuenta por id "+id, usuario, ip);
            try
            {
                var result = await _data.get(id);
                await _audit.exitoAuditoria((int)audit.IdLog, "Correcto");
                return result.Clone<TblAccountType, CreateAccountTypeDTO>();
            }
            catch (Exception ex)
            {
                await _audit.falloAuditoria((int)audit.IdLog, "error:" + ex.Message);
            }
            return null;
        }

        public async Task<CreateAccountTypeDTO> update(CreateAccountTypeDTO request, string ip, string usuario)
        {
            var audit = await _audit.crearAuditoria("Actualizar tipos de cuenta", usuario, ip);
            try
            {
                var result = await _data.Update(request.Clone<CreateAccountTypeDTO, TblAccountType>());
                await _audit.exitoAuditoria((int)audit.IdLog, "Correcto");
                return result.Clone<TblAccountType, CreateAccountTypeDTO>();
            }
            catch (Exception ex)
            {
                await _audit.falloAuditoria((int)audit.IdLog, "error:" + ex.Message);
            }
            return null;
        }
    }
}
