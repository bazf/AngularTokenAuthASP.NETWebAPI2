namespace DAL.Interfaces.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DevComDbContext context;

        private readonly DbSet<TEntity> dbSet;

        public GenericRepository(DevComDbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> Query()
        {
            return dbSet.AsQueryable();
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return dbSet.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public TEntity GetById(params object[] id)
        {
            try
            {
                return dbSet.Find(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public void Delete(params object[] id)
        {
            TEntity entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
