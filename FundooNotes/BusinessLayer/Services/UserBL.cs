using BusinessLayer.Interfaces;
using DataBaseLayer;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class UserBL : IUserBL
    {
        IUserRL userRL;
        public UserBL(IUserRL userRL) 
        { 
            this.userRL = userRL;
        }
      

        public void AddUser(UserPostModel user)
        {
            try
            {
                this.userRL.AddUser(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string LoginUser(string Email, string Password)
        {
            try
            {
                return this.userRL.LoginUser(Email, Password);
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }

        public bool ForgotPassword(string Email)
        {
            try
            {
                return this.userRL.ForgetPassword(Email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ChangePassword(string Email, ChangePasswordModel changePassward)
        {
            try
            {
                return this.userRL.ChangePassword(Email,changePassward);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
