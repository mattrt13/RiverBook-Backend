using FastEndpoints;
namespace RiverBooks.Books;

public class ListBookEndpoint(IBookService bookService) : EndpointWithoutRequest<ListBooksResponse>
{
    public override void Configure()
    {
        Get("/api/books");
        AllowAnonymous();
    }
    public override async Task HandleAsync(CancellationToken ct = default)
    {
        var books = await bookService.ListBooksAsync();
        await SendAsync(new ListBooksResponse()
        {
            Books = books
        });
    }
}