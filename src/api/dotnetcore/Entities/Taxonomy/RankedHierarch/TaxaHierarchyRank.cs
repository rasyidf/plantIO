namespace PlantIO.Entities.Taxonomy
{
    public class TaxaHierarchyRank
    {
        public TaxaHierarchyRank() { }
        public TaxaHierarchyRank(int level, string taxonType, NomenclatureConnectingTermUsage connectingTermUsage = NomenclatureConnectingTermUsage.Unused)
        {
            Level = level;
            TaxonType = taxonType;
            ConnectingTermUsage = connectingTermUsage;
        }
        public int Level { get; set; }

        public TaxaHierarchy Hierarchy { get; set; }
        public int HierarchyId { get; set; }

        public string TaxonType { get; set; }

        public string Value { get; set; }

        public NomenclatureConnectingTermUsage ConnectingTermUsage { get; set; }
    }

    public enum NomenclatureConnectingTermUsage
    {
        Unused = 0,

        /// <summary>
        /// Requires a connecting term in writen name,
        /// e.g.: "subsp." for subspecies
        /// </summary>
        Required = 1,
    }
}