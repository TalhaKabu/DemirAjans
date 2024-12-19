using Kab.DemirAjans.Entities.Auth;
using Kab.DemirAjans.Entities.Users;
using System.Security.Claims;

namespace Kab.DemirAjans.Business.Token;

public interface ITokenService
{
    AccessToken CreateToken(UserDto user);
    ClaimsPrincipal ValidateToken(string token);
}