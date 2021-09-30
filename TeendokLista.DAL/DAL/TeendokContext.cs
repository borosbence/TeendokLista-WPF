using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using TeendokLista.Data.Models;

namespace TeendokLista.Data.DAL
{
    public class TeendokContext : DbContext
    {
        //public TeendokContext() : base()
        //{

        //}
        public TeendokContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Feladat> Feladatok { get; set; }
        public DbSet<Felhasznalo> Felhasznalok { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder
        //        .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
        //        .EnableSensitiveDataLogging()
        //        .EnableDetailedErrors();
        //}
    }
}
