using System;
using System.Collections.Generic;

namespace PlantIO.Entities.Taxonomy
{
    public partial class TaxaHierarchy : IAmDefinedByAVersionedTaxonomyCode
    {
        public int Id { get; set; }

        // #review:
        /// <summary>
        /// Reduced key that concatenates all (key) ranks from most generic to most specific
        /// </summary>
        public string HierarchyKey { get; set; }

        public TaxaPhilosophy TaxaPhilosophy { get; set; }

        public virtual ICollection<TaxaHierarchyRank> Ranks { get; set; }

        public string TaxonomicCode { get; set; }
        public string TaxonomicCodeVersion { get; set; }

        #region #review: taxon data inheritance/merging/spliting to avoid duplicate an entire ranks structure for a subspecies(for instance)?
        //public int? PreviousTaxaHierarchyId { get; set; }

        /// <summary>
        /// Indicates the last level (most specific) declared by this taxon (eg: species, family), so other taxons can extend from this rank to more specific
        /// </summary>
        // public string CurrentTaxonRank { get; set;}

        // review: could cladistic use this inheritance? base class "Taxon"?
        #endregion
    }
}
