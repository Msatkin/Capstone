using Capstone_Api.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Script.Serialization;
using System.Web.Http;
using System.Web.Http.Results;

namespace Capstone_Api.Apis
{
    public class MessageController : ApiController
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        [HttpPost]
        public string Post(string token, string message, string longitude, string latitude, string delay)
        {
            if (!_db.verifyToken(token))
            {
                return null;
            }
            ApplicationUser user = _db.GetUserFromToken(token);
            _db.CreateTextMessage(user, message, longitude, latitude, int.Parse(delay));
            
            return "success";
        }

        [HttpGet]
        public List<Message> Get(string token, string longitude, string latitude)
        {
            if (!_db.verifyToken(token))
            {
                return null;
            }
            List<Message> messages = _db.GetNearbyMessages(double.Parse(longitude), double.Parse(latitude));
            var json = new JavaScriptSerializer().Serialize(messages);
            return messages;
        }

        [HttpDelete]
        public string Delete(string token, int messageId)
        {
            try
            {
                if (!_db.verifyToken(token))
                {
                    return "Invalid token";
                }

                Message messageToDelete = _db.GetMessageFromId(messageId);
                _db.DeleteMessage(messageToDelete);
                return "Message deleted";
            }
            catch (Exception e)
            {
                return "Error: " + e;
            }
        }

        [HttpPost]
        public string Post(string token, int messageId)
        {
            try {
                if (!_db.verifyToken(token))
                {
                    return "Invalid token";
                }

                Message messageViewed = _db.GetMessageFromId(messageId);
                _db.AddView(messageViewed);
                return "Message viewed";
            }
            catch (Exception e)
            {
                return "Error: " + e;
            }
}
    }
}