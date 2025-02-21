namespace Application.DTOs.UserDTOs;

public record LoginModel
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}
