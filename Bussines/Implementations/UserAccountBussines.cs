using Bussines.Interfaces;
using Data.Implementations;
using Data.Interfaces;
using Data.Models;
using DTO.request;
using DTO.response;
using Util;

namespace Bussines.Implementations
{
    public class UserAccountBussines : IUserAccountBussines
    {
        private readonly IUserAccountData _data;
        private readonly IUserData _datauser;
        private readonly ILogBussines _log;
        public UserAccountBussines(IUserAccountData data, IUserData IUserData, ILogBussines log)
        {
            _data = data;
            _datauser = IUserData;
            _log = log;
        }
        public async Task<bool> Update(UserAccountUpdateDTO request, string ip, string user)
        {
            bool status = false;
            TblLog idLog = await _log.crearAuditoria("Actualizar cuenta para usuario", user, ip);
            try
            {
                TblUserAccount account = await _data.getById(request.IdAccount);
                account.Description = request.Description;
                account.Name = request.Name;
                await _data.Update(account);
                status = true;
                await _log.exitoAuditoria((int)idLog.IdLog, "Se actualizo la cuenta correctamente");

            }
            catch (Exception ex)
            {
                await _log.falloAuditoria((int)idLog.IdLog, ex.Message);
            }
            return status;
        }
        public async Task<bool> Create(UserAccountCreateDTO request, string ip, string user)
        {
            bool status = false;
            TblLog idLog = await _log.crearAuditoria("Crear cuenta para usuario", user, ip);
            try
            {
                TblUser userExists = await _datauser.getByUserMail(user);
                await _data.Add(new Data.Models.TblUserAccount
                {
                    Description = request.Description,
                    Name = request.Name,
                    Enabled = true,
                    IdAccountType = request.IdAccountType,
                    IdUser = userExists.IdUser,
                });
                status = true;
                await _log.exitoAuditoria((int)idLog.IdLog, "Se creo la cuenta correctamente");
            }
            catch (Exception ex)
            {
                await _log.falloAuditoria((int)idLog.IdLog, ex.Message);
            }
            return status;
        }
        public async Task<bool> ChangeStatus(int id, string ip, string user)
        {
            bool status = false;
            TblLog idLog = await _log.crearAuditoria("Cambiar estado cuenta para usuario", user, ip);
            try
            {
                TblUserAccount account = await _data.getById(id);
                account.Enabled = !account.Enabled;
                await _data.Update(account);
                status = true;
                await _log.exitoAuditoria((int)idLog.IdLog, "OK");
            }
            catch (Exception ex)
            {
                await _log.falloAuditoria((int)idLog.IdLog, ex.Message);
            }
            return status;
        }
        public async Task<UserAccountDTO> getById(int id, string ip, string user)
        {
            UserAccountDTO status = null;
            TblLog idLog = await _log.crearAuditoria("Get cuenta by id", user, ip);
            try
            {
                TblUserAccount account = await _data.getById(id);
                status = account.Clone<TblUserAccount, UserAccountDTO>();
                await _log.exitoAuditoria((int)idLog.IdLog, "OK");
            }
            catch (Exception ex)
            {
                await _log.falloAuditoria((int)idLog.IdLog, ex.Message);
            }
            return status;
        }
        public async Task<ICollection<UserAccountDTO>> getByUser(string ip, string user)
        {
            ICollection<UserAccountDTO> status = null;
            TblLog idLog = await _log.crearAuditoria("Get cuenta by user ", user, ip);
            try
            {
                TblUser userExits = await _datauser.getByUserMail(user);
                ICollection<TblUserAccount> account = await _data.getByOwner(userExits.IdUser);
                status = account.Clone<TblUserAccount, UserAccountDTO>();
                await _log.exitoAuditoria((int)idLog.IdLog, "OK");
            }
            catch (Exception ex)
            {
                await _log.falloAuditoria((int)idLog.IdLog, ex.Message);
            }
            return status;
        }

    }
}
