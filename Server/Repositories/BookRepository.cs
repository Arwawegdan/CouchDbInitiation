using Couchbase.KeyValue;

namespace CouchDb.Server;
public class BookRepository : CouchDbRepository<Book>, IBookRepository
{
    public BookRepository (ICouchbaseCollection collection) : base(collection) { }
  
}