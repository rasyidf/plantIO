using System;
using PlantIO.Data.Core;
using PlantIO.Entities.Cultivar;
using SharpRepository.Repository;
using SharpRepository.Repository.Configuration;

namespace PlantIO.Data.EntityFramework.Repositories
{
    public class CultivarRepository : ConfigurationBasedRepository<Cultivar, Guid>, ICultivarRepository
    {
        public CultivarRepository(ISharpRepositoryConfiguration configuration, string repositoryName = null) 
            : base(configuration, repositoryName)
        {
        }
    }
}