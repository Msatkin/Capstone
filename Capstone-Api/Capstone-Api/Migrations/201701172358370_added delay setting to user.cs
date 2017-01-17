namespace Capstone_Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddelaysettingtouser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Views", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "ExpirationDelay", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ExpirationDelay");
            DropColumn("dbo.Messages", "Views");
        }
    }
}
