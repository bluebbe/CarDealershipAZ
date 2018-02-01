using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CarDealership.Data.Factories;
using CarDealership.Model.DataModel;
using CarDealership.Model.ViewModel;

namespace CarDealership.Tests
{
    [TestFixture]
    public class CarDealershipMockTesting
    {
        [TestCase]
        public void GetAllBodyStylesRuleTest()
        {
            var repo = CarDearlershipRespoFacotory.GetRepository().GetAllBodyStyles();

            Assert.NotNull(repo);
            Assert.AreEqual(4, repo.Count());
            string BodyStyle = repo.Where(i => i.BodyStyleName == "Car").FirstOrDefault().BodyStyleName;
            Assert.AreEqual("Car", BodyStyle);

            BodyStyle = repo.Where(i => i.BodyStyleName == "SUV").FirstOrDefault().BodyStyleName;
            Assert.AreEqual("SUV", BodyStyle);

            BodyStyle = repo.Where(i => i.BodyStyleName == "Truck").FirstOrDefault().BodyStyleName;
            Assert.AreEqual("Truck", BodyStyle);

            BodyStyle = repo.Where(i => i.BodyStyleName == "Van").FirstOrDefault().BodyStyleName;
            Assert.AreEqual("Van", BodyStyle);

       
        }

        [TestCase]
        public void GetAllColorsRuleTest()
        {

            var repo = CarDearlershipRespoFacotory.GetRepository().GetAllColors();

            Assert.NotNull(repo);
            Assert.AreEqual(5, repo.Count());

            string color = repo.Where(i => i.ColorName == "Black").FirstOrDefault().ColorName;
            Assert.AreEqual("Black", color);

        }
        [TestCase]
        public void GetAllInteriorsRuleTest()
        {
            var repo = CarDearlershipRespoFacotory.GetRepository().GetAllInteriors();

            Assert.NotNull(repo);
            Assert.AreEqual(5, repo.Count());

            string color = repo.Where(i => i.InteriorName == "Black").FirstOrDefault().InteriorName;
            Assert.AreEqual("Black", color);
        }

        [TestCase]
        public void GetAllMakesRuleTest()
        {
            var repo = CarDearlershipRespoFacotory.GetRepository().GetAllMakes();

            Assert.NotNull(repo);
            Assert.GreaterOrEqual(repo.Count(), 1);

            string make = repo.Where(i => i.MakeName == "VW").FirstOrDefault().MakeName;
            Assert.AreEqual("VW", make);
        }

        [TestCase]
        public void GetAllModelsRuleTest()
        {
            var repo = CarDearlershipRespoFacotory.GetRepository().GetAllModels();

            Assert.NotNull(repo);
            Assert.GreaterOrEqual(repo.Count(), 1);
            string model = repo.Where(i => i.ModelName == "Jetta").FirstOrDefault().ModelName;
            Assert.AreEqual("Jetta", model);
           
           
        }

        [TestCase]
        public void GetAllTransmissionsRuleTest()
        {
            var repo = CarDearlershipRespoFacotory.GetRepository().GetAllTransmissions();

            Assert.NotNull(repo);
            Assert.AreEqual(2, repo.Count());

            string actualResult = repo.Where(i => i.TransmissionName == "Automatic").FirstOrDefault().TransmissionName; 
            Assert.AreEqual("Automatic",actualResult);

            string actualResult2 = repo.Where(i => i.TransmissionName == "Manual").FirstOrDefault().TransmissionName;
            Assert.AreEqual("Manual", actualResult2);

        }


        [TestCase]
        public void GetAllTypesRuleTest()
        {
            var repo = CarDearlershipRespoFacotory.GetRepository().GetAllTypes();

            Assert.NotNull(repo);
            Assert.AreEqual(2, repo.Count());

            string typeName = repo.Where(i => i.TypeName == "New").FirstOrDefault().TypeName;
            Assert.AreEqual("New", typeName);


            string typeName2 = repo.Where(i => i.TypeName == "Used").FirstOrDefault().TypeName;
            Assert.AreEqual("Used", typeName2);


        }

