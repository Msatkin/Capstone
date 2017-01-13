namespace Capstone_Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addingtokentouserrtable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Token", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Token");
        }
    }
}
