using System;
using System.Runtime;
using Microsoft.EntityFrameworkCore;
using PlantIO.Entities.Taxonomy;

namespace PlantIO.Taxonomy.Data.EntityFramework
{
    // #note: there are still some duplicate/redundant fields that may be removed in next versions

    public static class TaxonomyEntityTypeConfigurator
    {
        public static class Constants // todo: maxlengths
        {
            public const int NomenclatureCodeMaxLength = 32;
            public const int NomenclatureCodeVersionMaxLength = 32;
            public const int TaxonTypeMaxLength = 32;
            public const int TaxonValueMaxLength = 64;
        }

        public static void ConfigureTaxonomyKeysAndRelationships<TDbContext>(TDbContext context, ModelBuilder modelBuilder)
            where TDbContext : ITaxonomyDbContext
        {
            #region Methodology
            var taxonomicCodes = modelBuilder.Entity<TaxonomicCode>()
                .ToTable(nameof(TaxonomicCode));
            taxonomicCodes.HasKey(c => new
            {
                c.Identifier,
                c.Version
            });
            taxonomicCodes
                .HasMany(c => c.Methodologies)
                .WithOne(m => m.TaxonomicCode)
                .HasForeignKey(m => new
                {
                    m.TaxonomicCodeIdentifier,
                    m.TaxonomicCodeVersion
                });

            var methodology = modelBuilder.Entity<TaxonomicMethodology>()
                .ToTable("TaxonMethodology");

            methodology.HasKey(m => m.Id);
            methodology
                .HasMany(m => m.TaxonTypes)
                .WithOne(tt => tt.Methodology)
                .HasForeignKey(tt => tt.MethodologyId);
            methodology
                .HasOne(rbm => rbm.RankedHierarchy)
                .WithOne(m => m.Methodology)
                .HasForeignKey<TaxonomicMethodologyRankHierarchy>(rh => rh.Id);

            var methodologyRankHierarchy = modelBuilder.Entity<TaxonomicMethodologyRankHierarchy>()
                .ToTable("TaxonMethodologyHierarchy");

            methodologyRankHierarchy
                .HasMany(rbm => rbm.RankTypes)
                .WithOne(t => t.Hierarchy)
                .HasForeignKey(t => t.HierarchyId);

            #endregion

            #region Taxon
            var taxon = modelBuilder.Entity<Taxon>()
                .ToTable(nameof(Taxon));

            taxon.HasKey(th => th.Id);
            taxon
                .HasOne(t => t.Methodology)
                .WithMany(m => m.Taxons)
                .HasForeignKey(t => t.MethodologyId);
            taxon
                .HasOne(t => t.Type)
                .WithMany(tt => tt.Taxons)
                .HasForeignKey(t => t.TypeId);
            taxon
                .HasMany(t => t.Entries)
                .WithOne(te => te.TargetTaxon)
                .HasForeignKey(t => t.TargetTaxonId);
            taxon
                .HasMany(t => t.Tags)
                .WithOne(tt => tt.Taxon)
                .HasForeignKey(t => t.TaxonId);

            var taxonType = modelBuilder.Entity<TaxonType>()
                .ToTable("TaxonType");

            taxonType.HasKey(tt => tt.Id);
            taxonType
                .HasOne(tt => tt.Methodology)
                .WithMany(m => m.TaxonTypes)
                .HasForeignKey(tt => tt.MethodologyId);

            var taxonTypeRank = modelBuilder.Entity<TaxonTypeRank>();
            taxonTypeRank.HasKey(rtt => rtt.TaxonTypeId);
            taxonTypeRank
                .HasOne(rtt => rtt.TaxonType)
                .WithOne(tt => tt.Rank)
                .HasForeignKey<TaxonTypeRank>(ttr => ttr.TaxonTypeId);

            var taxonEntry = modelBuilder.Entity<TaxonEntry>();
            taxonEntry.HasKey(te => te.TargetTaxonId);
            taxonEntry
                .HasOne(te => te.TargetTaxon)
                .WithMany(t => t.Entries)
                .HasForeignKey(te => te.TargetTaxonId);

            #endregion

            #region Taxon References
            var groupingTaxons = modelBuilder.Entity<GroupingTaxon>()
                .ToTable("Taxon_Grouping");

            groupingTaxons.HasKey(gt => gt.Id);
            groupingTaxons.HasIndex(rt => new
            {
                rt.MethodologyId,
                rt.TaxonTypeId,
                rt.TaxonId,
            })
            .IsUnique(true); //.ForSqlServerIsClustered();

            groupingTaxons
                .HasOne(gt => gt.Methodology)
                .WithMany(m => m.GroupingTaxons)
                .HasForeignKey(gt => gt.MethodologyId);
            groupingTaxons
                .HasOne(gt => gt.Taxon)
                .WithOne(t => t.GroupingTaxon)
                .HasForeignKey<Taxon>(t => t.GroupingTaxonId);
            groupingTaxons
                .HasOne(gt => gt.Rank)
                .WithOne(gt => gt.GroupingTaxon)
                .HasForeignKey<GroupingTaxon>(gt => gt.RankId)
                .OnDelete(DeleteBehavior.SetNull);

            groupingTaxons
                .HasMany(gt => gt.TaxonRelations)
                .WithOne(gtr => gtr.GroupingTaxon)
                .HasForeignKey(gtr => gtr.GroupingTaxonId);

            var groupingTaxonRanks = modelBuilder.Entity<GroupingTaxonRank>();
            groupingTaxonRanks.ToTable("Taxon_Rank");
            groupingTaxonRanks.HasKey(gtr => gtr.GroupingTaxonId);

            var groupingTaxonRelation = modelBuilder.Entity<GroupingTaxonRelation>()
                .ToTable("Taxon_GroupingRelations");

            groupingTaxonRelation
                .HasKey(tr => new
                {
                    tr.MethodologyId,
                    tr.GroupingTaxonId,
                    tr.TaxonTypeId,
                    //tr.TaxonId,
                });
            groupingTaxonRelation
                .HasOne(gt => gt.Methodology)
                .WithMany(m => m.GroupingTaxonRelations)
                .HasForeignKey(gt => gt.MethodologyId);
            groupingTaxonRelation
                .HasOne(gtr => gtr.Taxon)
                .WithMany(t => t.GroupingTaxonRelations)
                .HasForeignKey(t => t.TaxonId);

            //var cladeTaxons = modelBuilder.Entity<CladeTaxon>();
            #endregion

            #region Taxon Entities
            var speciesTaxonEntity = modelBuilder.Entity<SpeciesTaxonEntity>();
            speciesTaxonEntity.HasKey(s => s.Id);
            speciesTaxonEntity
                .HasOne(s => s.Taxon)
                .WithMany()
                .HasForeignKey(s => s.TaxonId);
                
            speciesTaxonEntity
                .HasMany(s => s.GroupingTaxonRelations)
                .WithOne(tg => tg.Species)
                .HasForeignKey(tg => tg.SpeciesId);

            var speciesTaxonGroupRelations = modelBuilder.Entity<SpeciesTaxonGroupRelation>();
            speciesTaxonGroupRelations.HasKey(str => new
            {
                str.MethodologyId,
                str.GroupingTaxonTypeId,
                str.SpeciesId,
                // str.GroupingTaxonId,
            });
            speciesTaxonGroupRelations
                .HasOne(gtr => gtr.Methodology)
                .WithMany()
                .HasForeignKey(t => t.MethodologyId);
            speciesTaxonGroupRelations
                .HasOne(gtr => gtr.GroupingTaxonType)
                .WithMany()
                .HasForeignKey(t => t.GroupingTaxonTypeId);
            speciesTaxonGroupRelations
                .HasOne(sgtr => sgtr.GroupingTaxon)
                .WithMany(gt => gt.SpeciesTaxonRelations)
                .HasForeignKey(sgtr => sgtr.GroupingTaxonId);

            #endregion

            #region Tags
            var taxonomicTags = modelBuilder.Entity<TaxonomicTag>();
            var taxonomicTagValues = modelBuilder.Entity<TaxonomicTagValue>();
            taxonomicTags.HasKey(tt => tt.Id);
            taxonomicTags
                .HasOne(tt => tt.Type)
                .WithMany(tt => tt.Tags)
                .HasForeignKey(tt => tt.TypeId);

            taxonomicTagValues.HasKey(ttv => new
            {
                ttv.TaxonId,
                ttv.TagId
            });
            #endregion
        }

        [Obsolete]
        static void ConfigureCompositePrimaryKeys_Test(ModelBuilder modelBuilder)
        {
            var groupingTaxons = modelBuilder.Entity<GroupingTaxon>();

            groupingTaxons.HasKey(rt => new
            {
                rt.MethodologyId,
                rt.TaxonTypeId,
                rt.TaxonId,
            });

            var groupingTaxonRelation = modelBuilder.Entity<GroupingTaxonRelation>();
            groupingTaxonRelation
                .HasKey(tr => new
                {
                    tr.MethodologyId,
                    tr.TaxonTypeId,
                    tr.GroupingTaxonId,
                    //tr.TaxonId,
                });

            var speciesTaxonGroupRelations = modelBuilder.Entity<SpeciesTaxonGroupRelation>();
            speciesTaxonGroupRelations
                .HasOne(sgtr => sgtr.GroupingTaxon)
                .WithMany(gt => gt.SpeciesTaxonRelations)
                .HasForeignKey(sgtr => new
                {
                    sgtr.MethodologyId,
                    sgtr.GroupingTaxonTypeId,
                    sgtr.GroupingTaxonId
                });
        }
    }
}
