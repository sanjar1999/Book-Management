using Application.DTOs.BookDTOs;

namespace Application.DTOs.AuthorDTOs;

public record AuthorGetModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public List<BooksGetModel> Books { get; set; }
}
