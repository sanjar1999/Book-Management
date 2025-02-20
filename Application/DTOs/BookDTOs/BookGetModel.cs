namespace Application.DTOs.BookDTOs;

public record BooksGetModel
{
    public int Id { get; set; }
    public string Title { get; set; }
}
