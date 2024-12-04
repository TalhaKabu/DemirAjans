using Kab.DemirAjans.Entities.Auth;
using Kab.DemirAjans.Entities.Users;

namespace Kab.DemirAjans.DataAccess.Auth
{
    public interface IAuthDal
    {
        Task<UserDto?> GetUserAsync(LoginDto loginDto);
    }
}