        [TestCase]
        public void GetModelsForSpecificRuleTest()
        {
            var repo = CarDearlershipRespoFacotory.GetRepository();

            Assert.NotNull(repo);

            var modelsForSpecificModel = repo.GetModelsForSpecificMake("For");
            Assert.IsNull(modelsForSpecificModel);

            modelsForSpecificModel = repo.GetModelsForSpecificMake("VW");
            Assert.NotNull(modelsForSpecificModel);

            var model = modelsForSpecificModel.Any(i => i.ModelName == "Jetta");
            Assert.IsTrue(model);

            model = modelsForSpecificModel.Any(i => i.ModelName == "Civic");
            Assert.IsFalse(model);


        }

        [TestCase]
        public void GetAllPurchaseTypesRuleTest()
        {

            var repo = CarDearlershipRespoFacotory.GetRepository().GetAllPurchaseTypes();

            Assert.NotNull(repo);
            Assert.AreEqual(3, repo.Count());

            string purchaseType = repo.Where(i => i.PurchaseTypeName == "Bank Finance").FirstOrDefault().PurchaseTypeName;
            Assert.AreEqual("Bank Finance", purchaseType);

            string purchaseType2 = repo.Where(i => i.PurchaseTypeName == "Cash").FirstOrDefault().PurchaseTypeName;
            Assert.AreEqual("Cash", purchaseType2);

            string purchaseType3 = repo.Where(i => i.PurchaseTypeName == "Dealer Finance").FirstOrDefault().PurchaseTypeName;
            Assert.AreEqual("Dealer Finance", purchaseType3);
        }


        [TestCase(1, "Car")]
        [TestCase(2, "SUV")]
        [TestCase(3, "Truck")]
        [TestCase(4, "Van")]
        public void GetBodyStyleByIdRuleTest(int id, string expectResult)
        {

            BodyStyle bodyStyle = CarDearlershipRespoFacotory.GetRepository().GetBodyStyleById(id);

            Assert.AreEqual(expectResult,bodyStyle.BodyStyleName);
        }

        [TestCase(1, "Black")]
        [TestCase(2, "White")]
        [TestCase(3, "Blue")]
        [TestCase(4, "Red")]
        [TestCase(5, "Silver")]
        public void GetColorsByIdRuleTest(int id, string expectResult)
        {
            Color color = CarDearlershipRespoFacotory.GetRepository().GetColorsById(id);

            Assert.AreEqual(expectResult, color.ColorName);
        }

        [TestCase(1, "Black")]
        [TestCase(2, "Light Gray")]
        [TestCase(3, "Dark Gray")]
        [TestCase(4, "White")]
        [TestCase(5, "Tan")]
        public void GetInteriorsByIdRuleTest(int id, string expectResult)
        {
            Interior interior = CarDearlershipRespoFacotory.GetRepository().GetInteriorsById(id);

            Assert.AreEqual(expectResult, interior.InteriorName);

        }

        [TestCase(1, "Audi")]
        [TestCase(2, "VW")]
        public void GetMakesByIdRuleTest(int id, string expectResult)
        {
            Make make = CarDearlershipRespoFacotory.GetRepository().GetMakesById(id);

            Assert.AreEqual(expectResult, make.MakeName);
        }


        [TestCase(1, "A4", "Audi")]
        [TestCase(2, "Jetta", "VW")]
        [TestCase(3, "Golf", "VW")]
        [TestCase(4, "TDI", "VW")]
        [TestCase(5, "A6", "Audi")]
        [TestCase(6, "A8", "Audi")]
        public void GetModelsByIdRuleTest(int modelId, string modelName, string makeName)
        {
           var repo = CarDearlershipRespoFacotory.GetRepository();
            Mdle model = repo.GetModelsById(modelId);
            Assert.AreEqual(modelName, model.ModelName);

            Make make = repo.GetMakesById(model.MakeId);
            Assert.AreEqual(makeName, make.MakeName);
            
        }

        [TestCase(1, "Automatic")]
        [TestCase(2, "Manual")]
        public void GetTransmissionsByIdRuleTest(int transmissionId, string transmissionName)
        {
            var repo = CarDearlershipRespoFacotory.GetRepository();
            Transmission trans = repo.GetTransmissionsById(transmissionId);

            Assert.AreEqual(transmissionName, trans.TransmissionName);
        }

