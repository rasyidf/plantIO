using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace PlantIO.Entities
{
    public class Cultivar
    {
        public Guid CultivarId { get; set; }

        public virtual CultivarNameIdentifier Identifier { get; set; }
        public virtual ICollection<CultivarNameIdentifier> Identifiers { get; set; }
        public virtual ICollection<CultivarPopularName> PopularNames { get; set; }

        public virtual ICollection<ICultivarCharacteristic> Characteristics { get; set; }
        
        public virtual ICollection<ICultivarInteraction> Interactions { get; set; }
    }
}