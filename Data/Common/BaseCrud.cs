using Microsoft.EntityFrameworkCore;

namespace Data.Common
{
    public class BaseCrud<TEntity> :IBaseCrud<TEntity> where TEntity : class
    {
        public IRepository<TEntity> _repo;

        public BaseCrud(IRepository<TEntity> repo)
        {
            _repo = repo;
        }
        public async Task<TEntity> Add(TEntity entity)
        {
            return await _repo.CreateAsync(entity);
        }
        public async Task<TEntity> Update(TEntity entity)
        {
            return await _repo.Put(entity);
        }
        public async Task<ICollection<TEntity>> Get()
        {
            return await (from row in _repo.Entity select row).ToListAsync();
        }
    }
}
