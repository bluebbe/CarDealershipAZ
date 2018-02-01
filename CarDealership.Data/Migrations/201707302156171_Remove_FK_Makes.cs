namespace CarDealership.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_FK_Makes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Inventories", "MakeId", "dbo.Makes");
            DropIndex("dbo.Inventories", new[] { "MakeId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Inventories", "MakeId");
            AddForeignKey("dbo.Inventories", "MakeId", "dbo.Makes", "MakeId", cascadeDelete: true);
        }
    }
}
