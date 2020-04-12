using System.Threading.Tasks;
using PlantIO.Data;
using PlantIO.Entities;

namespace PlantIO.Services
{

    public class CultivarService : StandardCultivarService<Cultivar>
    {
        public CultivarService(PlantDbContext db)
            : base(db)
        {

        }

        public async Task AddAsync(Cultivar cultivar)
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