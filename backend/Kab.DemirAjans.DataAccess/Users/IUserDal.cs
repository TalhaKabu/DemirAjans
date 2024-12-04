using Kab.DemirAjans.Entities.Users;

namespace Kab.DemirAjans.DataAccess.Users;

public interface IUserDal
{
    Task<UserDto?> GetAsync(int id);
    Task InsertAsync(UserDto userDto);
}