namespace CarDealership.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_AdminId_To_MakeAndModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mdles", "AdminId", c => c.Int(nullable: false));
            AddColumn("dbo.Makes", "AdminId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Makes", "AdminId");
            DropColumn("dbo.Mdles", "AdminId");
        }
    }
}
