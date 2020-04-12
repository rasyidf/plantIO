using System.Collections.Generic;

namespace PlantIO.Entities
{
    public interface ICultivarInteraction
    {
        ICollection<IEnvironmentFactor> Factors { get; set; }
        ICollection<IBiologicalInteractionOutput> Outputs { get; set; }
    }

    public interface IBiologicalInteractionOutput
    {
        /// <summary>
        /// The situation for 
        /// </summary>
        /// <value></value>
        IEnvironmentFactor Factor { get; set; }

        public string CultivarCharacteristicCode { get; set; }
    }
}