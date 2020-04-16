using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System;
using PlantIO.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Entities.Spatial;
using PlantIO.Entities.Cultivar;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlantIO.Entities.Taxonomy;

// #review: natural keys
// #review: max lengths

namespace PlantIO.Data
{
    public partial class CultivarDbContext // core partial class with dbsets
    {
        protected internal static class CoreConstants
        {
            public static class Taxonomy
            {
                public const int NomenclatureCodeMaxLength = 32;
                public const int NomenclatureCodeVersionMaxLength = 32;
                public const int TaxonTypeMaxLength = 32;
                public const int TaxonValueMaxLength = 64;
            }
        }

        #region Core DbSets
        public DbSet<Cultivar> Cultivars { get; set; }

        public DbSet<TaxaHierarchy> TaxaHierarchies { get; set; }

        #endregion

        public void ConfigureCoreEntities(ModelBuilder modelBuilder)
        {
            var taxaHierarchies = modelBuilder.Entity<TaxaHierarchy>();
            var taxaHierarchyRanks = modelBuilder.Entity<TaxaHierarchyRank>();
            var taxaHierarchyTaxonValues = modelBuilder.Entity<TaxaHierarchyTaxonValue>();
            ConfigureTaxonomy();
            void ConfigureTaxonomy()
            {
                taxaHierarchies
                    .HasKey(th => th.Id);

                // taxonHierarchies.HasIndex(th => th.HierarchyKey).IsUnique(false); // #review:

                taxaHierarchies
                    .HasMany(th => th.Ranks)
                    .WithOne(thr => thr.Hierarchy);
                taxaHierarchyRanks
                    .HasKey(thr => new
                    {
                        thr.HierarchyId,
                        thr.TaxonType,
                    });

                taxaHierarchyTaxonValues
                    .HasOne(thtv => thtv.Hierarchy)
                    .WithMany()
                    .HasForeignKey(thtv => thtv.HierarchyId);
                taxaHierarchyTaxonValues
                    .HasTaxonType()
                    .HasKey(cctre => new
                    {
                        cctre.HierarchyId,
                        cctre.TaxonType
                    });
            }

            var cultivar = modelBuilder.Entity<Cultivar>();
            var cultivarPopularName = modelBuilder.Entity<CultivarPopularName>();
            ConfigureCultivar();
            void ConfigureCultivar()
            {
                var cultivarIdentifiers = modelBuilder.Entity<CultivarIdentifier>();

                cultivar
                    .HasMany(c => c.Identifiers)
                    .WithOne(cid => cid.Cultivar)
                    .HasForeignKey(cid => cid.CultivarId);
                cultivarIdentifiers
                    .HasKey(cid => new // #review: this key / test with int or guid key and separate clustered index
                    {
                        cid.DataSetId,
                        cid.CultivarId,
                        cid.TaxonomicCode,
                        cid.TaxonomicCodeVersion,
                    });
                cultivarIdentifiers
                    .HasOne(cid => cid.TaxaHierarchy)
                    .WithMany()
                    .HasForeignKey(cid => cid.TaxaHierarchyId);

                cultivarIdentifiers
                    .HasKey(ccr => new
                    {
                        ccr.DataSetId,
                        ccr.CultivarId,
                        ccr.TaxonomicCode,
                        ccr.TaxonomicCodeVersion,
                        ccr.TaxaHierarchyId,
                    });

                cultivarIdentifiers
                    .Property(ccr => ccr.TaxonomicCode)
                    .HasMaxLength(CoreConstants.Taxonomy.NomenclatureCodeMaxLength);
                cultivarIdentifiers
                    .Property(ccr => ccr.TaxonomicCodeVersion)
                    .HasMaxLength(CoreConstants.Taxonomy.NomenclatureCodeVersionMaxLength);

                // review: may be better to create individual indexes since **all key values** will propably not be used together on most queries
                // cultivarPopularName.HasIndex(c => new { c.CultivarId, c.Name }).ForSqlServerIsClustered(false).IsUnique(false);
                cultivarPopularName
                    .HasKey(cpn => new
                    {
                        cpn.DataSetId,
                        cpn.LanguageCultureName,
                        cpn.CultivarId,
                        cpn.RegionId,
                    });
            }
        }


    }

    public static class ITaxonEntityTypeBuilderExtensions
    {
        public static EntityTypeBuilder<TTaxon> HasTaxonType<TTaxon>(this EntityTypeBuilder<TTaxon> builder)
            where TTaxon : class, ITaxon
        {
            builder
                .Property(t => t.TaxonType)
                .HasMaxLength(CultivarDbContext.CoreConstants.Taxonomy.TaxonTypeMaxLength);
            return builder;
        }
    }
}

// ⚠ disclaimer: partial class is experimental, nested methods are meant to be hidden
// those methods can be splitted apart in the future, but at last for now, it would make the overall modeling less comprehensive