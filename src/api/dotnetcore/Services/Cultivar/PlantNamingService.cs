using System;
using System.Linq;
using PlantIO.Entities.Taxonomy;

namespace PlantIO.Services
{
    public class PlantNamingService
    {
        public IQueryable<SpeciesTaxonEntity> FindSpecies(string scientificName)
        {
            throw new NotImplementedException();
        }

        void Rename(string nameHash, object newName)
        {
            // change ids accross database
        }

    }
}