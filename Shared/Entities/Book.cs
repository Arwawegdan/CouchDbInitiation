namespace CouchDb.Shared;
public class Book : BaseSettingsEntity
{
    [JsonProperty(PropertyName = "isbn")]
    public string? ISBN { get; set; }

    [JsonProperty(PropertyName = "author")]
    public string? Author { get; set; }

    [JsonProperty(PropertyName = "price")]
    public decimal Price { get; set; }
}  