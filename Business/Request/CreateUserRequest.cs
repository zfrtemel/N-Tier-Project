using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Request
{
    public class CreateUserRequest
    {
        [NotNull]
        public string Email { get; set; }
        [NotNull]
        public string Password { get; set; }
        [NotNull]
        public string UserName { get; set; }

    }
}
