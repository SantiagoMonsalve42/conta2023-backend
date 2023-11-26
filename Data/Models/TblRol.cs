using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

[Table("TBL_ROL")]
public partial class TblRol
{
    [Key]
    [Column("ID_ROL")]
    public int IdRol { get; set; }

    [Column("DESCRIPTION")]
    [StringLength(100)]
    [Unicode(false)]
    public string Description { get; set; } = null!;

    [InverseProperty("IdRolNavigation")]
    public virtual ICollection<TblUser> TblUsers { get; set; } = new List<TblUser>();
}
