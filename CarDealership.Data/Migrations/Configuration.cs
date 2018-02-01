namespace CarDealership.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CarDealership.Model.DataModel;
    using Microsoft.AspNet.Identity;
    using CarDealership.Data.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<CarDealership.Data.EF.EFProdRepo>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CarDealership.Data.EF.EFProdRepo context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.ContactUs.AddOrUpdate(
           p => p.ContactUsId,
           new ContactUs { ContactUsId = 1, Name = "test", Email = "some@somewhere.com", Phone = "999-999-9999", Message = "Initial message" }
           );
            context.SaveChanges();

            context.Colors.AddOrUpdate(
                p => p.ColorId,
                new Color {ColorId = 1, ColorName = "Black" },
                new Color {ColorId = 2, ColorName = "White" },
                new Color {ColorId = 3, ColorName = "Blue" },
                new Color {ColorId = 4, ColorName = "Red" },
                new Color {ColorId = 5, ColorName = "Silver" }

                );

            context.SaveChanges();
            context.BodyStyles.AddOrUpdate(
                p => p.BodyStyleId,
                   new BodyStyle { BodyStyleId = 1, BodyStyleName = "Car" },
                            new BodyStyle {BodyStyleId=2, BodyStyleName = "SUV" },
                            new BodyStyle {BodyStyleId = 3, BodyStyleName = "Truck" },
                            new BodyStyle {BodyStyleId = 4, BodyStyleName = "Van" }
                );

            context.SaveChanges();

            context.Interiors.AddOrUpdate(
                p => p.InteriorId,

                    new Interior {InteriorId = 1, InteriorName = "Black" },
                    new Interior {InteriorId = 2, InteriorName = "Light Gray" },
                    new Interior {InteriorId = 3, InteriorName = "Dark Gray" },
                    new Interior {InteriorId = 4, InteriorName = "White" },
                    new Interior {InteriorId = 5, InteriorName = "Tan" }


                );

            context.SaveChanges();

            context.Makes.AddOrUpdate(
                p => p.MakeId,
                new Make { MakeId = 1,MakeName = "Audi", Created = DateTime.Now },
                new Make { MakeId = 2, MakeName = "VW", Created = DateTime.Now }
                );

            context.SaveChanges();

            context.Models.AddOrUpdate(
                p => p.MdleId,

                    new Mdle { MdleId = 1,ModelName = "A4", Created = DateTime.Now, MakeId = 1 },
                    new Mdle {  MdleId = 2,ModelName = "Jetta", Created = DateTime.Now, MakeId = 2 },
                    new Mdle { MdleId = 3,ModelName = "Golf", Created = DateTime.Now, MakeId = 2 },
                    new Mdle { MdleId = 4,ModelName = "TDI", Created = DateTime.Now, MakeId = 2 },
                    new Mdle { MdleId = 5, ModelName = "A6", Created = DateTime.Now, MakeId = 1 },
                    new Mdle { MdleId = 6,ModelName = "A8", Created = DateTime.Now, MakeId = 1 }


                );

            context.SaveChanges();

            context.Transmissions.AddOrUpdate(
                p => p.TransmissionId,
                    new Transmission { TransmissionId = 1,TransmissionName = "Automatic" },
                    new Transmission { TransmissionId = 2,TransmissionName = "Manual" }


                );
            context.SaveChanges();

            context.Typs.AddOrUpdate(
                p => p.TypId,
                    new Typ { TypId = 1,TypeName = "New" },
                    new Typ { TypId = 2,TypeName = "Used" }
                );
            context.SaveChanges();

            context.PurchaseTypes.AddOrUpdate(
                p => p.PurchaseTypeId,
                    new PurchaseType { PurchaseTypeId = 1,PurchaseTypeName = "Bank Finance" },
                    new PurchaseType { PurchaseTypeId = 2,PurchaseTypeName = "Cash" },
                    new PurchaseType { PurchaseTypeId = 3,PurchaseTypeName = "Dealer Finance" }
                );

            context.SaveChanges();

            context.Specials.AddOrUpdate(
                p => p.SpecialAdId,
                    new SpecialAd {  SpecialAdId =1,Title = "Special 1 Title", Description = "Special 1 Description" },
                    new SpecialAd { SpecialAdId = 2,Title = "Special 2 Title", Description = "Special 2 Description" },
                    new SpecialAd { SpecialAdId = 3,Title = "Special 3 Title", Description = "Special 3 Description" }


                );

            context.SaveChanges();

            context.Inventorys.AddOrUpdate(
                p => p.Id,

                           new Inventory
                           {
                               Id = 1,
                            
                               MdleId = 3,
                               ColorId = 1,
                               InteriorId = 1,
                               BodyStyleId = 1,
                               TypId = 1,
                               Year = 2019,
                               TransmissionId = 1,
                               Mileage = 102000,
                               VIN = "XXXXXXXXXXXXX", // New Car, Not purchased
                               MSRP = 22000,
                               SalesPrice = 16000,
                               Description = "Something",
                               Picture = "inventory-1.jpg",
                               FeatureVehicle = true,
                               PurchaseTypeId = null,
                               PurchaseDate = null,
                               SalesPersonId = null,
                               PictureData = null
                           },

                     new Inventory
                     {
                         Id = 2,
                       
                         MdleId = 3,
                         ColorId = 1,
                         InteriorId = 1,
                         BodyStyleId = 1,
                         TypId = 2,
                         Year = 2019,
                         TransmissionId = 2,
                         Mileage = 102000,
                         VIN = "KKKKKKKKKKKKK", //Used Car, Not purchased
                         MSRP = 23000,
                         SalesPrice = 15000,
                         Description = "Something2",
                         Picture = "inventory-2.jpg",
                         FeatureVehicle = true,
                         PurchaseTypeId = null,
                         PurchaseDate = null,
                         SalesPersonId = null,
                         PictureData = null
                     },
                     new Inventory
                     {
                         Id = 3,
                       
                         MdleId = 4,
                         ColorId = 1,
                         InteriorId = 1,
                         BodyStyleId = 1,
                         TypId = 1,
                         Year = 2018,
                         TransmissionId = 1,
                         Mileage = 102000,
                         VIN = "XXXXXXXXXXXXX", // New Car, Purchased
                         MSRP = 22000,
                         SalesPrice = 14000,
                         Description = "Something",
                         Picture = "inventory-3.jpg",
                         FeatureVehicle = false,
                         PurchaseTypeId = 1,
                         PurchasePrice = 15000,
                         PurchaseDate = DateTime.Now,
                         SalesPersonId = 1,
                         PictureData = null
                     },
                     new Inventory
                     {
                         Id = 4,
                       
                         MdleId = 4,
                         ColorId = 1,
                         InteriorId = 1,
                         BodyStyleId = 1,
                         TypId = 1,
                         Year = 2018,
                         TransmissionId = 1,
                         Mileage = 102000,
                         VIN = "XXXXXXXXXXXXX",// New Car Purchased
                         MSRP = 22000,
                         SalesPrice = 13000,
                         Description = "Something",
                         Picture = "inventory-4.jpg",
                         FeatureVehicle = false,
                         PurchaseTypeId = 2,
                         PurchasePrice = 15000,
                         PurchaseDate = DateTime.Now,
                         SalesPersonId = 1,
                         PictureData = null
                     },
                     new Inventory
                     {
                         Id = 5,
                      
                         MdleId = 2,
                         ColorId = 1,
                         InteriorId = 1,
                         BodyStyleId = 1,
                         TypId = 1,
                         Year = 2017,
                         TransmissionId = 1,
                         Mileage = 102000,
                         VIN = "XXXXXXXXXXXXX", // New Car Purchased
                         MSRP = 21000,
                         SalesPrice = 12000,
                         Description = "Something",
                         Picture = "inventory-5.jpg",
                         FeatureVehicle = false,
                         PurchaseTypeId = 3,
                         PurchasePrice = 15000,
                         PurchaseDate = DateTime.Now,
                         SalesPersonId = 1,
                         PictureData = null
                     },
                        new Inventory
                        {
                            Id = 6,
                          
                            MdleId = 2,
                            ColorId = 1,
                            InteriorId = 1,
                            BodyStyleId = 1,
                            TypId = 1,
                            Year = 2017,
                            TransmissionId = 1,
                            Mileage = 102000,
                            VIN = "XXXXXXXXXXXXX", // New Car Not Purchased
                            MSRP = 22000,
                            SalesPrice = 11000,
                            Description = "Something",
                            Picture = "inventory-6.jpg",
                            FeatureVehicle = true,
                            PurchaseTypeId = null,
                            PurchaseDate = null,
                            SalesPersonId = null,
                            PictureData = null
                        },
                     new Inventory
                     {
                         Id = 7,
                       
                         MdleId = 4,
                         ColorId = 1,
                         InteriorId = 1,
                         BodyStyleId = 1,
                         TypId = 2,       //Used Car, Not Purchased
                         Year = 2018,
                         TransmissionId = 1,
                         Mileage = 102000,
                         VIN = "XXXXXXXXXXXXX",
                         MSRP = 21000,
                         SalesPrice = 13000,
                         Description = "Something",
                         Picture = "inventory-7.jpg",
                         FeatureVehicle = false,
                         PurchaseTypeId = 3,
                         PurchasePrice = 15000,
                         PurchaseDate = DateTime.Now,
                         SalesPersonId = 1,
                         PictureData = null
                     }

                );
            context.SaveChanges();

            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(context));
            var roleMgr = new RoleManager<AppRole>(new RoleStore<AppRole>(context));

            // have we loaded roles already?
            if (roleMgr.RoleExists("admin") && roleMgr.RoleExists("sales"))
                return;

            // create roles
            roleMgr.Create(new AppRole() { Name = "admin" });
            roleMgr.Create(new AppRole() { Name = "sales" });
            // create the default user
            var user = new AppUser()
            {
                UserName = "admin"

            };

            var user2 = new AppUser()
            {
                UserName = "sales"
            };

            // create the user with the manager class
            userMgr.Create(user, "testing123");
            userMgr.Create(user2, "testing123");

            // add the user to the role
            userMgr.AddToRole(user.Id, "admin");
            userMgr.AddToRole(user2.Id, "sales");
        }
    }
}
