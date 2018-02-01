namespace CarDealership.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_Profile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "UsersInfo_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "UsersInfo_Id");
            AddForeignKey("dbo.AspNetUsers", "UsersInfo_Id", "dbo.UserInfoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "UsersInfo_Id", "dbo.UserInfoes");
            DropIndex("dbo.AspNetUsers", new[] { "UsersInfo_Id" });
            DropColumn("dbo.AspNetUsers", "UsersInfo_Id");
            DropTable("dbo.UserInfoes");
        }
    }
}
