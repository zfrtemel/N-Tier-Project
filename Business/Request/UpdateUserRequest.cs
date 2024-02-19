using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Request
{
    public class UpdateUserRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
