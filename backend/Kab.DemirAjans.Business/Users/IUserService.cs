using Kab.DemirAjans.Entities.Users;

namespace Kab.DemirAjans.Business.Users;

public interface IUserService
{
    Task<UserDto?> GetAsync(int id);
    Task InsertAsync(UserCreateDto create);
}