namespace CarDealership.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EF_init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BodyStyles",
                c => new
                    {
                        BodyStyleId = c.Int(nullable: false, identity: true),
                        BodyStyleName = c.String(),
                    })
                .PrimaryKey(t => t.BodyStyleId);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        ColorId = c.Int(nullable: false, identity: true),
                        ColorName = c.String(),
                    })
                .PrimaryKey(t => t.ColorId);
            
            CreateTable(
                "dbo.ContactUs",
                c => new
                    {
                        ContactUsId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.ContactUsId);
            
            CreateTable(
                "dbo.Interiors",
                c => new
                    {
                        InteriorId = c.Int(nullable: false, identity: true),
                        InteriorName = c.String(),
                    })
                .PrimaryKey(t => t.InteriorId);
            
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MakeId = c.Int(nullable: false),
                        MdleId = c.Int(nullable: false),
                        TypId = c.Int(nullable: false),
                        BodyStyleId = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        TransmissionId = c.Int(nullable: false),
                        ColorId = c.Int(nullable: false),
                        InteriorId = c.Int(nullable: false),
                        Mileage = c.Int(nullable: false),
                        VIN = c.String(),
                        MSRP = c.Int(nullable: false),
                        SalesPrice = c.Int(nullable: false),
                        Description = c.String(),
                        Picture = c.String(),
                        FeatureVehicle = c.Boolean(nullable: false),
                        PurchasePrice = c.Decimal(precision: 18, scale: 2),
                        PurchaseTypeId = c.Int(),
                        PurchaseDate = c.DateTime(),
                        SalesPersonId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodyStyles", t => t.BodyStyleId, cascadeDelete: true)
                .ForeignKey("dbo.Colors", t => t.ColorId, cascadeDelete: true)
                .ForeignKey("dbo.Interiors", t => t.InteriorId, cascadeDelete: true)
                .ForeignKey("dbo.Makes", t => t.MakeId, cascadeDelete: true)
                .ForeignKey("dbo.Mdles", t => t.MdleId, cascadeDelete: true)
                .ForeignKey("dbo.PurchaseTypes", t => t.PurchaseTypeId)
                .ForeignKey("dbo.Transmissions", t => t.TransmissionId, cascadeDelete: true)
                .ForeignKey("dbo.Typs", t => t.TypId, cascadeDelete: true)
                .Index(t => t.MakeId)
                .Index(t => t.MdleId)
                .Index(t => t.TypId)
                .Index(t => t.BodyStyleId)
                .Index(t => t.TransmissionId)
                .Index(t => t.ColorId)
                .Index(t => t.InteriorId)
                .Index(t => t.PurchaseTypeId);
            
            CreateTable(
                "dbo.Makes",
                c => new
                    {
                        MakeId = c.Int(nullable: false, identity: true),
                        MakeName = c.String(),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MakeId);
            
            CreateTable(
                "dbo.Mdles",
                c => new
                    {
                        MdleId = c.Int(nullable: false, identity: true),
                        ModelName = c.String(),
                        Created = c.DateTime(nullable: false),
                        MakeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MdleId);
            
            CreateTable(
                "dbo.PurchaseTypes",
                c => new
                    {
                        PurchaseTypeId = c.Int(nullable: false, identity: true),
                        PurchaseTypeName = c.String(),
                    })
                .PrimaryKey(t => t.PurchaseTypeId);
            
            CreateTable(
                "dbo.Transmissions",
                c => new
                    {
                        TransmissionId = c.Int(nullable: false, identity: true),
                        TransmissionName = c.String(),
                    })
                .PrimaryKey(t => t.TransmissionId);
            
            CreateTable(
                "dbo.Typs",
                c => new
                    {
                        TypId = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                    })
                .PrimaryKey(t => t.TypId);
            
            CreateTable(
                "dbo.SpecialAds",
                c => new
                    {
                        SpecialAdId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.SpecialAdId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inventories", "TypId", "dbo.Typs");
            DropForeignKey("dbo.Inventories", "TransmissionId", "dbo.Transmissions");
            DropForeignKey("dbo.Inventories", "PurchaseTypeId", "dbo.PurchaseTypes");
            DropForeignKey("dbo.Inventories", "MdleId", "dbo.Mdles");
            DropForeignKey("dbo.Inventories", "MakeId", "dbo.Makes");
            DropForeignKey("dbo.Inventories", "InteriorId", "dbo.Interiors");
            DropForeignKey("dbo.Inventories", "ColorId", "dbo.Colors");
            DropForeignKey("dbo.Inventories", "BodyStyleId", "dbo.BodyStyles");
            DropIndex("dbo.Inventories", new[] { "PurchaseTypeId" });
            DropIndex("dbo.Inventories", new[] { "InteriorId" });
            DropIndex("dbo.Inventories", new[] { "ColorId" });
            DropIndex("dbo.Inventories", new[] { "TransmissionId" });
            DropIndex("dbo.Inventories", new[] { "BodyStyleId" });
            DropIndex("dbo.Inventories", new[] { "TypId" });
            DropIndex("dbo.Inventories", new[] { "MdleId" });
            DropIndex("dbo.Inventories", new[] { "MakeId" });
            DropTable("dbo.SpecialAds");
            DropTable("dbo.Typs");
            DropTable("dbo.Transmissions");
            DropTable("dbo.PurchaseTypes");
            DropTable("dbo.Mdles");
            DropTable("dbo.Makes");
            DropTable("dbo.Inventories");
            DropTable("dbo.Interiors");
            DropTable("dbo.ContactUs");
            DropTable("dbo.Colors");
            DropTable("dbo.BodyStyles");
        }
    }
}
