using DTO.response;

namespace Bussines.Interfaces
{
    public interface IDocumentTypeBussines
    {
        Task<ICollection<DocumentTypeDTO>> get(string ip, string usuario);
    }
}
