using Inovi.DataAccessLayer.Models;
using Inovi.DataTransferObject.DTOs;
using Inovi.DataTransferObject.Interfaces;

namespace Inovi.Services.Repostories
{
    public class UserRepo : IUserRepo
    {
        private QueryPro _context;

        public UserRepo(QueryPro context)
        {
            _context = context;
        }
        public async Task<bool> LoginUser(LoginDTO req)
        {
            try
            {
                var isExist = _context.Users.Where(x => x.Username == req.UserName).FirstOrDefault();
                if (isExist != null)
                {
                    if (isExist.Password == req.UserPassword)
                    {
                        if (isExist.UserRoleId != null && isExist.UserRoleId != 0)
                        {
                            throw new Exception("Login Successful");
                        }
                        else
                        {
                            throw new Exception("UserRole not Found!");
                        }
                    }
                    else
                    {
                        throw new Exception("User Not Authorized!");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return true;
        }

        public async Task<string> SendOTP(string EmailAddress)
        {
            try
            {
                var isExist = _context.Users.Where(x => x.EmailAddress == EmailAddress).FirstOrDefault();
                if (isExist == null)
                {
                    throw new Exception("Email not Exist!");
                }
                return isExist.EmailAddress;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> SignupUser(SignupDTO req)
        {
            try
            {
                var isExist = _context.Users.Where(x => x.Username == req.Username).FirstOrDefault();
                if (isExist != null)
                {
                    throw new Exception("User with the same name already exist");
                }

                User tblReq = new User
                {
                    FName = req.UserFName,
                    LName = req.UserLName,
                    Username = req.Username,
                    Password = req.UserPassword,
                    EmailAddress = req.UserEmail

                };
                _context.Users.Add(tblReq);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateUserPassword(UpdateUserPasswordDTO req)
        {
            try
            {
                var isExist = _context.Users.Where(x => x.EmailAddress == req.UserEmail).FirstOrDefault();
                if (isExist != null)
                {
                    throw new Exception("User with the same name already exist");
                }

                User tblReq = new User
                {
                 Password = req.UserPassword,
                };
                _context.Users.Add(tblReq);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
