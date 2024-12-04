using Kab.DemirAjans.DataAccess.DbAccess;
using Kab.DemirAjans.Entities.Auth;
using Kab.DemirAjans.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kab.DemirAjans.DataAccess.Auth;

public class AuthDal(ISqlDataAccess db) : IAuthDal
{
    private readonly ISqlDataAccess _db = db;

    public async Task<UserDto?> GetUserAsync(LoginDto loginDto) => (await _db.LoadDataAsync<UserDto, dynamic>(storedProcedure: "spUsers_GetByUsername", new { loginDto.Username })).FirstOrDefault();
}