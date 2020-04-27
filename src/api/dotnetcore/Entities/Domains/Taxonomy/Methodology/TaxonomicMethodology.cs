using System;
using System.Collections.Generic;

namespace PlantIO.Entities.Taxonomy
{
    public class TaxonomicMethodology
    {
        // public static readonly TaxonomicMethodology Default = new TaxonomicMethodology() { Id = 0 }; // for species

        public int Id { get; set; }
        public string Identifier { get; set; }
        public virtual TaxonomicMethodologyRankHierarchy RankedHierarchy { get; set; }
        
        public string TaxonomicCodeIdentifier { get; set; }
        public string TaxonomicCodeVersion { get; set; }
        public virtual TaxonomicCode TaxonomicCode { get; set; }

        public TaxaPhilosophy Philosophy { get; set; }

        public string Author { get; set; }
        public int? Version { get; set; }

        public string Name { get; set; }

        public virtual ICollection<TaxonType> TaxonTypes { get; set; }
        public virtual ICollection<Taxon> Taxons { get; set; }
        public virtual ICollection<GroupingTaxon> GroupingTaxons { get; set; }
        public virtual ICollection<GroupingTaxonRelation> GroupingTaxonRelations { get; set; }

        public TaxonomicMethodology() { }
        public TaxonomicMethodology(TaxonomicCode code)
        {
            TaxonomicCode = code;
        }
    }
}