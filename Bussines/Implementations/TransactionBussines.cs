using Bussines.implementations;
using Bussines.Interfaces;
using Data.Interfaces;
using Data.Models;
using DTO.request;
using DTO.response;
using Util;

namespace Bussines.Implementations
{
    public class TransactionBussines : ITransactionBussines
    {
        private readonly ITransaccionData _data;
        private readonly ILogBussines _log;
        private readonly FileSystemGenerico _file;
        public TransactionBussines(ITransaccionData data, ILogBussines log,FileSystemGenerico file)
        {
            _data = data;
            _log = log;
            _file = file;
        }
        public async Task<bool> Create(TransactionCreateDTO request, string ip, string user)
        {
            bool status = false;
            TblLog idLog = await _log.crearAuditoria("Crear transaccion", user, ip);
            try
            {
                var Ruta = "";
                if(request.Adjunto != null)
                {
                    Ruta= await _file.subirArchivo(request.Adjunto, user, ip);
                }
                TblTransaction dato= request.Clone<TransactionCreateDTO, TblTransaction>();
                dato.UrlAttach = Ruta;
                await _data.Add(dato);
                status = true;
                await _log.exitoAuditoria((int)idLog.IdLog, "OK");
            }
            catch (Exception ex)
            {
                await _log.falloAuditoria((int)idLog.IdLog, ex.Message);
            }
            return status;
        }

        public async Task<bool> Delete(int id, string ip, string user)
        {
            bool status = false;
            TblLog idLog = await _log.crearAuditoria("Eliminar transaccion", user, ip);
            try
            {
                await _data.Delete(id);
                status = true;
                await _log.exitoAuditoria((int)idLog.IdLog, "OK");
            }
            catch (Exception ex)
            {
                await _log.falloAuditoria((int)idLog.IdLog, ex.Message);
            }
            return status;
        }

        public async Task<ICollection<TransactionDTO>> getByAccount(int id,string ip, string user)
        {
            ICollection<TransactionDTO> status = null;
            TblLog idLog = await _log.crearAuditoria("Get transaccion por cuenta id ", user, ip);
            try
            {
                ICollection<TblTransaction> account = await _data.getByAccount(id);
                status = account.Clone<TblTransaction, TransactionDTO>();
                await _log.exitoAuditoria((int)idLog.IdLog, "OK");
            }
            catch (Exception ex)
            {
                await _log.falloAuditoria((int)idLog.IdLog, ex.Message);
            }
            return status;
        }

        public async Task<TransactionDTO> getById(int id, string ip, string user)
        {
            TransactionDTO status = null;
            TblLog idLog = await _log.crearAuditoria("Get transaccion por id", user, ip);
            try
            {
                TblTransaction account = await _data.getById(id);
                status = account.Clone<TblTransaction, TransactionDTO>();
                await _log.exitoAuditoria((int)idLog.IdLog, "OK");
            }
            catch (Exception ex)
            {
                await _log.falloAuditoria((int)idLog.IdLog, ex.Message);
            }
            return status;
        }

        public async Task<bool> Update(TransactionUpdateDTO request, string ip, string user)
        {
            bool status = false;
            TblLog idLog = await _log.crearAuditoria("Actualizar transaccion", user, ip);
            try
            {
                TblTransaction account = await _data.getById(request.IdTransaction);
                var Ruta = "";
                if (request.Adjunto != null)
                {
                    Ruta = await _file.subirArchivo(request.Adjunto, user,ip);
                    account.UrlAttach = Ruta;
                }
                account.Description = request.Description;
                account.Value = request.Value;
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
    }
}
