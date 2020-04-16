namespace PlantIO.Entities.Taxonomy
{
    /// <summary>
    /// The Philo criteria used in this grouping
    /// </summary>
    /// <remarks>
    /// Item documentations source: Samanthi. Differencebetween.com, 21 Jan. 2018, 
    /// www.differencebetween.com/difference-between-monophyletic-and-vs-paraphyletic-and-vs-polyphyletic
    /// </remarks>
    public enum TaxaPhilosophy
    {
        /// <summary>
        /// Monophyletic group is a taxon that consists of a most recent common ancestor and all its descendants.
        /// </summary>
        MonoPhyletic = 1,

        /// <summary>
        /// Paraphyletic group is a taxon that consists of a most recent common ancestor and some of its descendants.
        /// </summary>
        ParaPhyletic = 2, 

        /// <summary>
        /// Polyphyletic group is a taxon that consists of unrelated organisms who are from a different recent common ancestor. This group lacks a most recent common ancestor.
        /// </summary>
        PolyPhyletic = 4
    }
}