using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone_Api.Models
{
    public class Updater
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        public void Run()
        {
            _db.DeleteExpiredMessages();
        }
    }
}