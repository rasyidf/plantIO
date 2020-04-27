using System;
using System.Collections.Generic;
using PlantIO.Entities.Taxonomy;

namespace PlantIO.Entities.Cultivar
{
    /// <summary>
    /// Entry for a classification in a determined database (null for local) and with an classification criteria
    /// </summary>
    [Obsolete("This class is being replaced by " + nameof(Taxonomy.SpeciesTaxonEntity))] // but still need to be multidataset
    public class CultivarIdentifier : ITaxonomyIdentifier, IMultiDataSetData
    {
        #region Key
        public Guid? DataSetId { get; set; }

        public Guid CultivarId { get; set; }
        public virtual Cultivar Cultivar { get; set; }

        public int RankHierarchyId { get; set; }
        public TaxonomicMethodologyRankHierarchy RankHierarchy { get; set; }
        #endregion

        public Guid SpeciesTaxonomyId { get; set; }
        public virtual SpeciesTaxonEntity SpeciesTaxonEntity { get; set; }

        public TaxonomyIdentifierUsage Usage { get; set; }

        // Clade
    }

    public class SpeciesTaxonomyLineage 
    {
        public Guid SpeciesId { get; set; }

        public virtual GroupingTaxon TaxaHierarchy { get; set; }
        public virtual ICollection<TaxonEntry> TaxaHierarchyTaxonValues { get; set; }
    }
}
