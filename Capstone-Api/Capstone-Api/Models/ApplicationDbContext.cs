using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

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
    }
}