

using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Common
{
    public class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        private readonly SpDbContext _SpContextDb;
        private readonly DbSet<TEntity> _Entity;
        private bool disposed = false;
        public SpDbContext spDbContext => _SpContextDb;

        public DbSet<TEntity> Entity => _Entity;

        public Repository(SpDbContext spContextDb)
        {
            this._SpContextDb = spContextDb;
            this._Entity = spContextDb.Set<TEntity>();
        }

        public void Dispose()
        {
            if (!this.disposed)
            {
                _SpContextDb.Dispose();
            }
            this.disposed = true;
        }
        public IQueryable<TEntity> AsQueryable()
        {
            return Entity.AsQueryable<TEntity>();
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await Entity.AddAsync(entity);
            await Save();
            return entity;
        }

        public async Task<TEntity> Delete(TEntity entity)
        {
            Entity.Remove(entity);
            await Save();
            return entity;
        }

        public void Detached(TEntity entity)
        {
            spDbContext.Entry(entity).State = EntityState.Detached;
        }



        public async Task<TEntity> Put(TEntity entity)
        {
            spDbContext.Entry(entity).State = EntityState.Modified;
            Entity.Update(entity);
            await Save();
            return entity;
        }

        public Task<int> Save()
        {
            return spDbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteRange(ICollection<TEntity> range)
        {
            spDbContext.RemoveRange(range);
            return true;
        }
    }
}
