using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TeendokLista.Models
{
    public partial class TeendokContext : DbContext
    {
        public TeendokContext()
        {
        }

        public TeendokContext(DbContextOptions<TeendokContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Feladat> Feladatok { get; set; }
        public virtual DbSet<Felhasznalo> Felhasznalok { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;user id=root;database=teendoklista", ServerVersion.Parse("10.4.21-mariadb"))
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            modelBuilder.Entity<Feladat>(entity =>
            {
                entity.HasOne(d => d.Felhasznalo)
                    .WithMany(p => p.feladatok)
                    .HasForeignKey(d => d.FelhasznaloId)
                    .HasConstraintName("FK_Feladatok_Felhasznalok_FelhasznaloId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
