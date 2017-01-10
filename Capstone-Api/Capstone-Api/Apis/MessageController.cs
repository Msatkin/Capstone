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

        [Route("api/Message/Create/{userId}/{message}")]
        public void Post(string message, string userId)
        {
            Message newMessage = new Message();
            newMessage.Text = message;
            newMessage.Date = DateTime.Now;
            newMessage.UserId = userId;
            _db.Messages.Add(newMessage);
            _db.SaveChanges();
        }

        [Route("api/Message/Recieve/{userId}")]
        public List<Message> Get(string userId)
        {
            return _db.Messages
                .Where(m => m.UserId == userId)
                .ToList();
        }
    }
}