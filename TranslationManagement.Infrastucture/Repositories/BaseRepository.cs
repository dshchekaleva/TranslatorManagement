using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TranslationManagement.Application.Common;
using TranslationManagement.Domain.Entities;

namespace TranslationManagement.Infrastructure.Repositories
{
    public class BaseRepository: IRepository
    {
        private AppDbContext Context { get; }

        public BaseRepository(AppDbContext context)
        {
            Context = context;
        }
        public async Task<bool> Add<TEntity>(TEntity entity) where TEntity : class
        {
            Context.Add(entity);
            return await Context.SaveChangesAsync() > 0;
        }

        public virtual async Task<TEntity[]> Get<TEntity>(Expression<Func<TEntity, bool>> where) where TEntity : class
        {
            var query = Context.Set<TEntity>().AsNoTracking().AsQueryable();
            return await query.Where(@where).ToArrayAsync();
        }

        public virtual async Task<TEntity[]> Get<TEntity>() where TEntity : class
        {
            var query = Context.Set<TEntity>().AsQueryable();
            return await query.ToArrayAsync();
        }

        public virtual async Task<TEntity> GetById<TEntity>(int id) where TEntity : class, IId<int>
        {
            var query = Context.Set<TEntity>().AsQueryable();
            return await query.SingleAsync(x => x.Id == id);
        }

        public virtual Task Update<TEntity>(TEntity entity) where TEntity : class
        {
            Context.Update(entity);
            return Context.SaveChangesAsync();
        }

        public Task Delete<TEntity>(TEntity entity) where TEntity : class
        {
            Context.Remove(entity);
            return Context.SaveChangesAsync();
        }
    }
}
