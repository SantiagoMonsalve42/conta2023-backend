using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

[Table("TBL_LOG")]
public partial class TblLog
{
    [Key]
    [Column("ID_LOG")]
    public long IdLog { get; set; }

    [Column("IP")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Ip { get; set; }

    [Column("USER")]
    [StringLength(200)]
    [Unicode(false)]
    public string User { get; set; } = null!;

    [Column("DATE", TypeName = "datetime")]
    public DateTime Date { get; set; }

    [Column("STATE")]
    [StringLength(1)]
    [Unicode(false)]
    public string State { get; set; } = null!;

    [Column("DESCRIPTION")]
    [StringLength(150)]
    [Unicode(false)]
    public string Description { get; set; } = null!;

    [Column("MESSAGE")]
    [Unicode(false)]
    public string Message { get; set; } = null!;
}
