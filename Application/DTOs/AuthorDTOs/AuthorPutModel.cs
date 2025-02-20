namespace Application.DTOs.AuthorDTOs;

public record AuthorPutModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
}
