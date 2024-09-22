namespace RiverBooks.Books;

public interface IReadOnlyBookRepository
{
    Task<Book?> GetByIdAsync(Guid guid);
    Task<List<Book>> GetListAsync();
}