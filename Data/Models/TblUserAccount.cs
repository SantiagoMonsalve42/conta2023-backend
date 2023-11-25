using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

[Table("TBL_USER_ACCOUNT")]
public partial class TblUserAccount
{
    [Key]
    [Column("ID_ACCOUNT")]
    public int IdAccount { get; set; }

    [Column("ID_USER")]
    public int? IdUser { get; set; }

    [Column("ID_ACCOUNT_TYPE")]
    public int IdAccountType { get; set; }

    [Column("DESCRIPTION")]
    [Unicode(false)]
    public string? Description { get; set; }

    [Column("NAME")]
    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Required]
    [Column("ENABLED")]
    public bool? Enabled { get; set; }

    [ForeignKey("IdAccountType")]
    [InverseProperty("TblUserAccounts")]
    public virtual TblAccountType IdAccountTypeNavigation { get; set; } = null!;

    [ForeignKey("IdUser")]
    [InverseProperty("TblUserAccounts")]
    public virtual TblUser? IdUserNavigation { get; set; }
}
