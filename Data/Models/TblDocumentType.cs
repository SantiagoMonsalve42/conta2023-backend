using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;

[Table("TBL_DOCUMENT_TYPE")]
public partial class TblDocumentType
{
    [Key]
    [Column("ID_DOCUMENT_TYPE")]
    public int IdDocumentType { get; set; }

    [Column("DOCUMENT_TYPE")]
    [StringLength(100)]
    [Unicode(false)]
    public string DocumentType { get; set; } = null!;


    [InverseProperty("IdDocumentTypeNavigation")]
    public virtual ICollection<TblUser> TblUsers { get; set; } = new List<TblUser>();
}
