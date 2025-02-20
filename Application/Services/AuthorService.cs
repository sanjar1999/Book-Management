using Application.DTOs.AuthorDTOs;
using Application.DTOs.BookDTOs;
using Application.Interfaces;
using DAL.Context;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class AuthorService : IAuthorService
{
    private readonly ApplicationContext _context;

    public AuthorService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<AuthorGetModel?> GetAuthor(int id)
    {
        var author = await _context.Authors
            .Include(a => a.Books)
            .FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);

        if (author is null) return null;

        return new AuthorGetModel
        {
            Id = author.Id,
            Name = author.Name,
            BirthDate = author.BirthDate,
            Books = author.Books.Select(b => new BooksGetModel { Id = b.Id, Title = b.Title }).ToList()
        };
    }

    public async Task<List<AuthorGetModel>> GetAuthors()
    {
        return await _context.Authors
            .Include(a => a.Books)
            .Where(x => !x.IsDeleted)
            .Select(a => new AuthorGetModel
            {
                Id = a.Id,
                Name = a.Name,
                BirthDate = a.BirthDate,
                Books = a.Books.Select(b => new BooksGetModel { Id = b.Id, Title = b.Title }).ToList()
            }).ToListAsync();
    }

    public async Task AddAuthor(AuthorPostModel author)
    {
        var authorToAdd = new Author
        {
            Name = author.Name,
            BirthDate = author.BirthDate
        };

        _context.Authors.Add(authorToAdd);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAuthor(AuthorPutModel author)
    {
        var authorToUpdate = await _context.Authors.FindAsync(author.Id);
        if (authorToUpdate is null) return;

        authorToUpdate.Name = author.Name;
        authorToUpdate.BirthDate = author.BirthDate;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAuthor(int id)
    {
        var author = await _context.Authors.FindAsync(id);
        if (author is null) return;

        author.IsDeleted = true;
        await _context.SaveChangesAsync();
    }
}
