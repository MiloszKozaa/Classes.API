using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Classes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

public static class AuthHelpers
{
    public static string HashPassword(string password, IConfiguration configuration)
    {
        using var sha256 = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(password + configuration["Jwt:Salt"]);
        var hash = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }

    public static bool VerifyPassword(string password, string passwordHash, IConfiguration configuration)
    {
        return HashPassword(password, configuration) == passwordHash;
    }

    public static string GenerateJwtToken(User user, IConfiguration configuration)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(configuration["Jwt:Secret"]!);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            }),
            Expires = DateTime.UtcNow.AddHours(24),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), 
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    // NOWE METODY - pobieranie UserId

    public static Guid GetUserIdFromToken(HttpContext httpContext)
    {
        var userIdClaim = httpContext.User?.FindFirst(ClaimTypes.NameIdentifier);
        
        if (userIdClaim == null || !Guid.TryParse(userIdClaim.Value, out var userGuid))
        {
            throw new UnauthorizedAccessException("Nie znaleziono User ID w tokenie");
        }

        return userGuid;
    }

    public static Guid GetUserIdWithQueryPriority(Guid? userIdFromQuery, HttpContext httpContext)
    {
        // Jak jest w query - bierzemy z query
        if (userIdFromQuery.HasValue && userIdFromQuery.Value != Guid.Empty)
        {
            return userIdFromQuery.Value;
        }

        // Jak nie ma w query - bierzemy z tokenu
        return GetUserIdFromToken(httpContext);
    }
}