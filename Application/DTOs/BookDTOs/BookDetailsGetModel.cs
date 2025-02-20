namespace Application.DTOs.BookDTOs;

public record BookDetailsGetModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime PublishedDate { get; set; }
    public string AuthorName { get; set; }
    public int ViewsCount { get; set; }
    public double PopularityScore { get; set; }
}
