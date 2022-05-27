namespace CouchDb.Server;

[Route("api/[controller]")]
[ApiController]
public class BooksController : BaseController<Book>
{
    public BooksController(CouchDbRepository<Book> bookRepository) : base(bookRepository) { }
}
