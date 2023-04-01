using System.Linq.Expressions;
using UpDEV.Marketplace.Domains.Common.Database;

namespace UpDEV.Marketplace.Domains.Common.Contracts
{
    public interface IDefaultRepository<TEntity> where TEntity : EntityBase
    {
        IQueryable<TEntity> GetQuery();
        Task<TEntity?> GetByIdAsync(long id, CancellationToken cancellationToken);
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);
        Task<TEntity?> FindSingleAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy);
        Task<IEnumerable<TEntity>> FindWithPaginationAsync(int currentPage, int perPage, Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken);
        Task<int> CountAsync(CancellationToken cancellationToken);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken);
        Task<TEntity?> SaveOrUpdateAsync(TEntity target,CancellationToken cancellationToken);
        Task<TEntity?> DeleteAsync(TEntity entity, CancellationToken cancellationToken);
    }
}
