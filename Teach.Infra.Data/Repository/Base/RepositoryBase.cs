using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Teach.Domain.Interfaces;
using Teach.Infra.Data.Context;

namespace Teach.Infra.Data.Repository.Base
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {

        protected readonly TeachContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public RepositoryBase(TeachContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public Task<TEntity> GetById(Guid id) => DbSet.FindAsync(id);

        public Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
            => DbSet.FirstOrDefaultAsync(predicate);

        public void Add(TEntity entity)
        {
            DbSet.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public Task<int> CountAll() => DbSet.CountAsync();

        public Task<int> CountWhere(Expression<Func<TEntity, bool>> predicate)
            => DbSet.CountAsync(predicate);

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
