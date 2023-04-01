using NHibernate;
using NHibernate.Linq;
using System.Linq.Expressions;
using UpDEV.Marketplace.Domains.Common.Contracts;
using UpDEV.Marketplace.Domains.Common.Database;

namespace UpDEV.Marketplace.Infrastructures.DatabaseRepository.Common
{
    public abstract class DefaultRepository<TEntity> : IDefaultRepository<TEntity> where TEntity : EntityBase
    {
        protected readonly ISession? session;

        protected DefaultRepository(ISession session)
        {
            ArgumentNullException.ThrowIfNull(session, "Instância do Banco de Dados estava nula.");

            this.session = session;
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken)
        {
            return await this.session!.Query<TEntity>().Where(expression).AnyAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<int> CountAsync(CancellationToken cancellationToken)
        {
            return await this.session!.Query<TEntity>().CountAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken)
        {
            return await this.session!.Query<TEntity>().Where(expression).CountAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<TEntity?> DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
            var now = DateTime.UtcNow;

            entity.UpdatedAt = now;
            entity.DeletedAt = now;

            await this.session!.SaveOrUpdateAsync(entity, cancellationToken).ConfigureAwait(false);

            return entity;
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy)
        {
            var query = this.session!.Query<TEntity>().Where(expression);

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync().ConfigureAwait(false);
            }
            else
            {
                return await query.OrderByDescending(p => p.CreatedAt).ToListAsync().ConfigureAwait(false);
            }
        }

        public async Task<TEntity?> FindSingleAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken)
        {
            return await this.session!.Query<TEntity>().Where(expression).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> FindWithPaginationAsync(int currentPage, int perPage, Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy)
        {
            var query = this.session!.Query<TEntity>().Where(expression);

            if (orderBy != null)
            {
                return await orderBy(query).Skip(currentPage * perPage).Take(perPage).ToListAsync().ConfigureAwait(false);
            }
            else
            {
                return await query.OrderByDescending(p => p.CreatedAt).Skip(currentPage * perPage).Take(perPage).ToListAsync().ConfigureAwait(false);
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await this.session!.Query<TEntity>().OrderByDescending(p => p.CreatedAt).ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<TEntity?> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            var result = await this.session!.GetAsync<TEntity>(id, cancellationToken).ConfigureAwait(false);

            return result;
        }

        public IQueryable<TEntity> GetQuery()
        {
            return this.session!.Query<TEntity>();
        }

        public async Task<TEntity?> SaveOrUpdateAsync(TEntity target, CancellationToken cancellationToken)
        {
            if (!target.CreatedAt.HasValue)
            {
                target.CreatedAt = DateTime.UtcNow;
            }

            target.UpdatedAt = DateTime.UtcNow;

            await this.session!.SaveOrUpdateAsync(target, cancellationToken).ConfigureAwait(false);

            return target;
        }
    }
}
