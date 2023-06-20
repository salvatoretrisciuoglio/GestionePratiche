using GestionePratiche.Persistence.Model;
using Microsoft.EntityFrameworkCore;

namespace GestionePratiche.Persistence.Repositories;

public abstract class Repository<TEntity, TContext> : IRepository<TEntity>
    where TEntity : class, IEntityBase
    where TContext : DbContext
{
    private readonly TContext _dbContext;

    protected Repository(TContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Create(TEntity entity, CancellationToken cancellationToken)
    {
        _dbContext.Set<TEntity>().Add(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> Delete(Guid entityId, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Set<TEntity>().FindAsync(entityId, cancellationToken) ?? throw new InvalidOperationException($"La pratica con id {entityId} non è stata trovata");

        _dbContext.Set<TEntity>().Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task<TEntity> GetById(Guid entityId, CancellationToken cancellationToken)
    {
        return await _dbContext.Set<TEntity>().FindAsync(entityId, cancellationToken) ?? throw new InvalidOperationException($"La pratica con id {entityId} non è stata trovata");
    }


}
