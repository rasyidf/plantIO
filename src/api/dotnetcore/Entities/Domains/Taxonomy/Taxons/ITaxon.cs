namespace PlantIO.Entities.Taxonomy
{
    /// <summary>
    /// A grouping of living organisms
    /// </summary>
    public interface ITaxon
    {
        /// <summary>
        /// Formal Latin descriptor for taxa: classis, ordo, familia, genus, class; 
        /// depending on nomenclature code
        /// </summary>
        string TaxonType { get; set; }
    }
}
