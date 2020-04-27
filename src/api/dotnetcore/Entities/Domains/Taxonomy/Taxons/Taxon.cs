using System;
using System.Collections.Generic;

namespace PlantIO.Entities.Taxonomy
{
    /// <summary>
    /// A taxonomic identifier for a unit of beings.
    /// </summary>
    public class Taxon : ITaxonTypeReference, ITaxonReference // #review: the idea behind this class is to have a common GUID to reference between taxonomic relationships. The way it is now may lead to orphaned taxons. further analysis will be necessary while the other modules are developed
    {
        public int Id { get; set; }

        public string Identifier { get; set; }

        public int MethodologyId { get; set; }
        public virtual TaxonomicMethodology Methodology { get; set; }

        [Obsolete("TaxonGrouping binds a taxon to a type and methodology")]
        public int TypeId { get; set; }
        [Obsolete("TaxonGrouping binds a taxon to a type and methodology")]
        public virtual TaxonType Type { get; set; }

        public int? GroupingTaxonId { get; set; }
        public virtual GroupingTaxon GroupingTaxon { get; set; }

        public virtual ICollection<TaxonomicTagValue> Tags { get; set; }

        public virtual ICollection<TaxonEntry> Entries { get; set; }

        public virtual ICollection<GroupingTaxonRelation> GroupingTaxonRelations { get; set; }

        int ITaxonReference.TaxonId => Id; // #refactor: this can cause problems using navigation properties based on "ITaxonReference.TaxonId"
        Taxon ITaxonReference.Taxon => this;


        public Taxon() { }
        /// <summary>
        /// Primary key constructor
        /// </summary>
        public Taxon(int id)
        {
            Id = id;
        }
        public Taxon(string identifier, TaxonType type)
        {
            Identifier = identifier;
            Type = type;
            Methodology = type?.Methodology;
        }
    }

    /// <summary>
    /// This is an actual "Taxon".
    /// Holds a taxon value for a taxon rank according to a <c>TaxaHierarchy</c>
    /// </summary>
    [Obsolete("prototype")]
    public class TaxonEntry : ITaxonValue<Taxon>
    {
        public int TargetTaxonId { get; set; }
        public virtual Taxon TargetTaxon { get; set; }

        public int TypeId { get; set; }
        public virtual TaxonType Type { get; set; }

        public string Value { get; set; }
    }
}
