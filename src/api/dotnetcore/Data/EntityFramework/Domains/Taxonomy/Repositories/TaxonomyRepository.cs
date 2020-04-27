using System.Linq;
using System;
using PlantIO.Data.Core;
using PlantIO.Entities.Cultivar;
using SharpRepository.Repository;
using SharpRepository.Repository.Configuration;
using PlantIO.Entities.Taxonomy;
using System.Data.Entity;
using PlantIO.Botany;

namespace PlantIO.Taxonomy.Data.EntityFramework
{
    // #refactor:#issue: create a DTO with taxons result structure (clades/ranks/groups) and (#review: do not expose IQueryable)
    // On the other hand, it's fine and advised to use/reuse(with care) IQueryable internally (sharing queries with internal / IQueryable<> extension methods)

    public class TaxonomyRepository : ConfigurationBasedRepository<Cultivar, Guid>
    {
        DbSet<SpeciesTaxonEntity> _speciesTaxons;
        DbSet<GroupingTaxon> _groupingTaxons;
        DbSet<GroupingTaxonRelation> _rankedTaxonValues;
        DbSet<BotanicFeature> _features;
        
        public TaxonomyRepository(ISharpRepositoryConfiguration configuration, string repositoryName = null) 
            : base(configuration, repositoryName)
        {
        }

        public IQueryable<GroupingTaxon> GetSpeciesTaxons(Guid speciesTaxonId, int methodologyId)
        {
            return _speciesTaxons
                .SelectMany(st => st.GroupingTaxonRelations
                    .Where(tg => tg.MethodologyId == methodologyId)
                    .Select(tg => tg.GroupingTaxon)
                );                
        }

        public IQueryable<GroupingTaxon> GetSpeciesTaxons(Guid speciesTaxonId, int[] methodologyIds)
        {
            return _speciesTaxons
                .SelectMany(st => st.GroupingTaxonRelations
                    .Where(tg => methodologyIds.Contains(tg.MethodologyId))
                    .Select(tg => tg.GroupingTaxon)
                );
        }
    }

    public class TaxonFeaturesRepository
    {
        TaxonomyRepository _taxonomy;
        DbSet<TaxonBotanicFeature> _taxonFeatures;

        public TaxonFeaturesRepository(TaxonomyRepository taxonomy)
        {
            _taxonomy = taxonomy;
        }


        public IQueryable<TaxonFeaturesInfo> GetFeatures(Guid speciesTaxonId, int[] methodologyIds)
        {
            var taxons = _taxonomy.GetSpeciesTaxons(speciesTaxonId, methodologyIds);
            var taxonFeatures = _taxonFeatures;
            var a = (
                from gt in taxons
                join f in taxonFeatures
                on gt.TaxonId equals f.TaxonId
                select new 
                {
                    gt.Taxon,
                    f.TaxonId
                });

            return null;
            //_features.Where(f => f.TaxonRelations.Where(tr => tr.))
            // return _speciesTaxons
            //     .SelectMany(st => st.TaxonGroups
            //         .Where(tg => methodologyIds.Contains(tg.MethodologyId))
            //         .Select(tg => tg.GroupingTaxon)
            //     ); 
        }
    }

    public static class TaxonFeatureQueryable
    {
        //public static IQueryable<x> GetFeatures(this IQueryable<x>)
    }

    public class TaxonFeaturesInfo
    {

    }
}