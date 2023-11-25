using Bussines.Interfaces;
using Data.Implementations;
using Data.Models;
using DTO.response;
using Util;

namespace Bussines.Implementations
{
    public class DocumentTypeBussines : IDocumentTypeBussines
    {
        private DocumentTypeData _data;
        private readonly ILogBussines _audit;
        public DocumentTypeBussines(DocumentTypeData data, ILogBussines audit)
        {
            _data = data;
            _audit = audit;
        }
        public async Task<ICollection<DocumentTypeDTO>> get(string ip, string usuario)
        {
            var audit = await _audit.crearAuditoria("Consultar tipos de documento", ip, usuario);
            try
            {
                var result = await _data.Get();
                await _audit.exitoAuditoria((int)audit.IdLog, "Correcto");
                return result.Clone<TblDocumentType, DocumentTypeDTO>();
            }
            catch (Exception ex)
            {
                await _audit.falloAuditoria((int)audit.IdLog, "error:" + ex.Message);
            }
            return null;
        }
    }
}
