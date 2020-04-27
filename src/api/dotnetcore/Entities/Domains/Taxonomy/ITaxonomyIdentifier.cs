using System;

namespace PlantIO.Entities.Taxonomy
{
    [Obsolete("prototype")]
    public interface ITaxonomyIdentifier
    {
        TaxonomyIdentifierUsage Usage { get; set; }

        Guid SpeciesTaxonomyId { get; set; }
        SpeciesTaxonEntity SpeciesTaxonEntity { get; set; }
    }

    [Obsolete("prototype")]
    public enum TaxonomyIdentifierUsage : byte
    {
        None = 0,

        Exclusive = 1,

        /// <summary>
        /// Used to merge group and custom ranks
        /// </summary>
        Complementary = 2,
    }
}