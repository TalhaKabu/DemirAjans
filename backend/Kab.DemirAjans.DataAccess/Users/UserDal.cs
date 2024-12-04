using Kab.DemirAjans.DataAccess.DbAccess;
using Kab.DemirAjans.Entities.Users;
using System;

namespace Kab.DemirAjans.DataAccess.Users;

public class UserDal(ISqlDataAccess db) : IUserDal
{
    private readonly ISqlDataAccess _db = db;

    public async Task<UserDto?> GetAsync(int id) => (await _db.LoadDataAsync<UserDto, dynamic>(storedProcedure: "spUsers_Get", new { Id = id })).FirstOrDefault();
    public async Task InsertAsync(UserDto userDto) => await _db.SaveDataAsync(storedProcedure: "spUsers_Insert", new { userDto.Username, userDto.Password, userDto.Name, userDto.LastName, userDto.Email, userDto.IsAdmin, userDto.CreationDate, userDto.LastModificationDate });
}