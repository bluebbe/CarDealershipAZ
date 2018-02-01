namespace CarDealership.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_email_from_profile : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserInfoes", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserInfoes", "Email", c => c.String());
        }
    }
}
