﻿using Capstone_Api.Models;
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
        
        public string Post(string token, string message, string longitude, string latitude)
        {
            Message newMessage = new Message();
            string userId = _db.GetUserIdFromToken(token);
            DateTime timeNow = DateTime.Now;

            newMessage.Text = message;
            newMessage.Date = timeNow;
            newMessage.UserId = userId;
            newMessage.Longitude = decimal.Parse(longitude);
            newMessage.Latitude = decimal.Parse(latitude);
            _db.Messages.Add(newMessage);
            _db.SaveChanges();
            return "success";
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