using System;
using System.Collections.Generic;

namespace PlantIO.Entities.Taxonomy
{
    // (#review: with the same ID as TaxonID)
    /// <summary>
    /// Describes a Taxon with an specification Entity
    /// </summary>
    public abstract class TaxonEntity : TaxonReference
    {
        /// <summary>
        /// Id for this specification
        /// </summary>
        public int Id { get; set; }

        public TaxonEntity() { }
        public TaxonEntity(Taxon taxon)
            : base(taxon)
        {
            //Id = taxon.Id;
        }
    }
}
