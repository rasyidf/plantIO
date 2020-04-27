using System;
using System.Collections.Generic;

namespace PlantIO.Entities.Taxonomy
{
    public class GroupingTaxonRank
    {
        public int RankHierarchyId { get; set; }
        public TaxonomicMethodologyRankHierarchy RankHierarchy { get; set; } // #review: duplicate RankType.Hierarchy

        public int GroupingTaxonId { get; set; }
        public GroupingTaxon GroupingTaxon { get; set; }

        public int RankTypeId { get; set; }
        public TaxonTypeRank RankType { get; set; }

        public GroupingTaxonRank() { }
        public GroupingTaxonRank(GroupingTaxon taxon, TaxonTypeRank rank)
        {
            GroupingTaxon = taxon;
            RankType = rank;
        }
    }

    [Obsolete("Experimental class for SQL hierarchy / Recursive CTEs")] // this would avoid duplicate row data, but could be less performant
    public class RankedGradeTaxonNode : GroupingTaxonRank
    {
        public Guid ParentId { get; }
        public virtual RankedGradeTaxonNode Parent { get; }

        public virtual ICollection<RankedGradeTaxonNode> Ranks { get; }
    }

}
