using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Kab.DemirAjans.Entities.Users;
using Kab.DemirAjans.Entities.Auth;
using Kab.DemirAjans.Business.Helper.JwtHelper;
using System;

namespace Kab.DemirAjans.Business.Token;

public class TokenManager(IConfiguration configuration) : ITokenService
{
    private readonly IConfiguration _configuration = configuration;

    public AccessToken CreateToken(UserDto userDto)
    {
        var securityKey = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(securityKey), SecurityAlgorithms.HmacSha256Signature);
        var jwt = CreateJwtSecurityToken(userDto, signingCredentials);
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var token = jwtSecurityTokenHandler.WriteToken(jwt);
        return new AccessToken { Token = token };
    }

    public JwtSecurityToken CreateJwtSecurityToken(UserDto userDto, SigningCredentials signingCredentials)
    {
        var jwt = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            expires: DateTime.Now.AddDays(1),
            notBefore: DateTime.Now,
            claims: SetClaims(userDto),
            signingCredentials: signingCredentials
        );
        return jwt;
    }

    private IEnumerable<Claim> SetClaims(UserDto userDto)
    {
        var claims = new List<Claim>();
        claims.AddNameIdentifier(userDto.Id.ToString());
        claims.AddName(userDto.Username);
        claims.AddRoles(userDto.IsAdmin ? new List<string> { "Admin", "User" } : new List<string> { "User" });
        return claims;
    }

    public ClaimsPrincipal ValidateToken(string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityKey = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]); // Convert the secret key to bytes

            // Validate the token using the secret key
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = _configuration["Jwt:Issuer"], // Replace with your actual issuer
                ValidAudience = _configuration["Jwt:Audience"], // Replace with your actual audience
                IssuerSigningKey = new SymmetricSecurityKey(securityKey),
                ClockSkew = TimeSpan.Zero // Optional: define clock skew for JWT expiration time tolerance
            };

            SecurityToken validatedToken;
            ClaimsPrincipal principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);

            // If token is valid, return the claims principal (user data)
            return principal;
        }
        catch (Exception ex)
        {
            // If validation fails, return null or throw an error
            return null;
        }
    }
}