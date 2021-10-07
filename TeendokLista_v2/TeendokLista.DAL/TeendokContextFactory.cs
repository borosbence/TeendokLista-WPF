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

namespace TeendokLista.DAL
{
    public class TeendokContextFactory : IDesignTimeDbContextFactory<TeendokContext>
    {
        public TeendokContext CreateDbContext(string[] args = null)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string connectionString = configuration.GetConnectionString("TeendokDB");
            var optionsBuilder = new DbContextOptionsBuilder<TeendokContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
            return new TeendokContext(optionsBuilder.Options);
        }
    }
}
