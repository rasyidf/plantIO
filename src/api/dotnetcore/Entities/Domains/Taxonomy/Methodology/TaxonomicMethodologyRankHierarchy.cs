using System;
using System.Collections.Generic;
using System.Linq;

namespace PlantIO.Entities.Taxonomy
{
    /// <summary>
    /// Describes a code of nomenclature, like:
    /// International Code of Nomenclature for Cultivated Plants (ICNCP);
    /// International Code of Zoological Nomenclature (ICZN);
    /// Note: This class does not implement PhyloCode, but can be used for complementary information.
    /// </summary>
    public class TaxonomicMethodologyRankHierarchy
    {
        public int Id { get; set; }
        public TaxonomicMethodology Methodology { get; set; }

        public virtual ICollection<TaxonTypeRank> RankTypes { get; set; }
        public virtual ICollection<GroupingTaxonRank> Ranks { get; set; }

        public TaxonomicMethodologyRankHierarchy() { }
        public TaxonomicMethodologyRankHierarchy(TaxonomicMethodology methodology, params TaxonTypeRank[] ranks)
        {
            Methodology = methodology;
            RankTypes = ranks;
        }
        public TaxonomicMethodologyRankHierarchy(TaxonomicMethodology methodology, ICollection<TaxonTypeRank> ranks)
        {
            Methodology = methodology;
            RankTypes = ranks;
        }
    }
}