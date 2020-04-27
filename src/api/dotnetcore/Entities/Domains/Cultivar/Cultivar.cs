using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace PlantIO.Entities.Cultivar
{
    public class Cultivar
    {
        public int Id { get; set; }

        /// <summary>
        /// All identifiers, including from imported DataSets and from previous Nomenclature Code versions
        /// </summary>
        public virtual ICollection<CultivarIdentifier> Identifiers { get; set; }

        public virtual ICollection<CultivarPopularName> PopularNames { get; set; }

        // #wip: those data are in botany domain, but cultivar could have some specific characteristics, like the growth phases(which is more agriculture-oriented and related to botanical life cycles) 
        // public virtual ICollection<ICultivarInteraction> Interactions { get; set; }
        // review: include both features and regional features?
        // public virtual ICollection<RegionalFeature> RegionalFeatures { get; set; }
        // public virtual ICollection<ICultivarCharacteristic> Nutrients { get; set; } // external service
    }
}