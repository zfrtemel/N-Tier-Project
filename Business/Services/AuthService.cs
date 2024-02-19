using Business.Interfaces;
using Business.Repositories.Abstract;
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
        public AuthService(ITokenService tokenService, IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            _tokenService = tokenService;
        }
        public UserEntity GetAuthUser()
        {
            int userId = Convert.ToInt32(_httpContextAccessor.HttpContext?.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier)?.FirstOrDefault()?.Value);
            var user = _userRepository.GetById(userId);
            if (user == null) throw new Exception("Unauthorized");

            return user;
        }
        public int GetAuthUserId()
        {
            int userId = Convert.ToInt32(_httpContextAccessor.HttpContext?.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier)?.FirstOrDefault()?.Value);
            return userId;
        }
        public string Login(IAuthLoginRequest request)
        {
            var user = _userRepository.GetByUsername(request.Username);
            if (user == null) throw new Exception("User not found");
            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password)) throw new Exception("Password is wrong");

            return _tokenService.GenerateToken(new List<Claim>() {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            });

        }
    }
}
