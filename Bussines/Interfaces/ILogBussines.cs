using Data.Models;

namespace Bussines.Interfaces
{
    public interface ILogBussines
    {
        public  Task<TblLog> crearAuditoria(string description, string user, string ip);
        public  Task<TblLog> exitoAuditoria(int id, string errorMessage);
        public  Task<TblLog> falloAuditoria(int id, string errorMessage);
    }
}
