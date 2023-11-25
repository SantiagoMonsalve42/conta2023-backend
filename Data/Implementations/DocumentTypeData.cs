using Data.Common;
using Data.Models;

namespace Data.Implementations
{
    public class DocumentTypeData : BaseCrud<TblDocumentType>
    {
        public DocumentTypeData(IRepository<TblDocumentType> repo) : base(repo)
        {
        }
    }
}
