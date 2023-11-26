using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

[Table("TBL_ACCOUNT_TYPE")]
public partial class TblAccountType
{
    [Key]
    [Column("ID_ACCOUNT_TYPE")]
    public int IdAccountType { get; set; }

    [Column("ACCOUNT_TYPE")]
    [StringLength(150)]
    [Unicode(false)]
    public string AccountType { get; set; } = null!;

    [Column("POSITIVE")]
    public bool Positive { get; set; }

    [InverseProperty("IdAccountTypeNavigation")]
    public virtual ICollection<TblUserAccount> TblUserAccounts { get; set; } = new List<TblUserAccount>();
}
