using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Hangfire;
using Hangfire.SqlServer;
using Capstone_Api.Models;

[assembly: OwinStartup(typeof(Capstone_Api.Startup))]

namespace Capstone_Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            JobStorage.Current = new SqlServerStorage("ConnectionStringName");
            Updater updater = new Updater();
            RecurringJob.AddOrUpdate(() => updater.Run(), Cron.Minutely);
            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}
