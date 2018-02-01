namespace CarDealership.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_Vechicle_Picture_URL : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inventories", "PictureURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inventories", "PictureURL");
        }
    }
}
