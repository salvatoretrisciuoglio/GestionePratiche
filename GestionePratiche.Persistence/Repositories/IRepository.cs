using GestionePratiche.Persistence.Model;

namespace GestionePratiche.Persistence.Repositories;
public interface IRepository<TEntity>
    where TEntity : class, IEntityBase
{
    Task<TEntity> GetByIdAsync(Guid entityId, CancellationToken cancellationToken);

    Task<Guid> CreateAsync(TEntity entity, CancellationToken cancellationToken);

    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken);

    Task<TEntity> DeleteAsync(Guid entityId, CancellationToken cancellationToken);

}
