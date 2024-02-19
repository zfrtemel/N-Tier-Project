using Business.Interfaces;
using Business.Repositories.Abstract;
using Core.Enum;
using Core.Interfaces;
using Core.Web.Abstracts.Auth;
using Entity.Models.User;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly ICryptoService _cryptoService;
        public AuthService(ICryptoService cryptoService, ITokenService tokenService, IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            _tokenService = tokenService;
            _cryptoService = cryptoService;
        }
        public UserEntity GetAuthUser()
        {
            int userId = Convert.ToInt32(_httpContextAccessor.HttpContext?.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier)?.FirstOrDefault()?.Value);
            var user = _userRepository.Get(userId);
            if (user == null) throw new Exception("Unauthorized");

            return user;
        }
        public int GetAuthUserId()
        {
            int userId = Convert.ToInt32(_httpContextAccessor.HttpContext?.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier)?.FirstOrDefault()?.Value);
            return userId;
        }
        public string Login(AuthLoginRequest request, EUserRole role)
        {
            var user = _userRepository.Get().Where(x => x.Username == request.Username && x.Role == nameof(role)).FirstOrDefault();
            if (user == null) throw new Exception("User not found");
            if (!_cryptoService.Verify(request.Password, user.Password)) throw new Exception("Password is wrong");

            return _tokenService.GenerateToken(new List<Claim>() {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            });

        }
    }
}
