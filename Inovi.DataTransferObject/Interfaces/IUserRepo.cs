using Inovi.DataTransferObject.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inovi.DataTransferObject.Interfaces
{
    public interface IUserRepo
    {
       Task<bool>SignupUser(SignupDTO req);
        Task<bool> LoginUser(LoginDTO req);
        Task<string> SendOTP(string EmailAddress);
       Task <bool> UpdateUserPassword(UpdateUserPasswordDTO req);



    }
}
