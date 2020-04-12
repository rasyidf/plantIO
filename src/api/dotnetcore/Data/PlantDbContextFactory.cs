using System.IO;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PlantIO.Data
{
    public class PlantDbContextFactory : IDesignTimeDbContextFactory<PlantDbContext>
    {
        public PlantDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<PlantDbContext>();
            var connectionString = configuration.GetConnectionString("Default");

            builder.UseSqlite(new SqliteConnection(connectionString));

            return new PlantDbContext(builder.Options);
        }
    }

}