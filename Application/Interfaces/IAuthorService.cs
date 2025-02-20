using Application.DTOs.AuthorDTOs;

namespace Application.Interfaces;

public interface IAuthorService
{
    public Task<AuthorGetModel?> GetAuthor(int id);
    public Task<List<AuthorGetModel>> GetAuthors();
    public Task AddAuthor(AuthorPostModel author);
    public Task UpdateAuthor(AuthorPutModel author);
    public Task DeleteAuthor(int id); 
}
