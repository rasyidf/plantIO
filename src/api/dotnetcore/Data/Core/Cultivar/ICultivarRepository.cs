using System;
using PlantIO.Entities.Cultivar;
using SharpRepository.Repository;

namespace PlantIO.Data.Core
{
    public interface ICultivarRepository : ICrudRepository<Cultivar, Guid>
    {
        
    }
}