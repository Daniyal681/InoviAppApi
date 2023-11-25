using Inovi.DataTransferObject;
using Inovi.DataTransferObject.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace Inovi.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IRepositoryWrapper _reposWrapper;
        public UserController(IRepositoryWrapper reposWrapper)
        {
            _reposWrapper = reposWrapper;
        }

        [HttpPost]
        public async Task<ActionResult> LoginUser([FromBody] LoginDTO req)
        {
            try
            {
                var loggedInUser = await _reposWrapper.UserRepo.LoginUser(req);
                if (loggedInUser != false)
                {
                    return Ok();
                }
                else
                {
                    throw new Exception("Values cannot be Null!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        public async Task<ActionResult<string>> SendOTP([FromBody] string EmailAddress)
        {
            try
            {
                var result = await _reposWrapper.UserRepo.SendOTP(EmailAddress);
                if (result != null)
                {
                    return result;
                }
                else
                {

                    throw new Exception("Error in Verifying!");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public async Task<IActionResult> SignupUser([FromBody]SignupDTO req)
        {
            try
            {
                if (req == null)
                {
                    throw new Exception("Data Null!");
                }
              var result = _reposWrapper.UserRepo.SignupUser(req);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult> UpdateUserPassword([FromBody] UpdateUserPasswordDTO req)
        {
            try
            {

           
            if (req == null || string.IsNullOrWhiteSpace(req.UserEmail) || string.IsNullOrWhiteSpace(req.UserPassword))
            {
                throw new Exception("Data Null!"); 
            }

            var result = await _reposWrapper.UserRepo.UpdateUserPassword(req);

            if (result != null)
            {
                throw new Exception("Password updated successfully.");
            }
            else
            {
                throw new Exception("Data Null!");
            }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
    
