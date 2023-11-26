using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

[Table("TBL_TRANSACTION")]
public partial class TblTransaction
{
    [Key]
    [Column("ID_TRANSACTION")]
    public int IdTransaction { get; set; }

    [Column("ID_ACCOUNT")]
    public int IdAccount { get; set; }

    [Column("DESCRIPTION")]
    [StringLength(150)]
    [Unicode(false)]
    public string Description { get; set; } = null!;

    [Column("URL_ATTACH")]
    [StringLength(250)]
    [Unicode(false)]
    public string? UrlAttach { get; set; }

    [Column("VALUE")]
    public double Value { get; set; }

    [ForeignKey("IdAccount")]
    [InverseProperty("TblTransactions")]
    public virtual TblUserAccount IdAccountNavigation { get; set; } = null!;
}
