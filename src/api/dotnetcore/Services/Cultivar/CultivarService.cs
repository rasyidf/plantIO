using System.Runtime.InteropServices;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlantIO.Data;
using PlantIO.Entities;
using PlantIO.Entities.Cultivar;
using PlantIO.Taxonomy.Data;
using PlantIO.Botany;

namespace PlantIO.Services
{
    public class CultivarService : StandardService<Cultivar>
    {
        ITaxonomyRepository _taxonomyRepository;

        public CultivarService(CultivarDbContext db, ITaxonomyRepository repository)
            : base(db)
        {
            _taxonomyRepository = repository;
        }

        public List<LifeCycleTaxonInfo> GetLifeCycles(Guid speciesTaxonId, int[] methodologyIds)
        {
            var taxonsQuery = _taxonomyRepository
                .GetSpeciesTaxons(speciesTaxonId, methodologyIds)
                .Select(t => new
                {
                    t.TaxonId,
                    t.MethodologyId,
                    t.TaxonType.LatinName,
                });

            var lifeCycles = Db.Set<BotanicTaxonLifeCycle>()
                .Where(lc => taxonsQuery
                    .Select(t => t.TaxonId)
                    .Contains(lc.TaxonId))
                .Select(lc => new LifeCycleTaxonInfo
                {
                    TaxonId = lc.TaxonId,
                    TaxonTypeId = lc.Taxon.TypeId,
                    TaxonTypeIdentifier = lc.Taxon.Type.LatinName,
                    Order = lc.Order,
                    AverageDuration = lc.AverageDuration,
                });

            return lifeCycles.ToList();
        }

        public class LifeCycleTaxonInfo // #discuss: use mapper
        {
            public int TaxonId { get; set; }
            public int TaxonTypeId { get; set; }
            public string TaxonTypeIdentifier { get; set; }
            public int Order { get; set; } // review: 
            public TimeSpan AverageDuration { get; set; }
        }

        public async Task AddAsync(Cultivar cultivar) // #todo: receive dto ?
        {
            using (var transaction = Db.Database.BeginTransaction())
            {
                //await Db.Cultivars.AddAsync(cultivar);
                await Db.SaveChangesAsync();

                transaction.Commit();
            }
            return;
        }
    }
}