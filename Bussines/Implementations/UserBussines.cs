using Azure.Core;
using Bussines.Interfaces;
using Data.Interfaces;
using Data.Models;
using DTO.common;
using DTO.request;
using DTO.response;
using System.Data;
using Util;

namespace Bussines.Implementations
{
    public class UserBussines: IUserBussines
    {
        private readonly IUserData _data;
        private readonly ILogBussines _log;
        private readonly StringUtil _util;

        public UserBussines(IUserData data, ILogBussines log, StringUtil util)
        {
            _data = data;
            _log = log;
            _util = util;
        }

        public async Task<SpGenericResult> Crear(CreateUserDTO request, string Ip,string User)
        {

            SpGenericResult status=new SpGenericResult { Message= "Error",Status="1"};
            TblLog idAudit = await _log.crearAuditoria("Creacion usuario", Ip,User);
            try
            {
                request.Password = StringUtil.GetSHA256(request.Password);
                status= _data.Createuser(request.Clone<CreateUserDTO, TblUser>());
                await _log.exitoAuditoria((int)idAudit.IdLog, "Correcto: " + request.Username);
            }
            catch (Exception ex)
            {
                await _log.falloAuditoria((int)idAudit.IdLog, "Fallo: " +ex.Message);
            }
            return status;
        }
        public async Task<LoginResponseDTO> Login(LoginDTO request, string Ip, string User)
        {

            SpGenericResult status = new SpGenericResult { Message = "Error", Status = "1" };
            LoginResponseDTO loginResponse= new LoginResponseDTO(null, false,null);
            TblLog idAudit = await _log.crearAuditoria("Login usuario", Ip, User);
            try
            {
                request.Password = StringUtil.GetSHA256(request.Password);
                status = _data.Login(request.Username,request.Password);
                if(status.Status == "0")
                {
                    TblUser user = await _data.getByUserMail(request.Username);
                    string token = _util.GenerateToken(user.Email, user.IdUser);
                    user.LastToken = token;
                    await _data.Update(user);
                    loginResponse = new LoginResponseDTO(token, true,status.Message);
                }
                else
                {
                    loginResponse = new LoginResponseDTO(null, false, status.Message);
                }
                await _log.exitoAuditoria((int)idAudit.IdLog, "Correcto: " + request.Username);
            }
            catch (Exception ex)
            {
                await _log.falloAuditoria((int)idAudit.IdLog, "Fallo: " + ex.Message);
            }
            return loginResponse;
        }

        public async Task<LoginResponseDTO> UpdateToken(UpdateTokenDTO request, string Ip, string User)
        {
            TblLog idAudit = await _log.crearAuditoria("Refresh token", Ip, User);
            LoginResponseDTO loginResponse = new LoginResponseDTO(null, false, null);
            try
            {
                TblUser user = await _data.getByUserMail(request.Username);
                if(user.LastToken == request.Token)
                {
                    string token = _util.GenerateToken(user.Email, user.IdUser);
                    user.LastToken = token;
                    await _data.Update(user);
                    loginResponse = new LoginResponseDTO(token, true, "OK");
                    await _log.exitoAuditoria((int)idAudit.IdLog, "Correcto: " + request.Username);
                }
                else
                {
                    loginResponse = new LoginResponseDTO(null, false, null);
                    await _log.exitoAuditoria((int)idAudit.IdLog, "Correcto pero no actualiza: " + request.Username);
                }
            }
            catch (Exception ex)
            {
                await _log.falloAuditoria((int)idAudit.IdLog, "Fallo: " + ex.Message);
            }
            return loginResponse;
        }
        public async Task<DataTable> GetTotalByAccounts(string Ip, string User)
        {
            DataTable response =null;
            TblLog idAudit = await _log.crearAuditoria("Get total por cuentas usuario", Ip, User);
            try
            {
                response = _data.GetTotalByAccounts(User);
                await _log.exitoAuditoria((int)idAudit.IdLog, "Correcto: " + User);
            }
            catch (Exception ex)
            {
                await _log.falloAuditoria((int)idAudit.IdLog, "Fallo: " + ex.Message);
            }
            return response;
        }
        public async Task<DataTable> GetTotal(string Ip, string User)
        {
            DataTable response = null;
            TblLog idAudit = await _log.crearAuditoria("Get total por cuentas usuario", Ip, User);
            try
            {
                response = _data.GetTotal(User);
                await _log.exitoAuditoria((int)idAudit.IdLog, "Correcto: " + User);
            }
            catch (Exception ex)
            {
                await _log.falloAuditoria((int)idAudit.IdLog, "Fallo: " + ex.Message);
            }
            return response;
        }
    }
}
