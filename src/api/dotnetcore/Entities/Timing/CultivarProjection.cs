using System;
using System.Collections.Generic;

namespace PlantIO.Entities.Timing
{
    public class CultivarProjection
    {
        public Guid CultivarId { get; set; }

        //public virtual ICollection<ICultivarCharacteristic> Characteristics { get; set; }

        public virtual ICollection<ICultivarInteraction> Interactions { get; set; }
    }
}