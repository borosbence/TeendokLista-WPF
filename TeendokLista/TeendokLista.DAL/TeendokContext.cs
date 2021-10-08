using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using TeendokLista.Models;

namespace TeendokLista.DAL
{
    public class TeendokContext : DbContext
    {
        public TeendokContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Feladat> Feladatok { get; set; }
        public DbSet<Felhasznalo> Felhasznalok { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Felhasznalo>()
                .HasIndex(user => user.Felhasznalonev)
                .IsUnique(true);
        }
    }
}
