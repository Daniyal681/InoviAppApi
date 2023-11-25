using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inovi.DataTransferObject.DTOs
{
    public class UserDTO
    {
    }
    public class LoginDTO
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }

    public class SignupDTO
    {
        public string UserFName { get; set; }
        public string UserLName { get; set; }

        public string Username { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
    }

    public class UpdateUserPasswordDTO
    {
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
    }

}
