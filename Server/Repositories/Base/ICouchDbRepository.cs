namespace CouchDb.Server;
public interface ICouchDbRepository<TEntity> 
    where TEntity : BaseEntity
{
    
    Task<TEntity> Add(TEntity TEntity);
    Task<IEnumerable<TEntity>> Add(IEnumerable<TEntity> entities);

    Task<TEntity> Get(Guid id);

    Task<TEntity> Update(TEntity entity);
    Task<IEnumerable<TEntity>> Update(IEnumerable<TEntity> entities);

    Task Delete(TEntity entity);
    Task Delete(IEnumerable<TEntity> entities);
}