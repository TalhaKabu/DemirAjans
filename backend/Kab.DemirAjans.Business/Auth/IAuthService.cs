using Kab.DemirAjans.Entities.Auth;
using System;

namespace Kab.DemirAjans.Business.Auth;

public interface IAuthService
{
    Task<AccessToken> Login(LoginDto loginDto);
}