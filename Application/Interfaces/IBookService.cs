using Application.DTOs.BookDTOs;

namespace Application.Interfaces;

public interface IBookService
{
    public Task<List<BooksGetModel>> GetBooks(int pageNumber, int pageSize);
    public Task<BookDetailsGetModel?> GetBook(int id);
    public Task AddBooks(List<BookPostModel> books);
    public Task DeleteBooks(List<int> ids);
    public Task UpdateBook(BookPutModel book);
}
