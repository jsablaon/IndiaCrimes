using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IndiaCrimes.Models
{
    public partial class IndiaCrimeDBContext : DbContext
    {
        public IndiaCrimeDBContext()
        {
        }

        public IndiaCrimeDBContext(DbContextOptions<IndiaCrimeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CrimeFactTable> CrimeFactTables { get; set; } = null!;
        public virtual DbSet<CriminalFactTable> CriminalFactTables { get; set; } = null!;
        public virtual DbSet<EighteenThirtyTable> EighteenThirtyTables { get; set; } = null!;
        public virtual DbSet<FithtyUpTable> FithtyUpTables { get; set; } = null!;
        public virtual DbSet<GenderTable> GenderTables { get; set; } = null!;
        public virtual DbSet<PropertyRecoveredTable> PropertyRecoveredTables { get; set; } = null!;
        public virtual DbSet<PropertyStolenTable> PropertyStolenTables { get; set; } = null!;
        public virtual DbSet<SixteenUnderTable> SixteenUnderTables { get; set; } = null!;
        public virtual DbSet<ThirtyFithtyTable> ThirtyFithtyTables { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-JC3S25B\\HMSSQLSERVER;Database=IndiaCrimeDB;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CrimeFactTable>(entity =>
            {
                entity.HasKey(e => e.CrimeId);

                entity.ToTable("Crime_FactTable");

                entity.Property(e => e.CrimeId)
                    .ValueGeneratedNever()
                    .HasColumnName("crimeID");

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .HasColumnName("location");

                entity.Property(e => e.PrecovId).HasColumnName("precovID");

                entity.Property(e => e.PstoleId).HasColumnName("pstoleID");

                entity.Property(e => e.Year).HasColumnName("year");
            });

            modelBuilder.Entity<CriminalFactTable>(entity =>
            {
                entity.HasKey(e => e.CriminalId);

                entity.ToTable("Criminal_FactTable");

                entity.Property(e => e.CriminalId)
                    .ValueGeneratedNever()
                    .HasColumnName("criminalID");

                entity.Property(e => e.AeightntothirtId).HasColumnName("aeightntothirtID");

                entity.Property(e => e.AfithabovId).HasColumnName("afithabovID");

                entity.Property(e => e.AsixtnUid).HasColumnName("asixtnUID");

                entity.Property(e => e.AthirttofithId).HasColumnName("athirttofithID");

                entity.Property(e => e.GenderId).HasColumnName("genderID");

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .HasColumnName("location");

                entity.Property(e => e.Year).HasColumnName("year");
            });

            modelBuilder.Entity<EighteenThirtyTable>(entity =>
            {
                entity.HasKey(e => e.AeightntothirtId);

                entity.ToTable("Eighteen_Thirty_Table");

                entity.Property(e => e.AeightntothirtId)
                    .ValueGeneratedNever()
                    .HasColumnName("aeightntothirtID");

                entity.Property(e => e.Aeightntothirt).HasColumnName("aeightntothirt");
            });

            modelBuilder.Entity<FithtyUpTable>(entity =>
            {
                entity.HasKey(e => e.AfithabovId);

                entity.ToTable("Fithty_Up_Table");

                entity.Property(e => e.AfithabovId)
                    .ValueGeneratedNever()
                    .HasColumnName("afithabovID");

                entity.Property(e => e.Afithabov).HasColumnName("afithabov");
            });

            modelBuilder.Entity<GenderTable>(entity =>
            {
                entity.HasKey(e => e.GenderId);

                entity.ToTable("Gender_Table");

                entity.Property(e => e.GenderId)
                    .ValueGeneratedNever()
                    .HasColumnName("genderID");

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .HasColumnName("gender");
            });

            modelBuilder.Entity<PropertyRecoveredTable>(entity =>
            {
                entity.HasKey(e => e.PrecovId);

                entity.ToTable("Property_RecoveredTable");

                entity.Property(e => e.PrecovId)
                    .ValueGeneratedNever()
                    .HasColumnName("precovID");

                entity.Property(e => e.PrecoVal).HasColumnName("precoVal");

                entity.Property(e => e.Precov).HasColumnName("precov ");
            });

            modelBuilder.Entity<PropertyStolenTable>(entity =>
            {
                entity.HasKey(e => e.PstoleId);

                entity.ToTable("Property_StolenTable");

                entity.Property(e => e.PstoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("pstoleID");

                entity.Property(e => e.Pstole).HasColumnName("pstole");

                entity.Property(e => e.PstoleVal).HasColumnName("pstoleVal");
            });

            modelBuilder.Entity<SixteenUnderTable>(entity =>
            {
                entity.HasKey(e => e.AsixtnUid);

                entity.ToTable("Sixteen_Under_Table");

                entity.Property(e => e.AsixtnUid)
                    .ValueGeneratedNever()
                    .HasColumnName("asixtnUID");

                entity.Property(e => e.AsixtnU).HasColumnName("asixtnU");
            });

            modelBuilder.Entity<ThirtyFithtyTable>(entity =>
            {
                entity.HasKey(e => e.AthirttofithId);

                entity.ToTable("Thirty_Fithty_Table");

                entity.Property(e => e.AthirttofithId)
                    .ValueGeneratedNever()
                    .HasColumnName("athirttofithID");

                entity.Property(e => e.Athirttofith).HasColumnName("athirttofith");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
