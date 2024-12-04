using Kab.DemirAjans.Entities.Auth;
using Kab.DemirAjans.Entities.Users;

namespace Kab.DemirAjans.Business.Token;

public interface ITokenService
{
    Task<AccessToken> CreateToken(UserDto user);
}