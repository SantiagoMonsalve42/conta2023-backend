using Bussines.Interfaces;
using Data.Interfaces;
using Data.Models;

namespace Bussines.Implementations
{
    public class LogBussines:ILogBussines
    {
        private ILogData _logData;
        public LogBussines(ILogData logData)
        {
            _logData = logData;
        }
        public async Task<TblLog> crearAuditoria(string description,string ip,string user)
        {
            return await _logData.Add(new TblLog
            {
                Date = DateTime.Now,
                Description = description,
                Ip = ip,
                Message = "",
                State = "P",
                User= user
            });
        }
        public async Task<TblLog> exitoAuditoria(int id, string errorMessage)
        {
            var existe = await _logData.getById(id);
            if(existe == null)
            {
                return null;
            }
            existe.State = "S";
            existe.Message = errorMessage;
            return await _logData.Update(existe);
        }
        public async Task<TblLog> falloAuditoria(int id, string errorMessage)
        {
            var existe = await _logData.getById(id);
            if (existe == null)
            {
                return null;
            }
            existe.State = "F";
            existe.Message = errorMessage;
            return await _logData.Update(existe);
        }
    }
}
