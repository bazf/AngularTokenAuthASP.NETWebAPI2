namespace DAL.Interfaces
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IGenericRepository<TEntity>
    {
        IQueryable<TEntity> Query();

        IEnumerable<TEntity> GetAll();

        Task<List<TEntity>> GetAllAsync();

        TEntity GetById(params object[] id);

        void Insert(TEntity entity);

        void Delete(TEntity entity);

        void Delete(params object[] id);

        void Update(TEntity entity);
    }
}
