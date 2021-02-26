using Microsoft.EntityFrameworkCore;
using second_try.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace second_try.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly AppDbContext context;

        public RepositoryBase(AppDbContext appDbContext)
        {
            this.context = appDbContext;
        }

        public virtual async Task<T> Add(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<T> Delete(long id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"{nameof(T)} doesn't exist");
            }

            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<IEnumerable<T>> GetAll() => await context.Set<T>().ToListAsync();

        public virtual async Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> expression) => await context.Set<T>().Where(expression).ToListAsync();

        public virtual async Task<T> FindById(long id) => await context.Set<T>().FindAsync(id);

        public virtual async Task<T> Update(T entity)
        {
            try
            {
                context.Entry(entity).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }

            return entity;
        }
    }
}
