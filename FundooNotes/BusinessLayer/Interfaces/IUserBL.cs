using DataBaseLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IUserBL
    {
        public void AddUser(UserPostModel user);
        public string LoginUser(string Email, string Password);
       public bool ForgotPassword(string Email);
        public bool ChangePassword(string Email, ChangePasswordModel changePassward);
    }
}
