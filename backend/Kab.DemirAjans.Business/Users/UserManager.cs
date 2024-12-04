using Kab.DemirAjans.Business.Mapper;
using Kab.DemirAjans.DataAccess.Users;
using Kab.DemirAjans.Domain.Users;
using Kab.DemirAjans.Entities.Users;
using System;

namespace Kab.DemirAjans.Business.Users;

public class UserManager(IUserDal userDal) : IUserService
{
    private readonly IUserDal _userDal = userDal;

    public async Task<UserDto?> GetAsync(int id) => await _userDal.GetAsync(id);

    public async Task InsertAsync(UserCreateDto create)
    {
        var user = new User(create.Username, create.Password, create.Name, create.LastName, create.Email, false);

        await _userDal.InsertAsync(ObjectMapper.Mapper.Map<User, UserDto>(user));
    }
}