using Application.DTOs.UserDTOs;
using Microsoft.AspNetCore.Identity;

namespace Application.Interfaces;

public interface IAuthService
{
    public Task<IdentityResult?> Register(RegisterModel model);
    public Task<TokenModel> Login(LoginModel model);
}