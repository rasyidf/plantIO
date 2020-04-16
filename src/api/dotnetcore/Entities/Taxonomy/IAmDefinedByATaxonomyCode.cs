public interface IAmDefinedByAVersionedTaxonomyCode // #review: name
{
        /// <summary>
        /// Discriminator for Taxonomic Nomenclature Code edition or custom classification criteria
        /// </summary>
        string TaxonomicCode { get; set; }
        string TaxonomicCodeVersion { get; set; }
}