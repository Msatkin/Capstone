using Capstone_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Capstone_Api.Apis
{
    public class LoginController : ApiController
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // POST api/<controller>
        [HttpPost]
        public string Post(string username, string password)
        {
            string userId;
            string response;
            if (!_db.CheckUsername(username))
            {
                response = "error:User not found";
                return response;
            }
            userId = _db.GetUserIdFromUsername(username);
            if (_db.CheckPassword(userId, password))
            {
                string token = _db.GetToken(userId);
                response = "success:" + token;
                return response;
            }
            response = "error:Incorrect password";
            return response;
        }

        [HttpPost]
        public string Post(string token)
        {
            if(_db.CheckToken(token))
            {
                return "success";
            }
            return "Invalid token";
        }
    }
}