namespace Capstone_Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedexpirationdatetomessages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "ExpirationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "ExpirationDate");
        }
    }
}
