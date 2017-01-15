namespace Capstone_Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpositiontomessages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Longitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Messages", "Latitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "Latitude");
            DropColumn("dbo.Messages", "Longitude");
        }
    }
}
