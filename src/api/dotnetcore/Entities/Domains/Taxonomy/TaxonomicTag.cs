using System;
using System.Collections.Generic;

namespace PlantIO.Entities.Taxonomy
{
    public class TaxonomicTag : ITaxonTypeReference
    {
        public int Id { get; set; }

        public int TypeId { get; set; }
        public virtual TaxonType Type { get; set; }
    }

    public class TaxonomicTagValue
    {
        public int TagId { get; set; }
        public virtual TaxonomicTag Tag { get; set; }

        public int TaxonId { get; set; }
        public virtual Taxon Taxon { get; set; }

        public string Value { get; set; }
    }
}