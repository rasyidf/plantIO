using System.Collections.ObjectModel;
using System.Collections.Generic;
using PlantIO.Entities.Taxonomy;
using PlantIO.Utils;

namespace PlantIO.Entities.Taxonomy.InternationalNomenclatureCodes.V9_0
{
    // this class is for reference and tests, can be marked as obsolete in future versions

    /// <summary>
    /// International Code of Nomenclature for Cultivated Plants (ICNCP).
    /// <see cref="https://www.ishs.org/scripta-horticulturae/international-code-nomenclature-cultivated-plants-ninth-edition" />
    /// </summary>
    public sealed class CultivatedPlantslNomenclatureCode : TaxonomicCode
    {
        public static CultivatedPlantslNomenclatureCode Instance { get; }
        public static readonly TaxonType Life;
        public static readonly TaxonType Domain;
        public static readonly TaxonType Kingdom;
        public static readonly TaxonType Phylum;
        public static readonly TaxonType Class;
        public static readonly TaxonType Order;
        public static readonly TaxonType Family;
        public static readonly TaxonType Genus;
        /// <summary>
        /// A group of organisms that can interbreed and produce fertile offspring (botanic).
        /// </summary>
        public static readonly TaxonType Species;
        public static readonly TaxonType SubSpecies;

        public ReadOnlyCollection<TaxonType> GroupingTaxonTypes { get; set; }

        private CultivatedPlantslNomenclatureCode() { }
        static CultivatedPlantslNomenclatureCode()
        {
            var methodology = new TaxonomicMethodology();
            var rankHierarchy = new TaxonomicMethodologyRankHierarchy
            {
                Methodology = methodology
            };
            var code = new CultivatedPlantslNomenclatureCode()
            {
                Identifier = "ICNCP",
                Version = "2009/10",
                Methodologies = new List<TaxonomicMethodology> { methodology },
                GroupingTaxonTypes = ReadOnlyCollectionFactory.FromArray(
                    Life = TaxonType.Ranked(1, "vitae", rankHierarchy),
                    Domain = TaxonType.Ranked(2, "regio", rankHierarchy),
                    Kingdom = TaxonType.Ranked(3, "regnum", rankHierarchy),
                    Phylum = TaxonType.Ranked(4, "phylum", rankHierarchy),
                    Class = TaxonType.Ranked(5, "classis", rankHierarchy),
                    Order = TaxonType.Ranked(6, "ordo", rankHierarchy),
                    Family = TaxonType.Ranked(7, "familia", rankHierarchy),
                    Genus = TaxonType.Ranked(8, "genus", rankHierarchy),
                    Species = TaxonType.Ranked(9, "species", rankHierarchy),
                    SubSpecies = TaxonType.Ranked(10, "subspecies", rankHierarchy) // , NomenclatureConnectingTermUsage.Required
                )
            };

            Instance = code;
        }
    }
}

namespace PlantIO.Utils
{
    public static class ReadOnlyCollectionFactory
    {
        public static ReadOnlyCollection<T> FromArray<T>(params T[] items)
        {
            var list = new List<T>(items.Length);
            list.AddRange(items);
            return new ReadOnlyCollection<T>(list);
        }
    }
}