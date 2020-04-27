using System;
using System.Collections.Generic;

namespace PlantIO.Entities.Taxonomy
{
    public class TaxonomicCode
    {
        public string Identifier { get; set; }
        public string Version { get; set; }

        public virtual TaxaPhilosophy Philosophy { get; set; }

        public virtual ICollection<TaxonomicMethodology> Methodologies { get; set; }
        public virtual ICollection<TaxonomicMethodologyRankHierarchy> RankBasedMethodologies { get; set; }

        public TaxonomicCode() { }
        public TaxonomicCode(string identifier, string version)
        {
            Identifier = identifier;
            Version = version;
        }
    }
}