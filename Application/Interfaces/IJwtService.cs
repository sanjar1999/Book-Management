using DAL.Models;

namespace Application.Interfaces;

public interface IJwtService
{
    public Task<string> CreateJWT(User user);
    public string GenerateRefreshToken();
}
