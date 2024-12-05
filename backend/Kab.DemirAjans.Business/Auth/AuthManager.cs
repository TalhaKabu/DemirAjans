using Kab.DemirAjans.Business.Token;
using Kab.DemirAjans.DataAccess.Auth;
using Kab.DemirAjans.Entities.Auth;

namespace Kab.DemirAjans.Business.Auth;

public class AuthManager(IAuthDal authDal, ITokenService tokenService) : IAuthService
{
    private readonly IAuthDal _authDal = authDal;
    private readonly ITokenService _tokenService = tokenService;

    public async Task<AccessToken> Login(LoginDto loginDto)
    {
        var userDto = await _authDal.GetUserAsync(loginDto) ?? throw new ArgumentException("Kullanıcı bulunamadı!");

        //todo şifreyi encryptle
        if (loginDto.Password != userDto.Password)
            throw new ArgumentException("Şifre yanlış!");

        return await Task.Run(() => _tokenService.CreateToken(userDto));
    }
}
