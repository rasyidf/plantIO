using System.Security.Cryptography;
using System;
using PlantIO.Entities;
using Microsoft.EntityFrameworkCore;

namespace PlantIO.Data
{
    public partial class CultivarDbContext : DbContext
    {
        public CultivarDbContext(DbContextOptions options)
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
