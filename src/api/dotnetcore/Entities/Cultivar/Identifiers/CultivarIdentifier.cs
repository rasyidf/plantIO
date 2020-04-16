using System;
using System.Collections.Generic;
using PlantIO.Entities.Taxonomy;

namespace PlantIO.Entities.Cultivar
{
    /// <summary>
    /// Entry for a classification in a determined database (null for local) and with an classification criteria
    /// </summary>
    public class CultivarIdentifier : ITaxonomyIdentifier, IMultiDataSetData
    {
        #region Key
        public Guid? DataSetId { get; set; }

        public Guid CultivarId { get; set; }
        public virtual Cultivar Cultivar { get; set; }

        public string TaxonomicCode { get; set; }
        public string TaxonomicCodeVersion { get; set; }
        #endregion

        public int? TaxaHierarchyId { get; set; }
        public virtual TaxaHierarchy TaxaHierarchy { get; set; }
        public virtual ICollection<TaxaHierarchyTaxonValue> TaxaHierarchyTaxonValues { get; set; }

        // #review: cladistic phylogeny

        public string Name { get; set; } // #review: a simple name can also be good

        public TaxonomyIdentifierUsage Usage { get; set; }
    }
}
