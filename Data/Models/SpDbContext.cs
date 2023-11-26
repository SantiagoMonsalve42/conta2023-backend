using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

public partial class SpDbContext : DbContext
{
    public SpDbContext()
    {
    }

    public SpDbContext(DbContextOptions<SpDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAccountType> TblAccountTypes { get; set; }

    public virtual DbSet<TblDocumentType> TblDocumentTypes { get; set; }

    public virtual DbSet<TblLog> TblLogs { get; set; }

    public virtual DbSet<TblRol> TblRols { get; set; }

    public virtual DbSet<TblTransaction> TblTransactions { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    public virtual DbSet<TblUserAccount> TblUserAccounts { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblLog>(entity =>
        {
            entity.Property(e => e.State).IsFixedLength();
        });

        modelBuilder.Entity<TblRol>(entity =>
        {
            entity.Property(e => e.IdRol).ValueGeneratedNever();
        });

        modelBuilder.Entity<TblTransaction>(entity =>
        {
            entity.HasOne(d => d.IdAccountNavigation).WithMany(p => p.TblTransactions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TBL_TRANSACTION_TBL_USER_ACCOUNT");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasOne(d => d.IdDocumentTypeNavigation).WithMany(p => p.TblUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TBL_USER_TBL_DOCUMENT_TYPE");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.TblUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TBL_USER_TBL_ROL");
        });

        modelBuilder.Entity<TblUserAccount>(entity =>
        {
            entity.Property(e => e.Enabled).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.IdAccountTypeNavigation).WithMany(p => p.TblUserAccounts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TBL_USER_ACCOUNT_TBL_ACCOUNT_TYPE");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.TblUserAccounts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TBL_USER_ACCOUNT_TBL_USER");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
