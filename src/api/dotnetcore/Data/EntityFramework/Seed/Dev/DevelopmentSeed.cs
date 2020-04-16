using System;
using System.Linq;
using System.Collections.Generic;
using PlantIO.Entities.Cultivar;
using PlantIO.Entities.Taxonomy;

// #review: seed and model for preview purposes
// #review: #TECHDEBT: use json DTOs for seed 🏖
// #review: migrate to HasData()

namespace PlantIO.Data.Seed
{
    public static class DevelopmentSeed
    {
        const string LB = TaxaHierarchySeedExtensions.MultilineItemSeparator;

        public static void Test(CultivarDbContext db)
        {
            var dataset1 = Guid.NewGuid();

            var internationalNomenclatureCode = Entities.Botanics.ICNCP.V90
                .CultivatedPlantsInternationalNomenclature.NomenclatureCode;

            var internationalNomenclatureCodeTaxaHierarchy = new TaxaHierarchy()
            {
                Ranks = internationalNomenclatureCode.Ranks
            };
            db.TaxaHierarchies.Add(internationalNomenclatureCodeTaxaHierarchy);
            db.SaveChanges();

            // hello mandioca
            var mandiocaId = Guid.NewGuid();
            var mandioca = new Cultivar() { ScientificName = "Manihot esculenta" };

            mandioca.Identifiers.Add(new CultivarIdentifier
            {
                DataSetId = dataset1,
                CultivarId = mandiocaId,
                TaxonomicCode = internationalNomenclatureCode.TaxonomicCode,
                TaxonomicCodeVersion = internationalNomenclatureCode.TaxonomicCodeVersion,
                TaxaHierarchyId = internationalNomenclatureCodeTaxaHierarchy.Id,
                TaxaHierarchyTaxonValues = new List<TaxaHierarchyTaxonValue>()
                    .AddMultilineCSV(
                        "species,M. esculenta" + LB +
                        "genus,Manihot" + LB +
                        "familia,Euphorbiaceae" + LB +
                        "clade,Tracheophytes" + LB +
                        "clade,Angiosperms" + LB +
                        "clade,Eudicots" + LB +
                        "clade,Rosids" + LB +
                        "ordo,Malpighiales"
                    )
            });

            mandioca.Identifiers.Add(new CultivarIdentifier
            {
                DataSetId = dataset1,
                CultivarId = mandiocaId,
                TaxonomicCode = "custom",
                TaxonomicCodeVersion = null,
                TaxaHierarchyId = null,
                TaxaHierarchyTaxonValues = new List<TaxaHierarchyTaxonValue>()
                    .AddOneLinedCSV("grupo,a;grupo,b")
            });
        }
    }

    public static class TaxaHierarchySeedExtensions
    {
        public const char ValueSeparator = ',';
        public const string OneLinedItemSeparator = ";";
        public const string MultilineItemSeparator = "\n";

        /// <summary>
        /// Parse itens using dot-comma as item separator and comma as field separator.
        /// </summary>
        /// <param name="csv">"rankName1,rankValue1;rankName2,rankValue3"</param>
        public static List<TaxaHierarchyTaxonValue> AddOneLinedCSV(
            this List<TaxaHierarchyTaxonValue> entries, string csv)
            => AddCSV(entries, csv, ValueSeparator, OneLinedItemSeparator);

        /// <summary>
        /// Parse itens using <see cref="MultilineItemSeparator"> as item separator and comma as field separator.
        /// </summary>
        /// <param name="csv">Multi-line Comma-Separated Values (CSV) file content</param>
        public static List<TaxaHierarchyTaxonValue> AddMultilineCSV(
            this List<TaxaHierarchyTaxonValue> entries, string csv)
            => AddCSV(entries, csv, ValueSeparator, MultilineItemSeparator);

        /// <param name="csv">[0]rankName,[1]rankValue</param>
        private static List<TaxaHierarchyTaxonValue> AddCSV(
            this List<TaxaHierarchyTaxonValue> entries,
            string csv, char valueSeparator, string itemSeparator)
        {
            if (string.IsNullOrWhiteSpace(csv))
                return entries;

            string[] csvItems = csv.Split(itemSeparator);
            entries.AddRange(csvItems.Select(csvLine =>
            {
                string[] itemValues = csvLine.Split(valueSeparator);

                return new TaxaHierarchyTaxonValue
                {
                    TaxonType = itemValues[0],
                    Value = itemValues[1],
                };
            }));
            return entries;
        }
    }
}