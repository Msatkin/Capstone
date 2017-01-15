using Capstone_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Capstone_Api.Apis
{
    public class RegisterController : ApiController
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        [HttpPost]
        public string Post(string username, string password, string email)
        {
            try
            {
                if (!_db.CheckUsername(username) && !_db.CheckEmail(email))
                {
                    return CreateUser(username, password, email);
                }
                if (_db.CheckEmail(email))
                {
                    return "email";
                }
                if (_db.CheckUsername(username))
                {
                    return "username";
                }
                return "fail";
            }
            catch (Exception e)
            {
                return "Error: " + e;
            }
        }

        private string CreateUser(string username, string password, string email)
        {
            try
            {
                ApplicationUser newUser = new ApplicationUser();
                newUser.UserName = username;
                newUser.Email = email;
                newUser.PasswordHash = password;
                _db.Users.Add(newUser);
                _db.SaveChanges();
                return "success";
            }
            catch
            {
                return "fail";
            }
        }
    }
}