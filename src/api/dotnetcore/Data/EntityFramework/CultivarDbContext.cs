using System.Security.Cryptography;
using System;
using PlantIO.Entities;
using Microsoft.EntityFrameworkCore;
using PlantIO.Botany;
using PlantIO.Taxonomy.Data.EntityFramework;
using PlantIO.Entities.Taxonomy;
using PlantIO.Botany.Data.EntityFramework;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace PlantIO.Data
{
    public partial class CultivarDbContext : DbContext,
        ITaxonomyDbContext, IBotanyDbContext
    {
        ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter("Microsoft", LogLevel.Warning)
                   .AddFilter("System", LogLevel.Warning)
                   .AddFilter("PlantIO", LogLevel.Debug)
                   .AddConsole();
        }
);

        #region Taxonomy
        public DbSet<TaxonomicMethodology> TaxonomicMethodologies { get; set; }
        public DbSet<TaxonomicMethodologyRankHierarchy> RankBasedTaxonomicMethodologies { get; set; }

        public DbSet<TaxonEntry> TaxonEntries { get; set; }

        public DbSet<SpeciesTaxonEntity> SpeciesTaxonEntities { get; set; }
        public DbSet<SpeciesTaxonGroupRelation> SpeciesTaxonGroupRelations { get; set; }

        #endregion

        #region Botany
        public DbSet<BotanicTaxonLifeCycle> BotanicLifeCycles { get; set; }
        #endregion

        #region Cultivar
        //public DbSet<Cultivar> Cultivars { get; set; }
        #endregion

        public CultivarDbContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory);
            // #todo: review: configure change-tracking and do NOT use lazy loading
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseClrTypeNameAsTableNames();
            TaxonomyEntityTypeConfigurator.ConfigureTaxonomyKeysAndRelationships(this, modelBuilder);
            BotanyEntityTypeConfigurator.ConfigureBotany(this, modelBuilder);
            CultivarEntityTypeConfigurator.ConfigureCoreEntities(this, modelBuilder);
            base.OnModelCreating(modelBuilder);
        }


    }

    // refactor: move
    public static class ModelBuilderExtensions
    {
        /// <remarks>source: https://stackoverflow.com/questions/46497733/using-singular-table-names-with-ef-core-2</remarks>
        public static void UseClrTypeNameAsTableNames(this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Use the entity name instead of the Context.DbSet<T> name
                // refs https://docs.microsoft.com/en-us/ef/core/modeling/relational/tables#conventions
                modelBuilder.Entity(entityType.ClrType).ToTable(entityType.ClrType.Name);
            }
        }
    }
}
