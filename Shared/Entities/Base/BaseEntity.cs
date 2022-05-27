namespace CouchDb.Shared;
public abstract class BaseEntity
{
    [JsonProperty(PropertyName = "id")]
    public Guid Id { get; set; }

}
