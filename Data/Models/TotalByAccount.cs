using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    [Keyless]
    public partial class TotalByAccount
    {
        [Column("TOTAL")]
        public long? Total { get; set; }

        [Column("NAME")]
        public string? Name { get; set; }
    }
}
