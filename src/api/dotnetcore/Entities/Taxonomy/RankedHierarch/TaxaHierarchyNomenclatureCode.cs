namespace PlantIO.Entities.Taxonomy
{
    /// <summary>
    /// Describes a code of nomenclature, like:
    /// International Code of Nomenclature for Cultivated Plants (ICNCP);
    /// International Code of Zoological Nomenclature (ICZN) 
    /// </summary>
    public class TaxaHierarchyNomenclatureCode : IAmDefinedByAVersionedTaxonomyCode
    {
        public string TaxonomicCode { get; set; }
        public string TaxonomicCodeVersion { get; set; }

        public TaxaHierarchyRank[] Ranks { get; }

        public TaxaHierarchyNomenclatureCode(){ }
        public TaxaHierarchyNomenclatureCode(string identifier, string version, params TaxaHierarchyRank[] ranks)
        { 
            TaxonomicCode = identifier;
            TaxonomicCodeVersion = version;
            Ranks = ranks;
        }
    }
}