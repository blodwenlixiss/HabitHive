using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Application.IServices;
using Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services;

public class JwtService : IJwtService
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<ApplicationUser> _userManager;

    public JwtService(IConfiguration configuration, UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public string GenerateRefreshToken()
    {
        var randomBytes = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomBytes);
        }

        return Convert.ToBase64String(randomBytes);
    }

    public async Task<string> GenerateAccessToken(ApplicationUser user)
    {
        var claim = await GenerateClaims(user);
        var signinCredentials = GetSigninCredentials();
        var token = CreateToken(claim, signinCredentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private async Task<IEnumerable<Claim>> GenerateClaims(ApplicationUser user)
    {
        var authClaims = new List<Claim>
        {
            new Claim("id", user.Id),
            new Claim("firstName", user.FirstName!),
            new Claim("lastName", user.LastName!),
            new Claim("email", user.Email!),
            new Claim("userName", user.UserName!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var roles = await _userManager.GetRolesAsync(user);

        foreach (var role in roles)
        {
            authClaims.Add(new Claim("Role", role));
        }

        return authClaims;
    }

    private SigningCredentials GetSigninCredentials()
    {
        var signinCredentials = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        return new SigningCredentials(signinCredentials, SecurityAlgorithms.HmacSha256);
    }

    private JwtSecurityToken CreateToken(IEnumerable<Claim> claims, SigningCredentials signingCredentials)
    {
        var expirationMinutes = int.Parse(_configuration["Jwt:ExpirationMinutes"]!);
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expirationMinutes),
            signingCredentials: signingCredentials
        );
        return token;
    }
}