        [TestCase(1, "New")]
        [TestCase(2, "Used")]
        public void GetTypesByIdRuleTest(int typeId, string typeName)
        {
            var repo = CarDearlershipRespoFacotory.GetRepository();
            Typ type = repo.GetTypesById(typeId);

            Assert.AreEqual(typeName, type.TypeName);

        }

        [TestCase("Honda",6)]
        [TestCase("Ford",6)]
        public void AddMakeRuleTest(string makeName,int adminId)
        {
            var repo = CarDearlershipRespoFacotory.GetRepository();
            Make newMake = repo.AddMake(makeName, adminId);

            Assert.NotNull(newMake);
            
            Assert.AreEqual(makeName, repo.GetMakesById(newMake.MakeId).MakeName);

        }

        [TestCase("Focus","Ford",6)]
        [TestCase("Civic","Honda",6)]
        public void AddModelRuleTest(string modelName, string makeName,int adminId)
        {
            var repo = CarDearlershipRespoFacotory.GetRepository();
            Make newMake = repo.AddMake(makeName, 6);

            Assert.NotNull(newMake);
            Assert.AreEqual(makeName, repo.GetMakesById(newMake.MakeId).MakeName);

            Mdle newModel = repo.AddModel(modelName, newMake.MakeId, adminId);

            Assert.NotNull(newModel);
            Assert.AreEqual(modelName, repo.GetModelsById(newModel.MdleId).ModelName);
            
        }


        [TestCase("Titel Test1","Description1")]
        [TestCase("Titel Test2", "Description2")]
        public void GetSpecialByIdRuleTest(string title, string description)
        {
            var repo = CarDearlershipRespoFacotory.GetRepository();

            SpecialAd newSpecialAd = repo.AddSpecial(title, description);

            Assert.NotNull(newSpecialAd);
            Assert.AreEqual(title, newSpecialAd.Title);
            Assert.AreEqual(description, newSpecialAd.Description);


            SpecialAd retrievedSpecialAd = repo.GetSpecialById(newSpecialAd.SpecialAdId);

            Assert.NotNull(retrievedSpecialAd);
            Assert.AreEqual(newSpecialAd.SpecialAdId, retrievedSpecialAd.SpecialAdId);
            Assert.AreEqual(title, retrievedSpecialAd.Title);
            Assert.AreEqual(description, retrievedSpecialAd.Description);
            
        }

        [TestCase("Titel Test1", "Description1")]
        [TestCase("Titel Test2", "Description2")]
        public void AddSpecialRuleTest(string title, string description)
        {
            var repo = CarDearlershipRespoFacotory.GetRepository();

            SpecialAd newSpecialAd = repo.AddSpecial(title, description);

            Assert.NotNull(newSpecialAd);
            Assert.AreEqual(title, newSpecialAd.Title);
            Assert.AreEqual(description, newSpecialAd.Description);

        }

        [Test]
        public void FilterInvewntoryByMakeRuleTest()
        {
            var repo = CarDearlershipRespoFacotory.GetRepository();
            var filterInventory = repo.FilterInventoryByMake("VW");

            Assert.NotNull(filterInventory);

            Assert.NotNull(filterInventory.Where(m => m.Make == "VW").FirstOrDefault());
            Assert.Null(filterInventory.Where(m => m.Make == "Audi").FirstOrDefault());

        }

        [Test]
        public void FilterInvewntoryByModelRuleTest()
        {
            var repo = CarDearlershipRespoFacotory.GetRepository();
            var filterInventory = repo.FilterInventoryByModel("Jetta");

            Assert.NotNull(filterInventory);

            Assert.NotNull(filterInventory.Where(m => m.Model == "Jetta").FirstOrDefault());
            Assert.Null(filterInventory.Where(m => m.Model == "A8").FirstOrDefault());

        }


        [Test]
        public void FilterInvewntoryByYearRuleTest()
        {
            var repo = CarDearlershipRespoFacotory.GetRepository();
            var filterInventory = repo.FilterInventoryByYear(2018);

            Assert.NotNull(filterInventory);

            Assert.NotNull(filterInventory.Where(m => m.Year == 2018).FirstOrDefault());
            Assert.Null(filterInventory.Where(m => m.Year == 2016).FirstOrDefault());

        }



