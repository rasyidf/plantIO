using System.Reflection.Metadata.Ecma335;
using System;
using PlantIO.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Entities.Spatial;

namespace PlantIO.Data
{
    public partial class PlantDbContext
    {
        public DbSet<Cultivar> Cultivars { get; set; }

        void ConfigureCoreEntities(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<Cultivar>().ToTable("Cultivars")
                .HasMany(c => c.Characteristics);

            modelBuilder.Entity<CultivarNameIdentifier>().ToTable("CultivarNameIdentifiers")
                .HasKey(nid => new { nid.DataSetId, nid.Id });

        }
    }
}
