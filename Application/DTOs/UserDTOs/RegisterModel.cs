using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.UserDTOs;

public record RegisterModel
{
    [StringLength(15, MinimumLength = 3)]
    public required string FirstName { get; set; }

    [StringLength(15, MinimumLength = 3)]
    public required string LastName { get; set; }

    [EmailAddress]
    public required string Email { get; set; }

    [StringLength(15, MinimumLength = 6)]
    public required string Password { get; set; }

    public required string Username { get; set; }
}
