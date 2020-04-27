using System.Diagnostics;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace PlantIO.Entities.Taxonomy
{
    /// <summary>
    /// A ranked polyphiletic/paraphyletic taxonomic grouping of beings.
    /// The lineage values are stored at <see cref="GroupingTaxonRelation" />
    /// </summary>
    public class GroupingTaxon : TaxonEntity // review:name: ClassificationTaxon
    {
        #region Primary Key
        public int MethodologyId { get; set; }
        public TaxonomicMethodology Methodology { get; set; }

        public int TaxonTypeId { get; set; } // #review: this fields is in Taxon
        public TaxonType TaxonType { get; set; }
        #endregion

        public int? RankId { get; set; }
        public GroupingTaxonRank Rank { get; set; }

        public TaxaPhilosophy TaxaPhilosophy { get; set; } // #review: this fields is in Taxon

        public virtual ICollection<GroupingTaxonRelation> TaxonRelations { get; set; }
        public virtual ICollection<SpeciesTaxonGroupRelation> SpeciesTaxonRelations { get; set; }

        #region Constructors
        public GroupingTaxon() { }
        public GroupingTaxon(Taxon taxon, TaxonType taxonType)
            : base(taxon)
        {
            TaxonType = taxonType;
        }
        public GroupingTaxon(Taxon taxon)
            : this(taxon, taxon.Type) { }

        public GroupingTaxon(string identifier, TaxonType taxonType)
            : this(new Taxon(identifier, taxonType)) { }
        /// <summary>
        /// Primary key constructor
        /// </summary>
        public GroupingTaxon(int taxonId, int taxonTypeId, int methodologyId)
        {
            TaxonId = taxonId;
            TaxonTypeId = taxonTypeId;
            MethodologyId = methodologyId;
        }
        public static GroupingTaxon Ranked(string identifier, TaxonTypeRank rankType)
        {   // refactor: null checks
            var taxon = new Taxon(identifier, rankType.TaxonType);

            var groupingTaxon = new GroupingTaxon(taxon, rankType.TaxonType)
            {
                Methodology = rankType.Hierarchy.Methodology
            };
            groupingTaxon.Rank = new GroupingTaxonRank
            {
                GroupingTaxon = groupingTaxon,
                RankHierarchy = rankType.TaxonType.Rank.Hierarchy,
                RankType = rankType
            };
            return groupingTaxon;
        }
        #endregion
    }
    public static class GroupingTaxonExtensions
    {
        public static void SetTaxons(this GroupingTaxon groupingTaxon, TaxonomicMethodology methodology, params Taxon[] taxons)
        {
            Taxon taxon;
            var taxonList = new List<GroupingTaxonRelation>(taxons.Length);
            for (var i = 0; i < taxons.Length; i++)
            {
                taxon = taxons[i];
                taxonList.Add(new GroupingTaxonRelation
                {
                    Methodology = methodology,
                    GroupingTaxon = groupingTaxon,
                    Taxon = taxon,
                    TaxonType = taxon.Type,
                });
            }
            groupingTaxon.TaxonRelations = taxonList;
        }
    }

    /// <summary>
    /// This is an actual entry for a Taxon.
    /// Holds a taxon value for a taxon rank according to a <see cref="TaxonTypeRank"/>.
    /// e.g.: for Taxon (species: homo sapiens) there could be two entries (tribe:homonini), (family:mammalia)
    /// </summary>
    public class GroupingTaxonRelation : ITaxonomicAssociation<GroupingTaxon, Taxon>
    {
        #region Key // some fields are duplicate from Taxon in order to create a cluster
        public int MethodologyId { get; set; }
        public TaxonomicMethodology Methodology { get; set; }

        public int GroupingTaxonId { get; set; }
        public virtual GroupingTaxon GroupingTaxon { get; set; }

        /// <summary>
        /// The grouped Taxon Type ID
        /// </summary>
        public int TaxonTypeId { get; set; }
        /// <summary>
        /// The grouped Taxon Type
        /// </summary>
        public TaxonType TaxonType { get; set; }
        #endregion

        /// <summary>
        /// The grouped Taxon ID
        /// </summary>
        public int TaxonId { get; set; }
        /// <summary>
        /// The grouped taxon
        /// </summary>
        public virtual Taxon Taxon { get; set; }
    }
}
