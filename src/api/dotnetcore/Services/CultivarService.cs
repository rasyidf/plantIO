using System.Threading.Tasks;
using PlantIO.Data;
using PlantIO.Entities;
using PlantIO.Entities.Cultivar;

namespace PlantIO.Services
{

    public class CultivarService : StandardCultivarService<Cultivar>
    {
        public CultivarService(CultivarDbContext db)
            : base(db)
        {

        }

        public async Task AddAsync(Cultivar cultivar) // #review: receive dto ?
        {
            using (var transaction = Db.Database.BeginTransaction())
            {
                await Db.Cultivars.AddAsync(cultivar);
                await Db.SaveChangesAsync();    
                
                transaction.Commit();
            }
            return;
        }
    }
}