        [Test]
        public void GetAllRuleTest()
        {
            var repo = CarDearlershipRespoFacotory.GetRepository();

            var inventory = repo.GetAll();

            Assert.NotNull(inventory);
           
            Assert.NotNull(inventory.Where(p => p.PurhasedDate == null).FirstOrDefault());




        }

        [Test]
        public void GetAllSpecialsRuleTest()
        {
            var repo = CarDearlershipRespoFacotory.GetRepository();

            var specials = repo.GetAllSpecials();

            Assert.NotNull(specials.Where(t => t.Title != null).FirstOrDefault());
            Assert.NotNull(specials.Where(t => t.Description != null).FirstOrDefault());

        }

        [Test]
        public void GetAllFeaturedRuleTest()
        {
            var repo = CarDearlershipRespoFacotory.GetRepository();
            var featured = repo.GetAllFeatured();

            Assert.NotNull(featured.Where(f => f.FeatureVehicle == true).FirstOrDefault());
            Assert.Null(featured.Where(f => f.FeatureVehicle == false).FirstOrDefault());

        }

        [Test]
        public void GetAllPurchasedRuleTest()
        {
            var repo = CarDearlershipRespoFacotory.GetRepository();
            var purchased = repo.GetAllPurchasedVehicle();

            Assert.NotNull(purchased.Where(i => i.PurchasedPrice != null).FirstOrDefault());
            Assert.Null(purchased.Where(i => i.PurchasedPrice == null).FirstOrDefault());


        }

        [Test]
        public void GetAllNonPurchasedRuleTest()
        {
            var repo = CarDearlershipRespoFacotory.GetRepository();
            var nonpurchased = repo.GetAllNonPurchasedVehicle();

            Assert.NotNull(nonpurchased.Where(i => i.PurchasedPrice == null).FirstOrDefault());
            Assert.Null(nonpurchased.Where(i => i.PurchasedPrice != null).FirstOrDefault());


        }

        [Test]
        public void GetInventoryByIdRuleTest()
        {
            var repo = CarDearlershipRespoFacotory.GetRepository();
            var vechicle = repo.GetInventorysById(1);

            Assert.NotNull(vechicle);
            Assert.AreEqual(1, vechicle.InventoryId);
            Assert.AreNotEqual(2, vechicle.InventoryId);


        }


        [Test]
        public void GetRemoveSpecialRuleTest()
        {
            var repo = CarDearlershipRespoFacotory.GetRepository();
            var newSpecial = repo.AddSpecial("Special Title 12", "Description 12");

            Assert.NotNull(newSpecial);

            var verifySpecialPresent = repo.GetSpecialById(newSpecial.SpecialAdId);

            Assert.NotNull(newSpecial);
            Assert.AreEqual(newSpecial.SpecialAdId, verifySpecialPresent.SpecialAdId);


            repo.RemoveSpecial(newSpecial.SpecialAdId);

            verifySpecialPresent = repo.GetSpecialById(newSpecial.SpecialAdId);

            Assert.Null(verifySpecialPresent);
            
        }

        [Test]
        public void PurchasedRuleTest()
        {
            var repo = CarDearlershipRespoFacotory.GetRepository();
           


            var vehicle = repo.GetAllPurchasedVehicle().Where(i => i.InventoryId == 1).FirstOrDefault();
            Assert.Null(vehicle);
            vehicle = repo.GetInventorysById(1);
            Assert.NotNull(vehicle);
            Assert.AreEqual(1, vehicle.InventoryId);
            PurchaseInfo info = new PurchaseInfo
            {
                Name = "Joe Doe",
                City = "Minneapolis",
                State = "MN",
                Email = "joe@gmail.com",
                Phone = "xxx-xxx-xxx",
                Street1 = "302 HWY 100",
                Zipcode = "55416",
                VechicleId = 1,
                Purchase = 18000,
                PurchaseType = "Cash"
            };

            repo.Purchased(info,6);

            vehicle = repo.GetAllPurchasedVehicle().Where(i => i.InventoryId == 1).FirstOrDefault();
            Assert.NotNull(vehicle);
            Assert.AreEqual(1, vehicle.InventoryId);

            vehicle = repo.GetAllNonPurchasedVehicle().Where(i => i.InventoryId == 1).FirstOrDefault();
            Assert.Null(vehicle);
        }


 
        }
}
