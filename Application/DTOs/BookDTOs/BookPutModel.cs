namespace Application.DTOs.BookDTOs;

public record BookPutModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime PublishedDate { get; set; }
    public int AuthorId { get; set; }
}
