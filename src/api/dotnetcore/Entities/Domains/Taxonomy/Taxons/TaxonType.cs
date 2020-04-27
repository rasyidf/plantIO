using System;
using System.Collections.Generic;

namespace PlantIO.Entities.Taxonomy
{
    /// <summary>
    /// A normalized entity for Taxon Type Latin name (classis, ordo, familia, genus, class, species, ...)
    /// </summary>
    public class TaxonType : ITaxonomicMethodologyReference
    {
        public int Id { get; set; }

        /// <summary>
        /// Formal Latin descriptor for taxa: ; 
        /// depending on nomenclature code
        /// </summary>
        public string LatinName { get; set; }

        [Obsolete("TaxonGrouping binds a taxon to a type and methodology")]
        public int MethodologyId { get; set; }
        [Obsolete("TaxonGrouping binds a taxon to a type and methodology")]
        public TaxonomicMethodology Methodology { get; set; }

        public TaxonTypeRank Rank { get; set; }

        [Obsolete("TaxonGrouping binds a taxon to a type and methodology")]
        public virtual ICollection<Taxon> Taxons { get; set; }
        public virtual ICollection<TaxonomicTag> Tags { get; set; }

        public TaxonType() { }
        public TaxonType(string latinName)
        {
            LatinName = latinName;
        }
        public static TaxonType Ranked(byte level, string latinName, 
            TaxonomicMethodologyRankHierarchy rankHierarchy)
        {
            var taxonType = new TaxonType(latinName)
            {
                Methodology = rankHierarchy.Methodology,
            };
            taxonType.Rank = new TaxonTypeRank
            {
                TaxonType = taxonType,
                Level = level,
                Hierarchy = rankHierarchy
            };
            return taxonType;
        }
    }
}