using Core.Enum;
using Core.Web.Abstracts.Auth;
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
    }
}
