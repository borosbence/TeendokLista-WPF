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

namespace TeendokLista.Data.DAL
{
    public class TeendokContextFactory : IDesignTimeDbContextFactory<TeendokContext>
    {
        public TeendokContext CreateDbContext(string[] args = null)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                // using Microsoft.Extensions.Configuration.FileExtensions
                // using Microsoft.Extensions.Configuration.Json
                //.SetBasePath(Directory.GetCurrentDirectory()).
                //.AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<TeendokContext>();
            var connectionString = ConfigurationManager.ConnectionStrings["TeendokDB"].ConnectionString;
            builder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
            return new TeendokContext(builder.Options);
        }
    }
}
