using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Teach.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> GetById(Guid id);

        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);

        Task<IEnumerable<TEntity>> GetAll();

        Task<IEnumerable<TEntity>> GetWhere(Expression<Func<TEntity, bool>> predicate);

        Task<int> CountAll();

        Task<int> CountWhere(Expression<Func<TEntity, bool>> predicate);
    }
}
