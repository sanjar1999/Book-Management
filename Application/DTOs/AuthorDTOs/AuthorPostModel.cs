namespace Application.DTOs.AuthorDTOs;

public record AuthorPostModel
{
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
}
