using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;

namespace TeendokLista.DAL.Models
{
    public class TeendokContext : DbContext
    {
        private string connectionString;

        public TeendokContext()
        {
            connectionString = ConfigurationManager.ConnectionStrings["TeendokDB"].ConnectionString;
        }

        public DbSet<Feladat> Feladatok { get; set; }
        public DbSet<Felhasznalo> Felhasznalok { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }
    }
}
