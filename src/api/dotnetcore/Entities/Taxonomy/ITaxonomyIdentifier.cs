namespace PlantIO.Entities.Taxonomy
{
    public interface ITaxonomyIdentifier : IAmDefinedByAVersionedTaxonomyCode
    {
        TaxonomyIdentifierUsage Usage { get; set; }
        TaxaHierarchy TaxaHierarchy { get; set; }
        // #review: cladistic
    }

    // #review: merging/splitting taxon hierarchies
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