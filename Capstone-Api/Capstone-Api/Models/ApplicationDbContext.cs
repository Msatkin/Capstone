using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
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
            if (this.Users.Any(c => c.UserName == username))
            {
                return false;
            }
            return true;
        }

        public bool CheckEmail(string email)
        {
            if (this.Users.Any(c => c.Email == email))
            {
                return false;
            }
            return true;
        }

        public string GetUserId(string username)
        {
            return Users.FirstOrDefault(u => u.Id == username).Id;
        }

        public ApplicationUser GetUser(string id)
        {
            return Users.FirstOrDefault(u => u.Id == id);
        }

        public bool CheckPassword(string userId, string password)
        {
            ApplicationUser user = GetUser(userId);
            if (user.PasswordHash == password)
            {
                return true;
            }
            return false;
        }

        public string GetToken()
        {
            return "string";
        }
    }
}