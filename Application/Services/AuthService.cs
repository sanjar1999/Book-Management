using Application.DTOs.UserDTOs;
using Application.Interfaces;
using DAL.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;

namespace Application.Services;

public sealed class AuthService : IAuthService
{
    private readonly IConfiguration _config;
    private readonly IJwtService _jwtService;
    private readonly UserManager<User> _userManager;

    public AuthService(IConfiguration config, IJwtService jwtService, UserManager<User> userManager)
    {
        _config = config;
        _jwtService = jwtService;
        _userManager = userManager;
    }

    public async Task<IdentityResult> Register(RegisterModel model)
    {
        if (await CheckEmailExistsAsync(model.Email) || await CheckUserNameExistsAsync(model.Username))
        {
            return null;
        }

        var userToAdd = new User
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            UserName = model.Username,
            Email = model.Email
        };

        var result = await _userManager.CreateAsync(userToAdd, model.Password);

        return result;
    }

    public async Task<TokenModel> Login(LoginModel model)
    {
        ArgumentNullException.ThrowIfNull(model);
        var user = await _userManager.FindByNameAsync(model.Username);

        if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
        {
            return null;
        }

        var tokenValidityInDays = int.Parse(_config["JWT:RefreshTokenValidityInDays"]);
        var accessToken = await _jwtService.CreateJWT(user);
        var refreshToken = _jwtService.GenerateRefreshToken();
        user.RefreshToken = refreshToken;
        user.ExpiryTime = DateTime.UtcNow.AddDays(tokenValidityInDays);
        await _userManager.UpdateAsync(user);

        return new TokenModel { RefreshToken = refreshToken, JwtToken = accessToken };
    }

    private async Task<bool> CheckEmailExistsAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email) != null;
    }

    private async Task<bool> CheckUserNameExistsAsync(string userName)
    {
        return await _userManager.FindByNameAsync(userName) != null;
    }
}