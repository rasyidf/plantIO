using PlantIO.Entities.Taxonomy;

namespace PlantIO.Entities.Botanics.ICNCP.V90
{
    /// <summary>
    /// International Code of Nomenclature for Cultivated Plants (ICNCP).
    /// <see cref="https://www.ishs.org/scripta-horticulturae/international-code-nomenclature-cultivated-plants-ninth-edition" />
    /// </summary>
    public static class CultivatedPlantsInternationalNomenclature
    {
        public static TaxaHierarchyNomenclatureCode NomenclatureCode { get; }

        public static readonly TaxaHierarchyRank Life;
        public static readonly TaxaHierarchyRank Domain;
        public static readonly TaxaHierarchyRank Kingdom;
        public static readonly TaxaHierarchyRank Phylum;
        public static readonly TaxaHierarchyRank Class;
        public static readonly TaxaHierarchyRank Order;
        public static readonly TaxaHierarchyRank Family;
        public static readonly TaxaHierarchyRank Genus;
        /// <summary>
        /// A group of organisms that can interbreed and produce fertile offspring (botanic).
        /// </summary>
        public static readonly TaxaHierarchyRank Species;
        public static readonly TaxaHierarchyRank SubSpecies; // TODO: check if stays here

        static CultivatedPlantsInternationalNomenclature()
        {
            NomenclatureCode = new TaxaHierarchyNomenclatureCode("ICNCP", "2009/10",
                Life = new TaxaHierarchyRank(1, "vitae"),
                Domain = new TaxaHierarchyRank(2, "regio"),
                Kingdom = new TaxaHierarchyRank(3, "regnum"),
                Phylum = new TaxaHierarchyRank(4, "phylum"),
                Class = new TaxaHierarchyRank(5, "classis"),
                Order = new TaxaHierarchyRank(6, "ordo"),
                Family = new TaxaHierarchyRank(7, "familia"),
                Genus = new TaxaHierarchyRank(8, "genus"),
                Species = new TaxaHierarchyRank(9, "species"),
                SubSpecies = new TaxaHierarchyRank(10, "subspecies", NomenclatureConnectingTermUsage.Required)
            );
        }
    }
}