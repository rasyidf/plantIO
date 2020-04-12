using System;
using PlantIO.Entities;
using Microsoft.EntityFrameworkCore;

namespace PlantIO.Data
{
    public partial class PlantDbContext : DbContext
    {
        public PlantDbContext(DbContextOptions options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureCoreEntities(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
