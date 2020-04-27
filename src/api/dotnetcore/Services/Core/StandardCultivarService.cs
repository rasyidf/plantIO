using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PlantIO.Data;

namespace PlantIO.Services
{
    /// <summary>
    /// Standard service implementation for core services. Embeded with repository methods bound to <c>PlantIO.Data.PlantDbContext</c>
    /// </summary>
    public abstract class StandardService<TEntity>
        where TEntity : class
    {
        public CultivarDbContext Db { get; protected set; }
        public DbSet<TEntity> DbSet { get; protected set; }
        protected virtual DbSet<TEntity> GetDbSet() => Db.Set<TEntity>();

        public StandardService(CultivarDbContext db)
        {
            this.Db = db;
            this.DbSet = GetDbSet();
        }

        #region Repository
        public EntityEntry<TEntity> Entry(TEntity entity)
        {
            return Db.Entry(entity);
        }

        public IQueryable<TEntity> List()
        {
            return DbSet;
        }
        #endregion
    }
}