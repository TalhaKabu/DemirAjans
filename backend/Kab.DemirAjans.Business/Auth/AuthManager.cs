using Kab.DemirAjans.DataAccess.Auth;
using Kab.DemirAjans.Entities.Auth;

namespace Kab.DemirAjans.Business.Auth
{
    public class AuthManager : IAuthService
    {
        private readonly IAuthDal AuthDal;

        public AuthManager( IAuthDal authDal)
        {
            AuthDal = authDal;
        }

        public async Task<AccessToken> Login(LoginDto loginDto)
        {
            var user = await AuthDal.GetUserAsync(loginDto);

            if (user == null)
                throw new ArgumentException("Kullanıcı adı veya şifre yanlış!");

            return null;
            //return TokenHelper.CreateToken(user, claims);
        }
    }
}
