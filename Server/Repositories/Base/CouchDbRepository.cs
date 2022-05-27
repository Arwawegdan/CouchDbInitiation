namespace CouchDb.Server;

public class CouchDbRepository<TEntity> : ICouchDbRepository<TEntity>
    where TEntity : BaseEntity
{
    private readonly ICouchbaseCollection _collection;
    public CouchDbRepository(ICouchbaseCollection collection) => _collection = collection;

    public async Task<TEntity> Add(TEntity entity)
    {
        await _collection.InsertAsync(entity.Id.ToString(), entity);
        return entity;
    }

    public async Task<IEnumerable<TEntity>> Add(IEnumerable<TEntity> entities)
    {
        foreach (TEntity entity in entities)
        {
            await Add(entity);
        }
        return entities;
    }

    public async Task<TEntity> Get(Guid id)
    {
        try
        {
            var result = await _collection.GetAsync(id.ToString());
            TEntity entity = result.ContentAs<TEntity>();
            return entity;
        }
        catch (Exception exception)
        {
            throw new Exception("There are no data");
        }
    }

    public async Task<TEntity> Update(TEntity entity)
    {
        await _collection.UpsertAsync("document-key", entity);
        return entity;
    }

    public async Task<IEnumerable<TEntity>> Update(IEnumerable<TEntity> entities)
    {
        foreach (TEntity entity in entities)
        {
            await Update(entity);
        }
        return entities;
    }
    public async Task Delete(TEntity entity)
    {
        await _collection.RemoveAsync(entity.Id.ToString());
    }

    public async Task Delete(IEnumerable<TEntity> entities)
    {
        foreach (TEntity entity in entities)
        {
            await Delete(entity);
        }
    }
}