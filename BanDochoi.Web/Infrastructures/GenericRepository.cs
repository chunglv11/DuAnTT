using Microsoft.EntityFrameworkCore;
using BanDochoi.Web.Data;

namespace BanDochoi.Web.Infrastructures
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly BanDoChoiDbContext context;
        protected DbSet<TEntity> entities;
        public GenericRepository(BanDoChoiDbContext context)
        {
            this.context = context;
            this.entities = context.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            this.entities.Add(entity);
        }

        public void Delete(int id)
        {
            var entity = this.entities.Find(id);
            if (entity != null)
            {
                entities.Remove(entity);
            }
            else
            {
                return;
            }
        }

        public void Delete(TEntity entity)
        {
            this.entities.Remove(entity);
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return entities.Where(predicate);
        }

        public TEntity Get(int id)
        {
            return entities.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return entities;
        }

        public void Update(TEntity entity)
        {
            //entities.Update(entity); // .net framework khong co phuong thuc nay;
            context.Entry<TEntity>(entity).State = EntityState.Modified;
        }
    }
}
