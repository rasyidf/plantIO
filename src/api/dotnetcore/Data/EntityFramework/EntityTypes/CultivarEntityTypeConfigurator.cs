using System.Runtime.InteropServices;
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
using System.Linq.Expressions;
using System.Collections.Generic;

namespace PlantIO.Data
{
    static class CultivarEntityTypeConfigurator
    {
        public static void ConfigureCoreEntities(CultivarDbContext context, ModelBuilder modelBuilder)
        {
            // var cultivar = modelBuilder.Entity<Cultivar>();
            // var cultivarPopularName = modelBuilder.Entity<CultivarPopularName>();
            // ConfigureCultivar();
            // void ConfigureCultivar()
            // {
            //     var cultivarIdentifiers = modelBuilder.Entity<CultivarIdentifier>();

            //     cultivar
            //         .HasMany(c => c.Identifiers)
            //         .WithOne(cid => cid.Cultivar)
            //         .HasForeignKey(cid => cid.CultivarId);
            //     cultivarIdentifiers
            //         .HasKey(cid => new // #review: this key / test with int or guid key and separate clustered index
            //         {
            //             cid.DataSetId,
            //             cid.CultivarId,
            //             cid.CodeIdentifier,
            //             cid.CodeVersion,
            //         });
            //     cultivarIdentifiers
            //         .HasOne(cid => cid.SpeciesTaxonomy)
            //         .WithMany()
            //         .HasForeignKey(cid => cid.SpeciesTaxonomyId);
            //     cultivarIdentifiers
            //         .HasOne(cid => cid.CultivarTaxonomy)
            //         .WithMany()
            //         .HasForeignKey(cid => cid.CultivarTaxonomyId);

            //     cultivarIdentifiers
            //         .HasKey(ccr => new
            //         {
            //             ccr.DataSetId,
            //             ccr.CultivarId,
            //             ccr.CodeIdentifier,
            //             ccr.CodeVersion,
            //             ccr.SpeciesTaxonomyId,
            //         });

            //     cultivarIdentifiers
            //         .Property(ccr => ccr.CodeIdentifier)
            //         .HasMaxLength(CoreConstants.Taxonomy.NomenclatureCodeMaxLength);
            //     cultivarIdentifiers
            //         .Property(ccr => ccr.CodeVersion)
            //         .HasMaxLength(CoreConstants.Taxonomy.NomenclatureCodeVersionMaxLength);

            //     // review: may be better to create individual indexes since **all key values** will propably not be used together on most queries
            //     // cultivarPopularName.HasIndex(c => new { c.CultivarId, c.Name }).ForSqlServerIsClustered(false).IsUnique(false);
            //     cultivarPopularName
            //         .HasKey(cpn => new
            //         {
            //             cpn.DataSetId,
            //             cpn.LanguageCultureName,
            //             cpn.CultivarId,
            //             cpn.RegionId,
            //         });
        }
    }


}

// public static class ITaxonEntityTypeBuilderExtensions
// {
//     /// <summary>
//     /// Correlates a <c>Taxon</c> to a <c>TaxaHierarchy</c>
//     /// </summary>
//     /// <param name="taxonWithManyTTaxonExpression"></param>
//     public static EntityTypeBuilder<TTaxonReference> IsTaxaHierarchyTaxonReference<TTaxonReference>(this EntityTypeBuilder<TTaxonReference> builder,
//         Expression<Func<TaxonType, IEnumerable<TTaxonReference>>> taxonWithManyTTaxonReferenceExpression = null)
//         where TTaxonReference : class, ITaxaHierarchyTaxonReference
//     {
//         builder
//             .HasKey(tr => new
//             {
//                 tr.RankedTaxonId,
//                 tr.TaxonTypeId,
//             });
//         builder
//             .HasOne(t => t.TaxonType)
//             .WithMany(taxonWithManyTTaxonReferenceExpression)
//             .HasForeignKey(t => t.TaxonTypeId);
//         return builder;
//     }

// }
