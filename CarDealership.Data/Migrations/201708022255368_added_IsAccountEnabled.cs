namespace CarDealership.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_IsAccountEnabled : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInfoes", "IsAccountEnabled", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInfoes", "IsAccountEnabled");
        }
    }
}
