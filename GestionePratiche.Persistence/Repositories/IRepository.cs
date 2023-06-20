using GestionePratiche.Persistence.Model;

namespace GestionePratiche.Persistence.Repositories;
public interface IRepository<TEntity>
    where TEntity : class, IEntityBase
{
    Task<TEntity> GetById(Guid entityId, CancellationToken cancellationToken);

    Task<Guid> Create(TEntity entity, CancellationToken cancellationToken);

    Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken);

    Task<TEntity> Delete(Guid entityId, CancellationToken cancellationToken);

}
