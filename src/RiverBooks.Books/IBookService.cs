namespace RiverBooks.Books;

public interface IBookService
{
    Task<List<BookDTO>> ListBooksAsync();
    Task<BookDTO> GetBookByIdAsync(Guid id);
    Task CreateBookAsync(BookDTO newBook);
    Task DeleteAsync(Guid id);
    Task UpdateBookPriceAsync(Guid id, decimal newPrice);
}
