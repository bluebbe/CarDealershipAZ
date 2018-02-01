namespace CarDealership.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_FK_MakeId_to_Model : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Mdles", "MakeId");
            AddForeignKey("dbo.Mdles", "MakeId", "dbo.Makes", "MakeId", cascadeDelete: true);
            DropColumn("dbo.Inventories", "MakeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Inventories", "MakeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Mdles", "MakeId", "dbo.Makes");
            DropIndex("dbo.Mdles", new[] { "MakeId" });
        }
    }
}
