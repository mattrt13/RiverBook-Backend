using Ardalis.GuardClauses;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace RiverBooks.Books;

public class EfBookRepository : IBookRepository
{
    private readonly BookDbContext db;
    public EfBookRepository(BookDbContext dbContext)
    {
        db = dbContext;
    }


    public Task AddAsync(Book book)
    {
        db.Add(book);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Book book)
    {
        db.Remove(book);
        return Task.CompletedTask;
    }

    public async Task<Book?> GetByIdAsync(Guid guid)
    {
        return await db.books.FindAsync(guid);
    }

    public async Task<List<Book>> GetListAsync()
    {
        return await db.books.ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await db.SaveChangesAsync();
    }
}
