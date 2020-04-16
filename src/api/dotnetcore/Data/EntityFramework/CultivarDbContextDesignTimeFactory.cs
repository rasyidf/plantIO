using System.IO;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PlantIO.Data
{
    public class CultivarDbContextDesignTimeFactory : IDesignTimeDbContextFactory<CultivarDbContext>
    {
        public CultivarDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<CultivarDbContext>();
            var connectionString = configuration.GetConnectionString("Default");

            builder.UseSqlite(new SqliteConnection(connectionString));

            return new CultivarDbContext(builder.Options);
        }
    }

}