using System;

namespace PlantIO.Entities.Taxonomy
{
    /// <summary>
    /// Association between taxons
    /// </summary>
    public interface ITaxonomicAssociation<TTaxonReference, TTaxon, TTaxonomicMethodology> 
        where TTaxonReference : ITaxonReference
        where TTaxon : Taxon
        where TTaxonomicMethodology : TaxonomicMethodology
    {
        public int MethodologyId { get; set; }
        public TaxonomicMethodology Methodology { get; set; }

        // public Guid OriginalTaxonId { get; set; }
        // public virtual GroupTaxon OriginalTaxon { get; set; }

        // public int DestinationTaxonId { get; set; }
        // public virtual Taxon DestinationTaxon { get; set; }
    }

    interface ITaxonomicAssociation<TTaxonReference, TTaxon> : ITaxonomicAssociation<TTaxonReference, TTaxon, TaxonomicMethodology>
        where TTaxonReference : ITaxonReference
        where TTaxon : Taxon
    { }
}
