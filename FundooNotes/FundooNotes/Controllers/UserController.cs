using BusinessLayer.Interfaces;
using DataBaseLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.DBcontext;
using System;
using System.Linq;

namespace FundooNotes.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UserController : ControllerBase
    {
        IUserBL userBL;
        FundooContext fundoo;
        private object fundooContext;

        public UserController(IUserBL userBL, FundooContext fundoo)
        {
            this.userBL = userBL;
            this.fundoo = fundoo;
        }
        [HttpPost("register")]
        public IActionResult RegisterUser(UserPostModel user)
        {
            try
            {

                this.userBL.AddUser(user);
                return this.Ok(new { success = true, message = $"Registration Successfull { user.Email}" });

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost("login/{Email}/{Password}")]
        public IActionResult LoginUser(string Email, string Password)
        {
            try
            {
                var userdata = fundoo.Users.FirstOrDefault(u => u.Email == Email && u.Password == Password);
                if (userdata == null)
                {
                    return this.BadRequest(new { success = false, message = $"Email And PassWord Is Invalid" });
                }
                var result = this.userBL.LoginUser(Email, Password);


                return this.Ok(new { success = true, message = $"Login Successfull {result}" });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        [HttpPost("ForgotPassword/{Email}")]
        public IActionResult ForgotPassword(string Email)
        {
            try
            {
                var Result = this.userBL.ForgotPassword(Email);
                if (Result != false)
                {
                    return this.Ok(new

                    {
                        success = true,
                        message = $"mail sent sucessfully" + $"token: {Result}"
                    });
                }

                return this.BadRequest(new { success = false, message = $"mail not sent" });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [Authorize]
        [HttpPut("ChangePassword")]

        public ActionResult ChangePassword(ChangePasswordModel changePassword)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
                int UserID = Int32.Parse(userid.Value);
                var result = fundoo.Users.Where(u => u.UserId == UserID).FirstOrDefault();
                string Email = result.Email.ToString();

                bool res = userBL.ChangePassword(Email, changePassword);//email.changepass
                if (res == false)
                {
                    return this.BadRequest(new { success = false, message = "Enter Valid Password" });
                }
                return this.Ok(new { success = true, message = "Password changed Successfully" });

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}


       