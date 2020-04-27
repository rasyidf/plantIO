using System;
using System.Linq;
using PlantIO.Entities.Cultivar;
using PlantIO.Entities.Taxonomy;
using SharpRepository.Repository;

namespace PlantIO.Taxonomy.Data
{
    public interface ITaxonomyRepository
    {
        IQueryable<GroupingTaxon> GetSpeciesTaxons(Guid speciesTaxonId, int methodologyId);
        IQueryable<GroupingTaxon> GetSpeciesTaxons(Guid speciesTaxonId, int[] methodologyIds);
    }
}