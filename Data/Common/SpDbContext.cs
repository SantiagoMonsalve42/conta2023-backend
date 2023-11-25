
using Constants;
using Microsoft.EntityFrameworkCore;


namespace Data.Models
{
    public partial class SpDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            if (!optionBuilder.IsConfigured)
            {
                optionBuilder.UseSqlServer(Variable.STRINGCONNECTION,
                    sqlServerOptionsAction: sqlOption =>
                    {
                        sqlOption.EnableRetryOnFailure();
                    });
            }
        }

        public virtual DbSet<TotalByAccount> TotalByAccount { get; set; }
    }
}
