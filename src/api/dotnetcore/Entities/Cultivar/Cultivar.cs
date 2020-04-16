using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace PlantIO.Entities.Cultivar
{
    public class Cultivar
    {
        public Guid Id { get; set; }

        public virtual string ScientificName { get; set; }

        /// <summary>
        /// All identifiers, including from imported DataSets and from previous Nomenclature Code versions
        /// </summary>
        public virtual ICollection<CultivarIdentifier> Identifiers { get; set; }

        // review:

        public virtual ICollection<CultivarPopularName> PopularNames { get; set; }

        // #review: clades

        // review: review modeling
        // public virtual ICollection<IFeature> Features { get; set; }
        // public virtual ICollection<ICultivarInteraction> Interactions { get; set; }

        // review: include both features and regional features?
        // public virtual ICollection<RegionalFeature> RegionalFeatures { get; set; }

        // #review: review
        // public virtual ICollection<ICultivarCharacteristic> Nutrients { get; set; } // external service
    }
}