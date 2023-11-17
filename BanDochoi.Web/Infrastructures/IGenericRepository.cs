namespace BanDochoi.Web.Infrastructures
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        void Delete(TEntity entity);
        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);
    }
}
