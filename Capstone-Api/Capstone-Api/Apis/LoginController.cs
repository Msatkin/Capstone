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

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public string[] Post(string username, string password)
        {
            string userId;
            string[] response;
            if (!_db.CheckUsername(username))
            {
                response = ["Error", "User not found"];
                return response;
            }
            userId = _db.GetUserId(username);
            if (_db.CheckPassword(userId, password))
            {
                string token = _db.GetToken(userId);
                response = ["success", token];
                return response;
            }
            response = ["Error", "Incorrect password"];
            return response;
        }
    }
}