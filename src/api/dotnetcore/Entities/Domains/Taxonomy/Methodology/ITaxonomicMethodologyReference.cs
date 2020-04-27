using System;

namespace PlantIO.Entities.Taxonomy
{
    public interface ITaxonomicMethodologyReference
    {
        /// <summary>
        /// Discriminator for nomenclature code and taxonomic methodology used for taxonomy
        /// </summary>
        int MethodologyId { get; set; }
        TaxonomicMethodology Methodology { get; }
    }
}