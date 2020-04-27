namespace PlantIO.Entities.Taxonomy
{
    /// <summary>
    /// A grouping of living organisms
    /// </summary>
    public interface ITaxonTypeReference
    {
        int TypeId { get; set; }
        TaxonType Type { get; set; }
    }
}
