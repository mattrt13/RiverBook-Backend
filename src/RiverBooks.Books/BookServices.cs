using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Http.HttpResults;

namespace RiverBooks.Books;

public class BookServices : IBookService
{

    private readonly IBookRepository _bookRepository;
    public BookServices(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task CreateBookAsync(BookDTO newBook)
    {
        var book = new Book(newBook.Id, newBook.Title, newBook.Author, newBook.Price);
        await _bookRepository.AddAsync(book);
        await _bookRepository.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var bookToDelete = await _bookRepository.GetByIdAsync(id);
        if (bookToDelete is null)
            return;
        await _bookRepository.DeleteAsync(bookToDelete);
        await _bookRepository.SaveChangesAsync();
    }

    public async Task<BookDTO> GetBookByIdAsync(Guid id)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        return new BookDTO(book.Id, Guard.Against.NullOrEmpty(book.Title), Guard.Against.NullOrEmpty(book.Author), book.Price);
    }

    public async Task<List<BookDTO>> ListBooksAsync()
    {
        var books = (await _bookRepository.GetListAsync())
            .Select(book => new BookDTO(book.Id, Guard.Against.NullOrEmpty(book.Title), Guard.Against.NullOrEmpty(book.Author), book.Price))
            .ToList();
        return books;
    }

    public async Task UpdateBookPriceAsync(Guid id, decimal newPrice)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        book.UpdatePrice(newPrice);
        await _bookRepository.SaveChangesAsync();
    }
}