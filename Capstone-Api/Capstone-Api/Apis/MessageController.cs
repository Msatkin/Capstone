using Capstone_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Capstone_Api.Apis
{
    public class MessageController : ApiController
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        [HttpPost]
        public string Post(string token, string message, string longitude, string latitude)
        {
            if (!_db.verifyToken(token))
            {
                return null;
            }
            ApplicationUser user = _db.GetUserFromToken(token);
            _db.CreateTextMessage(user, message, longitude, latitude);
            
            return "success";
        }

        [HttpGet]
        public List<Message> Get(string token, string longitude, string latitude)
        {
            if (!_db.verifyToken(token))
            {
                return null;
            }

            return _db.GetNearbyMessages(double.Parse(longitude), double.Parse(latitude));
        }
    }
}