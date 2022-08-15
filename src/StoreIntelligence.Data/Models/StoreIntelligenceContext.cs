using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace StoreIntelligence.Data.Models
{
    public partial class StoreIntelligenceContext : DbContext
    {
        public StoreIntelligenceContext()
        {
        }

        public StoreIntelligenceContext(DbContextOptions<StoreIntelligenceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LogEjecucione> LogEjecuciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=DESKTOP-VGA6SQT\\LOCALHOST;Database=StoreIntelligence;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<LogEjecucione>(entity =>
            {
                entity.Property(e => e.FechaHora).HasColumnType("datetime");

                entity.Property(e => e.Origen)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
                
                entity.Property(e => e.Equipo)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
