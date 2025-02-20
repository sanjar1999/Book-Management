namespace Application.DTOs.BookDTOs;

public record BookPostModel
{
    public string Title { get; set; }
    public DateTime PublishedDate { get; set; }
    public int AuthorId { get; set; }
}
