using System;

namespace PlantIO.Entities.Taxonomy
{
    /// <summary>
    /// Provides reference to a common GUID assigned to represent any kind of Taxon
    /// </summary>
    public interface ITaxonReference
    {
        int TaxonId { get; }
        Taxon Taxon { get; }
    }
    /// <summary>
    /// Provides reference to a common GUID assigned to represent any kind of Taxon
    /// </summary>
    public abstract class TaxonReference : ITaxonReference
    {
        /// <summary>
        /// Taxon ID for this specification
        /// </summary>
        public virtual int TaxonId { get; set; }
        /// <summary>
        /// Taxon for this specification, must be the same as <see cref="Id"/>
        /// </summary>
        public virtual Taxon Taxon { get; set; }

        public TaxonReference() { }
        public TaxonReference(Taxon taxon) 
        { 
            Taxon = taxon;
        }
    }
}
