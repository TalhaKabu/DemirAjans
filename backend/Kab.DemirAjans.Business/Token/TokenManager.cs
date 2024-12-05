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
}