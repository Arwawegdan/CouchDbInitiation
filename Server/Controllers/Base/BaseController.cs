namespace CouchDb.Server;

[Route("api/[controller]")]
[ApiController]
public class BaseController<TEntity> : ControllerBase where TEntity : BaseEntity
{
    protected readonly ICouchDbRepository<TEntity> _entityRepository;
    public BaseController(ICouchDbRepository<TEntity> entityRepository) => _entityRepository = entityRepository;

    [HttpPost]
    public async Task<TEntity> Post([FromBody] TEntity entity)
    {
        TEntity createdTEntity = await _entityRepository.Add(entity);
        return createdTEntity;
    }

    [HttpPost("/Bulk")]
    public async Task<IEnumerable<TEntity>> Post([FromBody] IEnumerable<TEntity> entities) => await _entityRepository.Add(entities);

    [HttpGet("{id}")]
    public async Task<TEntity> Get(Guid id) => await _entityRepository.Get(id);

    [HttpPut]
    public async Task<TEntity> Put([FromBody] TEntity entity) => await _entityRepository.Update(entity);

    [HttpPut("/Bulk")]
    public async Task<IEnumerable<TEntity>> Put([FromBody] IEnumerable<TEntity> entities) => await _entityRepository.Update(entities);


    [HttpDelete]
    public async Task Delete([FromBody] TEntity entity) => await _entityRepository.Delete(entity);

    [HttpDelete("/Bulk")]
    public async Task Delete([FromBody] IEnumerable<TEntity> entities) => await _entityRepository.Delete(entities);
}
