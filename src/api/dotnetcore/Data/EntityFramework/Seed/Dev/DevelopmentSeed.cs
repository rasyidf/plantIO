using System;
using System.Linq;
using System.Collections.Generic;
using PlantIO.Entities.Cultivar;
using PlantIO.Entities.Taxonomy;
using PlantIO.Entities.Taxonomy.InternationalNomenclatureCodes.V9_0;

/// <summary>
/// International Code of Nomenclature for Cultivated Plants
/// </summary>
using ICNCP = PlantIO.Entities.Taxonomy.InternationalNomenclatureCodes.V9_0.CultivatedPlantslNomenclatureCode;
using System.Data.Entity;
// seed and model for preview purposes
// #todo: use json DTOs for seed 🏖
// #issue: use HasData()?

namespace PlantIO.Data.Seed
{
    public static class DevelopmentSeed
    {
        //const string LB = TaxaHierarchySeedExtensions.MultilineItemSeparator;

        public static void Test(CultivarDbContext db)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var dataset1 = Guid.NewGuid();

            var methodology = GetOrCreateMethodology("international", 1, db, out bool hasMethodologySeed, m =>
            {
                m.RankedHierarchy = new TaxonomicMethodologyRankHierarchy()
                {
                    RankTypes = ICNCP.Instance.GroupingTaxonTypes
                        .Where(r => r.Rank != null)
                        .Select(r => r.Rank).ToList(),
                };
            });

            var defaultMethodology = GetOrCreateMethodology("default", 1, db, out hasMethodologySeed, m =>
            {
                m.TaxonTypes = new List<TaxonType>
                {
                    new TaxonType
                    {
                        LatinName = "species",
                        Methodology = m
                    }
                };
            });
            db.SaveChanges();

            var euphorbiaceaeFamily = GroupingTaxon.Ranked("Euphorbiaceae", ICNCP.Family.Rank);

            db.SaveChanges();

            var spermatophyta = GroupingTaxon.Ranked("Spermatophyta", ICNCP.Family.Rank);
            var gymnosperms = GroupingTaxon.Ranked("Gymnosperms", ICNCP.Family.Rank);

            var manihotGenus = GroupingTaxon.Ranked("Manihot", ICNCP.Genus.Rank);
            manihotGenus.SetTaxons(methodology,
                euphorbiaceaeFamily.Taxon
            );

            db.SaveChanges();

            var manihotEsculentaSpecies = new SpeciesTaxonEntity(
                "Manihot esculenta", defaultMethodology.TaxonTypes.First(t => t.LatinName == "species")
            );
            db.SpeciesTaxonEntities.Add(manihotEsculentaSpecies);
            db.SaveChanges();
            manihotEsculentaSpecies.GroupingTaxonRelations = new List<SpeciesTaxonGroupRelation>
            {
                new SpeciesTaxonGroupRelation(manihotEsculentaSpecies, manihotGenus)
            };
            db.SaveChanges();

            // db.SpeciesTaxonGroups.Add(new SpeciesTaxonGroupRelation(
            //     manihotEsculentaSpecies, manihotGenus
            // ));

            var mandiocaCultivar = new Cultivar();
            // #todo:refactor:
            // mandiocaCultivar.Identifiers.Add(new CultivarIdentifier
            // {
            //     DataSetId = dataset1,
            //     CultivarId = mandiocaCultivar.Id,
            //     NomenclatureCode = internationalNomenclatureCode,
            //     SpeciesTaxonomy = manihotEsculentaSpecies,
            // });

            // mandiocaCultivar.Identifiers.Add(new CultivarIdentifier
            // {
            //     DataSetId = dataset1,
            //     CultivarId = mandiocaCultivar.Id,
            //     NomenclatureCode = internationalNomenclatureCode,
            //     SpeciesTaxonomy = manihotEsculentaSpecies,
            //     CultivarTaxonomy = new CultivarTaxonomicHierarchy()
            //     {
            //         Id = Guid.NewGuid(),
            //         //BinomialName = "Manihot esculenta",
            //         TaxaHierarchy = internationalNomenclatureCodeTaxaHierarchy,
            //         TaxonRanks = new List<TaxonEntry>()
            //             .AddFromOneLinedCSV("grupo,a;grupo,b")
            //     }
            // });
            db.SaveChanges();
        }


        static TaxonomicMethodology GetOrCreateMethodology(string identifier, int version, CultivarDbContext db, out bool existing, Action<TaxonomicMethodology> initializer = null) // refactor this method
        {
            var methodology = db.TaxonomicMethodologies
                .Include(m => m.RankedHierarchy)
                .Include(m => m.TaxonTypes)
                .FirstOrDefault(m
                    => m.Identifier == identifier && m.Version == version
                );

            if (methodology != null)
            {
                existing = true;
                return methodology;
            }

            methodology = new TaxonomicMethodology()
            {
                Identifier = identifier,
                Version = version
            };

            initializer?.Invoke(methodology);
            db.TaxonomicMethodologies.Add(methodology);

            existing = false;
            return methodology;
        }
    }

    // public static class TaxaHierarchySeedExtensions
    // {
    //     public const char ValueSeparator = ',';
    //     public const string OneLinedItemSeparator = ";";
    //     public const string MultilineItemSeparator = "\n";
    //     static SpeciesTaxonGroupEntry ParseSpeciesTaxonEntry(string[] items)
    //     {
    //         return new SpeciesTaxonGroupEntry
    //         {

    //         }
    //     }

    //     /// <summary>
    //     /// Parse itens using dot-comma as item separator and comma as field separator.
    //     /// </summary>
    //     /// <param name="csv">"rankName1,rankValue1;rankName2,rankValue3"</param>
    //     public static SpeciesTaxonGroupEntry[] AddFromOneLinedCSV(
    //         this List<TaxonEntry> entries, string csv)
    //         => AddFromCSV(entries, csv, ValueSeparator, OneLinedItemSeparator);

    //     /// <summary>
    //     /// Parse itens using <see cref="MultilineItemSeparator"> as item separator and comma as field separator.
    //     /// </summary>
    //     /// <param name="csv">Multi-line Comma-Separated Values (CSV) file content</param>
    //     public static SpeciesTaxonGroupEntry[] AddFromMultilineCSV(
    //         this List<TaxonEntry> entries, string multilineItemSeparator, char valueSeparator, string csv)
    //         => AddFromCSV(entries, csv, valueSeparator, multilineItemSeparator);

    //     public static SpeciesTaxonGroupEntry[] AddFromCSV(
    //         this List<TaxonEntry> entries, string multilineItemSeparator, char valueSeparator, string csv)
    //     {
    //         var parsedItems = CsvUtils.Parse(entries, csv, valueSeparator, multilineItemSeparator);
    //             item => new );
    //     }


    //     /// <param name="csv">[0]rankName,[1]rankValue</param>
    // }

    public static class CsvUtils
    {
        public static T[] Parse<T>(string csv,
            char valueSeparator, string itemSeparator,
            Func<string[], T> itemParser)
        {
            if (string.IsNullOrWhiteSpace(csv))
                return Array.Empty<T>();

            string[] csvItems = csv.Split(itemSeparator);
            T[] parsedItems = new T[csvItems.Length];
            for (int i = 0; i < csvItems.Length; i++)
            {
                string[] itemValues = csvItems[i].Split(valueSeparator);
                parsedItems[i] = itemParser(itemValues);
            }
            return parsedItems;
        }
    }
}