using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Device.Location;
using System.Linq;

namespace Capstone_Api.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Message> Messages { get; set; }

        public ApplicationDbContext()
            : base("ConnectionStringName", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public bool CheckUsername(string username)
        {
            return Users.Any(u => u.UserName.ToLower() == username.ToLower());
        }

        public bool CheckEmail(string email)
        {
            return Users.Any(u => u.Email.ToLower() == email.ToLower());
        }

        public bool CheckToken(string token)
        {
            return Users.Any(u => u.Token == token);
        }

        public string GetUserIdFromUsername(string username)
        {
            return Users.FirstOrDefault(u => u.UserName.ToLower() == username.ToLower()).Id;
        }

        public string GetUserIdFromToken(string token)
        {
            return Users.FirstOrDefault(u => u.Token == token).Id;
        }
        public bool verifyToken(string token)
        {
            return (Users.FirstOrDefault(u => u.Token == token) != null);
        }

        public ApplicationUser GetUserFromId(string id)
        {
            return Users.FirstOrDefault(u => u.Id == id);
        }
        public ApplicationUser GetUserFromToken(string token)
        {
            return Users.FirstOrDefault(u => u.Token == token);
        }

        public bool CheckPassword(string userId, string password)
        {
            ApplicationUser user = GetUserFromId(userId);
            return (user.PasswordHash == password);

        }

        public string GetToken(string userId)
        {
            ApplicationUser user = GetUserFromId(userId);
            if (user.Token == null)
            {
                string token = CreateToken();
                user.Token = token;
                SaveChanges();
                return token;
            }
            return user.Token;
        }

        public string CreateToken()
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        }

        public List<Message> GetNearbyMessages(double longitude, double latitude)
        {
            List<Message> nearbyMessages = new List<Message>();
            foreach (Message message in Messages)
            {
                if (VerifyDistance(message.Longitude, message.Latitude, longitude, latitude, 100))
                {
                    Message copyMessage = message;
                    copyMessage.User = null;
                    nearbyMessages.Add(copyMessage);
                }
            }
            return nearbyMessages;
        }

        public void CreateTextMessage(ApplicationUser user, string message, string longitude, string latitude)
        {
            Message newMessage = new Message();
            DateTime timeNow = DateTime.Now;

            newMessage.Text = message;
            newMessage.Date = timeNow;
            newMessage.UserId = user.Id;
            newMessage.Username = user.UserName;
            newMessage.Longitude = double.Parse(longitude);
            newMessage.Latitude = double.Parse(latitude);

            Messages.Add(newMessage);
            SaveChanges();
        }
        public bool VerifyDistance(double longitudeOne, double latitudeOne, double longitudeTwo, double latitudeTwo, double distance)
        {
            var sCoord = new GeoCoordinate(latitudeOne, longitudeOne);
            var eCoord = new GeoCoordinate(latitudeTwo, longitudeTwo);

            return (sCoord.GetDistanceTo(eCoord) < distance);
        }
    }
}