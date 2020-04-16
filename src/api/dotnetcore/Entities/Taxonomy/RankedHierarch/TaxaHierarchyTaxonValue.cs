using System;
using System.Collections.Generic;

namespace PlantIO.Entities.Taxonomy
{
    /// <summary>
    /// This is an actual "Taxon" (ranked).
    /// Holds a taxon value for a taxon rank according to a <c>TaxaHierarchy</c>
    /// </summary>
    public partial class TaxaHierarchyTaxonValue : ITaxon
    {
        public TaxaHierarchy Hierarchy { get; set; }
        public int HierarchyId { get; set; }

        public string TaxonType { get; set; }

        public string Value { get;set; }
    }

    // public class CladeTaxonValue : ITaxon
    // {
            // string ITaxon.TaxonType { get => "clade"; set; }
            // CladeTaxonValue Ancestor { get; set; }
    // }
}
