using System.Collections.Generic;

namespace PlantIO.Entities
{
    public interface IEnvironmentFactor
    {
        public string Code { get; set; }
    }

    public interface ICyclicEnvironmentFactor
    {
        public int Percentage { get; set; }
    }

    public interface IFaunaEnvironmentFactor : IEnvironmentFactor
    {

    }

    public interface IFloraEnvironmentFactor : IEnvironmentFactor, ICyclicEnvironmentFactor
    {
        public string CultivarCharacteristicCode { get; set; }
    }
}