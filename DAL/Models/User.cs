using Microsoft.AspNetCore.Identity;

namespace DAL.Models;

public sealed class User : IdentityUser
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime ExpiryTime { get; set; }
}