using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<TeendokContext>();
            var connectionString = configuration.GetConnectionString("DatabaseConnection");
            builder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
            return new TeendokContext(builder.Options);
        }
    }
}
