﻿namespace Application.DTOs.UserDTOs;

public class TokenModel
{
    public string? JwtToken { get; set; }
    public string? RefreshToken { get; set; }
}
