using Core.Enum;
using Core.Web.Abstracts.Auth;
using Entity.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IAuthService
    {
        public string Login(AuthLoginRequest request,EUserRole role);
        public UserEntity GetAuthUser();
        public int GetAuthUserId();
    }
}
