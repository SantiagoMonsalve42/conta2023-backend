using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

[Table("TBL_USER")]
public partial class TblUser
{
    [Key]
    [Column("ID_USER")]
    public int IdUser { get; set; }

    [Column("USERNAME")]
    [StringLength(200)]
    [Unicode(false)]
    public string Username { get; set; } = null!;

    [Column("EMAIL")]
    [StringLength(200)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [Column("PASSWORD")]
    [StringLength(500)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    [Column("ID_DOCUMENT_TYPE")]
    public int IdDocumentType { get; set; }

    [Column("DOCUMENT")]
    [StringLength(200)]
    [Unicode(false)]
    public string Document { get; set; } = null!;

    [Column("LAST_TOKEN")]
    [Unicode(false)]
    public string? LastToken { get; set; }

    [Column("ID_ROL")]
    public int IdRol { get; set; }

    [ForeignKey("IdDocumentType")]
    [InverseProperty("TblUsers")]
    public virtual TblDocumentType IdDocumentTypeNavigation { get; set; } = null!;

    [ForeignKey("IdRol")]
    [InverseProperty("TblUsers")]
    public virtual TblRol IdRolNavigation { get; set; } = null!;

    [InverseProperty("IdUserNavigation")]
    public virtual ICollection<TblUserAccount> TblUserAccounts { get; set; } = new List<TblUserAccount>();
}
