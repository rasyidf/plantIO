using System;
using System.Diagnostics;

namespace PlantIO.Entities.Taxonomy
{
    public class TaxonTypeRank
    {
        const NomenclatureConnectingTermUsage defaultConnectingTermUsage
            = NomenclatureConnectingTermUsage.Unused;

        public virtual int TaxonTypeId { get; set; }
        public virtual TaxonType TaxonType { get; set; }

        #region Indexes
        public int HierarchyId { get; set; }
        public TaxonomicMethodologyRankHierarchy Hierarchy { get; set; }
        
        public byte Level { get; set; }
        public TaxonRankSubLevel SubLevel { get; set; }
        #endregion

        public bool IsActive { get; set; }

        public NomenclatureConnectingTermUsage ConnectingTermUsage { get; set; }

        public TaxonTypeRank() { }
        public TaxonTypeRank(byte level, TaxonType taxonType, NomenclatureConnectingTermUsage connectingTermUsage = defaultConnectingTermUsage)
        {
            Level = level;
            TaxonType = taxonType;
            ConnectingTermUsage = connectingTermUsage;
        }
    }

    public enum TaxonRankSubLevel : sbyte
    {
        Parvorder = -3,
        Infra = -2,
        Sub = -1,
        Standard = 0,
        Magn = 1,
        Super = 2,
        Grand = 3,
        Mir = 4,
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