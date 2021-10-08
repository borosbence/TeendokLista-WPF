using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeendokLista.Models
{
    public class TeendokContextFactory : IDesignTimeDbContextFactory<TeendokContext>
    {
        public TeendokContext CreateDbContext(string[] args = null)
        {
            //var configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddXmlFile("App.config")
            //    .Build();
            string connectionString = "server=localhost;user id=root;sslmode=None;database=teendoklista";

            var optionsBuilder = new DbContextOptionsBuilder<TeendokContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
            return new TeendokContext(optionsBuilder.Options);
        }
    }
}
