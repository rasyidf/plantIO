using System;

namespace PlantIO.Entities.Taxonomy
{
    // #todo: review
    /// <summary>
    /// An entry in the taxonomic hierarchy of organisms
    /// </summary>
    public interface ITaxonValue<TTaxon> : ITaxonTypeReference
        where TTaxon : ITaxonReference
    {
        int TargetTaxonId { get; set; }
        /// <summary>
        /// The Taxon that will have the <see cref="Value" /> assigned to
        /// </summary>
        TTaxon TargetTaxon { get; set; }

        /// <summary>
        /// The Taxon Type for the <see cref="Value" />
        /// </summary>
        new TaxonType Type { get; set; }

        string Value { get; set; }
    }
}
