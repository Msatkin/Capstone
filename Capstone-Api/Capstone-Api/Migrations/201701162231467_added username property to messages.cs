namespace Capstone_Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedusernamepropertytomessages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Username", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "Username");
        }
    }
}
