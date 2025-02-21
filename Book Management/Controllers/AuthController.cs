using Application.DTOs.ResponseDTOs;
using Application.DTOs.UserDTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Book_Management.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterModel registerDTO)
    {
        var result = await _authService.Register(registerDTO);

        if (result is not null)
        {
            return Ok(new ApiResponse<IdentityResult>
            {
                Status = "Success",
                Data = result,
                Message = "User Created"
            });
        }
        
        return BadRequest("Could not create");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginModel loginDTO)
    {
        var token = await _authService.Login(loginDTO);

        if (token is not null)
        {
            return Ok(new ApiResponse<TokenModel>
            {
                Status = "Success",
                Data = token,
                Message = "Logged In"
            });
        }

        return BadRequest("Invalid credentials");
    }
}