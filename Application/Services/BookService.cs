using Application.DTOs.BookDTOs;
using Application.Interfaces;
using DAL.Context;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public sealed class BookService : IBookService
{
    private readonly ApplicationContext _context;

    public BookService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<List<BooksGetModel>> GetBooks(int pageNumber, int pageSize)
    {
        return await _context.Books
            .Where(b => !b.IsDeleted)
            .OrderByDescending(b => b.ViewsCount)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(b => new BooksGetModel { Id = b.Id, Title = b.Title })
            .ToListAsync();
    }

    public async Task<BookDetailsGetModel?> GetBook(int id)
    {
        var book = await _context.Books
            .Include(b => b.Author)
            .FirstOrDefaultAsync(b => b.Id == id && !b.IsDeleted);

        if (book == null) return null;

        book.ViewsCount++;
        await _context.SaveChangesAsync();

        double yearsSincePublished = (DateTime.UtcNow - book.PublishedDate).TotalDays / 365;
        double popularityScore = book.ViewsCount * 0.5 + yearsSincePublished * 2;

        return new BookDetailsGetModel
        {
            Id = book.Id,
            Title = book.Title,
            PublishedDate = book.PublishedDate,
            AuthorName = book.Author?.Name,
            ViewsCount = book.ViewsCount,
            PopularityScore = popularityScore
        };
    }

    public async Task AddBooks(List<BookPostModel> books)
    {
        var existingTitles = await _context.Books.Select(b => b.Title).ToListAsync();

        var booksToAdd = books
            .Where(b => !existingTitles.Contains(b.Title))
            .Select(b => new Book
            {
                Title = b.Title,
                PublishedDate = b.PublishedDate,
                AuthorId = b.AuthorId
            }).ToList();

        if (!booksToAdd.Any()) return;

        await _context.Books.AddRangeAsync(booksToAdd);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateBook(BookPutModel book)
    {
        var existingBook = await _context.Books.FindAsync(book.Id);
        if (existingBook is null || existingBook.IsDeleted) return;

        existingBook.Title = book.Title;
        existingBook.PublishedDate = book.PublishedDate;
        existingBook.AuthorId = book.AuthorId;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteBooks(List<int> ids)
    {
        var books = await _context.Books.Where(b => ids.Contains(b.Id))
                                        .ToListAsync();
        books.ForEach(b => b.IsDeleted = true);

        await _context.SaveChangesAsync();
    }
}