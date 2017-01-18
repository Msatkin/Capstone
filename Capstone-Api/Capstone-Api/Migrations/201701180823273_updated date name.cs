namespace Capstone_Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateddatename : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "PostedDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Messages", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Messages", "PostedDate");
        }
    }
}
