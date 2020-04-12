using System.Collections.Generic;

namespace PlantIO.Entities.Timing
{
    public class CultivarHistory
    {
        public virtual ICollection<ICultivarCharacteristic> Characteristics { get; set; }

        public virtual ICollection<ICultivarInteraction> Interactions { get; set; }
    }
}