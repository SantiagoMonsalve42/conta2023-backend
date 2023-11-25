namespace Data.Common
{
    public interface IBaseCrud<TEntity> where TEntity : class
    {
        public Task<TEntity> Add(TEntity entity);
        public Task<TEntity> Update(TEntity entity);
        public Task<ICollection<TEntity>> Get();
    }
}
