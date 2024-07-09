using System.Linq.Expressions;
using TranslationManagement.Domain.Entities;

namespace TranslationManagement.Application.Common;

public interface IRepository
{
    Task<bool> Add<TEntity>(TEntity entity) where TEntity : class;
    Task Update<TEntity>(TEntity entity) where TEntity : class;
    Task Delete<TEntity>(TEntity entity) where TEntity : class;
    Task<TEntity[]> Get<TEntity>(Expression<Func<TEntity, bool>> where)
        where TEntity : class;
    Task<TEntity[]> Get<TEntity>() where TEntity : class;
    Task<TEntity> GetById<TEntity>(int id) where TEntity : class, IId<int>;
}
