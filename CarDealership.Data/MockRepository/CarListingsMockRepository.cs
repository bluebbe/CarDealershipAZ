using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Data.Interfaces;
using CarDealership.Model.DataModel;
using CarDealership.Model.ViewModel;
using System.IO;
using System.Web;
using System.Web.Hosting;

namespace CarDealership.Data.MockRepository
{
   



    public class CarListingsMockRepository : ICarDealershipRepository
    {
        private static List<Color> _colors = null;
        private static List<BodyStyle> _bodyStyles = null;
        private static List<Interior> _interiors = null;
        private static List<Make> _makes = null;
        private static List<Mdle> _models = null;
        private static List<Transmission> _transimissions = null;
        private static List<Typ> _types = null;
        private static List<Inventory> _inventorys = null;
        private static List<PurchaseType> _purchaseTypes = null;
        private static List<SpecialAd> _specials = null;

        private static List<ContactUs> _contactUs = null;

        public CarListingsMockRepository()
        {

            if (_contactUs == null)
            {
                _contactUs = new List<ContactUs>
                {
                    new ContactUs {ContactUsId = 1, Name="test",Email="some@somewhere.com",Phone="999-999-9999",Message="Initial message"}
                };

            }



            if (_colors == null)
            {
                _colors = new List<Color> {
                    new Color { ColorId = 1,ColorName="Black" },
                    new Color { ColorId = 2,ColorName="White"},
                     new Color { ColorId = 3,ColorName="Blue"},
                      new Color { ColorId = 4,ColorName="Red"},
                       new Color { ColorId = 5,ColorName="Silver"}
                    };
                
            }

            if (_bodyStyles == null)
            {
                _bodyStyles = new List<BodyStyle>
                {
                    new BodyStyle{BodyStyleId = 1,BodyStyleName= "Car"},
                    new BodyStyle{BodyStyleId = 2,BodyStyleName= "SUV"},
                    new BodyStyle{BodyStyleId = 3, BodyStyleName="Truck"},
                    new BodyStyle{BodyStyleId = 4, BodyStyleName="Van"}
                };

            }

            if(_interiors == null)
            {
                _interiors = new List<Interior>
                {
                    new Interior{InteriorId = 1,InteriorName = "Black"},
                    new Interior{InteriorId = 2,InteriorName = "Light Gray"},
                   new Interior{InteriorId = 3,InteriorName = "Dark Gray"},
                    new Interior{InteriorId = 4,InteriorName = "White"},
                     new Interior{InteriorId = 5,InteriorName = "Tan"}
                };

            }

            if (_makes == null)
            {
                _makes = new List<Make>
                {

                    new Make{MakeId = 1, MakeName="Audi", Created=DateTime.Now, AdminId = 6 },
                    new Make{MakeId = 2, MakeName="VW", Created=DateTime.Now, AdminId = 6}
                };
            }

            if (_models == null)
            {
                _models = new List<Mdle>
                {
                    new Mdle{MdleId = 1, ModelName="A4", Created=DateTime.Now, MakeId=1, AdminId = 6},
                    new Mdle{MdleId = 2, ModelName="Jetta", Created=DateTime.Now, MakeId=2, AdminId = 6},
                    new Mdle{MdleId = 3, ModelName="Golf", Created= DateTime.Now, MakeId=2 , AdminId =6},
                     new Mdle{MdleId = 4, ModelName="TDI", Created= DateTime.Now, MakeId=2, AdminId = 6},
                      new Mdle{MdleId = 5, ModelName="A6", Created=DateTime.Now, MakeId=1 , AdminId = 6},
                       new Mdle{MdleId = 6, ModelName="A8", Created=DateTime.Now, MakeId=1, AdminId = 6},
                };
            }

            if (_transimissions == null)
            {
                _transimissions = new List<Transmission>
                {
                    new Transmission{TransmissionId = 1,TransmissionName="Automatic"},
                    new Transmission{TransmissionId = 2, TransmissionName="Manual"}

                };
            }

            if (_types == null)
            {
                _types = new List<Typ>
                {
                    new Model.DataModel.Typ{TypId = 1,TypeName="New"},
                    new Model.DataModel.Typ{TypId = 2,TypeName="Used"}

                };

            }

            if (_purchaseTypes == null)
            {
                _purchaseTypes = new List<PurchaseType>
                {
                    new PurchaseType{PurchaseTypeId = 1, PurchaseTypeName = "Bank Finance"},
                    new PurchaseType{PurchaseTypeId = 2, PurchaseTypeName = "Cash"},
                    new PurchaseType{PurchaseTypeId = 3, PurchaseTypeName = "Dealer Finance"}
                };
            }


            if (_inventorys == null)
            {
                _inventorys = new List<Inventory>
                {
                    new Inventory {Id = 1, MdleId = 3,
                        ColorId = 1, InteriorId=1, BodyStyleId = 1 , TypId = 1,
                        Year = 2019, TransmissionId=1,Mileage=102000,VIN="XXXXXXXXXXXXX", // New Car, Not purchased
                        MSRP =22000,SalesPrice=16000,Description="Something",Picture="inventory-1.jpg",FeatureVehicle=true,PurchaseTypeId=null,
                        PurchaseDate = null, SalesPersonId = null, PurchasePrice = null},

                     new Inventory {Id = 2,  MdleId = 3, 
                        ColorId = 1, InteriorId=1, BodyStyleId = 1 , TypId = 2,
                        Year = 2019, TransmissionId=2,Mileage=102000,VIN="KKKKKKKKKKKKK", //Used Car, Not purchased
                        MSRP =23000,SalesPrice=15000,Description="Something2",Picture="inventory-2.jpg",FeatureVehicle=true,PurchaseTypeId=null,
                         PurchaseDate = null, SalesPersonId = null, PurchasePrice = null},
                     new Inventory {Id = 3, MdleId = 4,
                        ColorId = 1, InteriorId=1, BodyStyleId = 1 , TypId = 1,
                        Year = 2018, TransmissionId=1,Mileage=102000,VIN="XXXXXXXXXXXXX", // New Car, Purchased
                        MSRP =22000,SalesPrice=14000,Description="Something",Picture="inventory-3.jpg",FeatureVehicle=false, PurchaseTypeId=1,
                         PurchaseDate = DateTime.Now, SalesPersonId = 4,PurchasePrice= 18000},
                     new Inventory {Id = 4,  MdleId = 4,
                        ColorId = 1, InteriorId=1, BodyStyleId = 1 , TypId = 1,
                        Year = 2018, TransmissionId=1,Mileage=102000,VIN="XXXXXXXXXXXXX",// New Car Purchased
                        MSRP =22000,SalesPrice=13000,Description="Something",Picture="inventory-4.jpg",FeatureVehicle=false, PurchaseTypeId=2,
                         PurchaseDate = DateTime.Now, SalesPersonId = 3, PurchasePrice = 19000},
                     new Inventory {Id = 5, MdleId = 2,
                        ColorId = 1, InteriorId=1, BodyStyleId = 1 , TypId = 1,
                        Year = 2017, TransmissionId=1,Mileage=102000,VIN="XXXXXXXXXXXXX", // New Car Purchased
                        MSRP =21000,SalesPrice=12000,Description="Something",Picture="inventory-5.jpg",FeatureVehicle=false,PurchaseTypeId=3,
                         PurchaseDate = DateTime.Now, SalesPersonId = 3 , PurchasePrice = 15000},
                        new Inventory {Id = 6,  MdleId = 2,
                        ColorId = 1, InteriorId=1, BodyStyleId = 1 , TypId = 1,
                        Year = 2017, TransmissionId=1,Mileage=102000,VIN="XXXXXXXXXXXXX", // New Car Not Purchased
                        MSRP =22000,SalesPrice=11000,Description="Something",Picture="inventory-6.jpg",FeatureVehicle=true,PurchaseTypeId=null,
                         PurchaseDate = null, SalesPersonId = null, PurchasePrice = null},
                     new Inventory {Id = 7,  MdleId = 4,
                        ColorId = 1, InteriorId=1, BodyStyleId = 1 , TypId = 2,       //Used Car, Purchased
                        Year = 2018, TransmissionId=1,Mileage=102000,VIN="XXXXXXXXXXXXX",
                        MSRP =21000,SalesPrice=13000,Description="Something",Picture="inventory-7.jpg",FeatureVehicle=false,PurchaseTypeId=3,
                             PurchaseDate = DateTime.Now, SalesPersonId = 4, PurchasePrice = 18000},
    };

            }


            if (_specials == null)
            {

                _specials = new List<SpecialAd>
                {
                    new SpecialAd {SpecialAdId = 1, Title="Special 1 Title", Description="Special 1 Description"},
                    new SpecialAd {SpecialAdId = 2, Title="Special 2 Title", Description="Special 2 Description"},
                    new SpecialAd {SpecialAdId = 3, Title ="Special 3 Title", Description= "Special 3 Description"}

                };
            }

        }

        public IEnumerable<VechicleViewModel> GetAll()
        {


            List<VechicleViewModel> repo = new List<VechicleViewModel>();



            foreach (var item in _inventorys)
            {
                VechicleViewModel vechicle = new VechicleViewModel();
                vechicle.InventoryId = item.Id;
                vechicle.Make = GetMakesById(_models.Where(id => id.MdleId == item.MdleId).SingleOrDefault().MakeId).MakeName;
                vechicle.Model = _models.Where(id => id.MdleId == item.MdleId).SingleOrDefault().ModelName;
                vechicle.Type = _types.Where(id => id.TypId == item.TypId).SingleOrDefault().TypeName;
                vechicle.BodyStyle = _bodyStyles.Where(id => id.BodyStyleId == item.BodyStyleId).SingleOrDefault().BodyStyleName;
                vechicle.Year = item.Year;
                vechicle.Transmission = _transimissions.Where(id => id.TransmissionId == item.TransmissionId).SingleOrDefault().TransmissionName;
                vechicle.Color = _colors.Where(id => id.ColorId == item.ColorId).SingleOrDefault().ColorName;
                vechicle.Interior = _interiors.Where(id => id.InteriorId == item.InteriorId).SingleOrDefault().InteriorName;
                vechicle.Mileage = item.Mileage;
                vechicle.VIN = item.VIN;
                vechicle.MSRP = item.MSRP;
                vechicle.SalesPrice = item.SalesPrice;
                vechicle.Description = item.Description;
                vechicle.Picture = item.Picture;
                vechicle.FeatureVehicle = item.FeatureVehicle;
                vechicle.StillAvailable = item.PurchaseTypeId == null ? "Yes" : "No";
                vechicle.SalesId = item.SalesPersonId;
                vechicle.PurchasedPrice = item.PurchasePrice;


                repo.Add(vechicle);

            }

            return repo;
        }


      

        public IEnumerable<VechicleViewModel> FilterInventoryByMake(string makeName)
        {
            List<VechicleViewModel> repo = (this).GetAll().ToList();

            return repo.Where(m => m.Make == makeName);
        }

        public IEnumerable<VechicleViewModel> FilterInventoryByModel(string modelName)
        {
            List<VechicleViewModel> repo = (this).GetAll().ToList();

            return repo.Where(m => m.Model == modelName);
        }

        public IEnumerable<VechicleViewModel> FilterInventoryByYear(int year)
        {
            List<VechicleViewModel> repo = (this).GetAll().ToList();

            return repo.Where(m => m.Year == year);
        }

     

        public IEnumerable<BodyStyle> GetAllBodyStyles()
        {
            return _bodyStyles;
        }

        public IEnumerable<Color> GetAllColors()
        {
            return _colors;
        }

        public IEnumerable<Interior> GetAllInteriors()
        {
            return _interiors;
        }

        public IEnumerable<Make> GetAllMakes()
        {
            return _makes;
        }

        public IEnumerable<Mdle> GetAllModels()
        {
            return _models;
        }

        public IEnumerable<Transmission> GetAllTransmissions()
        {
            return _transimissions;
        }

        public IEnumerable<Model.DataModel.Typ> GetAllTypes()
        {
            return _types;
        }

        public BodyStyle GetBodyStyleById(int id)
        {
            return _bodyStyles.Where(b => b.BodyStyleId == id).FirstOrDefault();
        }

        public Color GetColorsById(int id)
        {
            return _colors.Where(c => c.ColorId == id).FirstOrDefault();
        }

        public Interior GetInteriorsById(int id)
        {
            return _interiors.Where(i => i.InteriorId == id).FirstOrDefault();
        }

        public VechicleViewModel GetInventorysById(int id)
        {
            return (this).GetAll().Where(i => i.InventoryId == id).FirstOrDefault();
        }

        public Make GetMakesById(int id)
        {
            return _makes.Where(i => i.MakeId == id).FirstOrDefault();
        }

        public Mdle GetModelsById(int id)
        {
            return _models.Where(i => i.MdleId == id).FirstOrDefault() ;
        }

        public Transmission GetTransmissionsById(int id)
        {
            return _transimissions.Where(i => i.TransmissionId == id).FirstOrDefault();
        }

        public Typ GetTypesById(int id)
        {
            return _types.Where(i => i.TypId == id).FirstOrDefault();
        }

        public Make AddMake(string makeName, int adminId)
        {
            Make newMake = new Make();
            newMake.MakeId = _makes.Max(i => i.MakeId) + 1;
            newMake.MakeName = makeName;
            newMake.Created = DateTime.Now;
            newMake.AdminId = adminId;
            _makes.Add(newMake);

            return newMake;

        }

        public Mdle AddModel(string modelName, int makeId, int adminId)
        {

            Mdle model = _models.Where(m => m.ModelName == modelName).FirstOrDefault();

            if (model == null)
            {
                Mdle newModel = new Mdle();
                newModel.MdleId = _models.Max(i => i.MdleId) + 1;
                newModel.ModelName = modelName;
                newModel.MakeId = makeId;
                newModel.Created = DateTime.Now;
                newModel.AdminId = adminId;
                _models.Add(newModel);

                return _models.Where(m => m.ModelName == modelName).First();

            }
            else return model;
            

        }

        public IEnumerable<SpecialAd> GetAllSpecials()
        {
            return _specials;
        }

        public SpecialAd AddSpecial(string title, string description)
        {
            SpecialAd special = new SpecialAd();

            special.SpecialAdId = _specials.Max(i => i.SpecialAdId) + 1;
            special.Title = title;
            special.Description = description;

            _specials.Add(special);

            return special;

        }

        public SpecialAd GetSpecialById(int id)
        {
            var result = _specials.ToList().Where(s => s.SpecialAdId == id).FirstOrDefault();
            return result;
        }

        public IEnumerable<VechicleViewModel> GetAllFeatured()
        {
            return (this).GetAll().Where(i => i.FeatureVehicle.Equals(true));
        }

        public void RemoveSpecial(int id)
        {
            _specials.Remove(GetSpecialById(id));
        }

        public VechicleViewModel AddVechicle(AddVehicleViewModel vechicle)
        {
            Inventory newInventory = new Inventory();

            newInventory.Id = _inventorys.Max(i => i.Id) + 1;
            newInventory.MdleId = GetAllModels().Where(m => m.ModelName == vechicle.Model).Single().MdleId;
            newInventory.TypId = GetAllTypes().Where(t => t.TypeName == vechicle.Type).Single().TypId;
            newInventory.BodyStyleId = GetAllBodyStyles().Where(b => b.BodyStyleName == vechicle.BodyStyle).Single().BodyStyleId;
            newInventory.Year = vechicle.Year;
            newInventory.TransmissionId = GetAllTransmissions().Where(t => t.TransmissionName == vechicle.Transmission).Single().TransmissionId;
            newInventory.ColorId = GetAllColors().Where(c => c.ColorName == vechicle.Color).Single().ColorId;
            newInventory.InteriorId = GetAllInteriors().Where(i => i.InteriorName == vechicle.Interior).Single().InteriorId;
            newInventory.Mileage = vechicle.Mileage;
            newInventory.VIN = vechicle.VIN;
            newInventory.MSRP = vechicle.MSRP;
            newInventory.SalesPrice = vechicle.SalesPrice;
            newInventory.Description = vechicle.Description;
            newInventory.PurchaseDate = null;
            newInventory.PurchasePrice = null;
            newInventory.SalesPersonId = null;



            if (vechicle.File != null && vechicle.File.ContentLength > 0)
            {

                string[] fileName = vechicle.File.FileName.Split('.');
                string newName = "inventory-" + newInventory.Id + "." + fileName.Last();


                string path = Path.Combine(HttpContext.Current.Server.MapPath("~/Images"),
                    Path.GetFileName(newName));

                vechicle.File.SaveAs(path);
                newInventory.Picture = newName;
            }
            _inventorys.Add(newInventory);

            return GetInventorysById(newInventory.Id);
        }

        public IEnumerable<Mdle> GetModelsForSpecificMake(string make)
        {
            var makesId = _makes.Where(m => m.MakeName == make).FirstOrDefault();
            if (makesId == null) return null;
            else return _models.Where(m => m.MakeId == makesId.MakeId);
        }

        public IEnumerable<VechicleViewModel> GetAllPurchasedVehicle()
        {

            return (this).GetAll().Where(p => p.StillAvailable == "No");
            
        }

        public IEnumerable<VechicleViewModel> GetAllNonPurchasedVehicle()
        {
            return (this).GetAll().Where(p => p.StillAvailable == "Yes");
        }

        public void ContactUs(ContactUs contactInfo)
        {
            ContactUs newContact = new ContactUs();
            newContact.ContactUsId = _contactUs.Max(id => id.ContactUsId) + 1;
            newContact.Name = contactInfo.Name;
            newContact.Phone = contactInfo.Phone;
            newContact.Email = contactInfo.Email;
            newContact.Message = contactInfo.Message;

            _contactUs.Add(newContact);


        }

        public IEnumerable<PurchaseType> GetAllPurchaseTypes()
        {
            return _purchaseTypes;
        }

        public void Purchased(PurchaseInfo purchase, int salesId)
        {


            var vechicle = _inventorys.Where(i => i.Id == purchase.VechicleId).First();
            vechicle.PurchasePrice = purchase.Purchase;
            vechicle.PurchaseTypeId = _purchaseTypes.Where(p => p.PurchaseTypeName == purchase.PurchaseType).Single().PurchaseTypeId;
            vechicle.FeatureVehicle = false;
            vechicle.PurchaseDate = DateTime.Now;
            vechicle.SalesPersonId = salesId;

            
        }

        public void EditVechicle(VechicleViewModel vechicle)
        {
           

            Inventory editVehicle = _inventorys.FirstOrDefault(p => p.Id == vechicle.InventoryId);
            _inventorys.Remove(editVehicle);
            editVehicle.Id = vechicle.InventoryId;
          
            editVehicle.MdleId = _models.FirstOrDefault(p => p.ModelName == vechicle.Model).MdleId;

            editVehicle.BodyStyleId = _bodyStyles.FirstOrDefault(p => p.BodyStyleName == vechicle.BodyStyle).BodyStyleId;
            editVehicle.ColorId = _colors.SingleOrDefault(p => p.ColorName == vechicle.Color).ColorId;
            editVehicle.TypId = _types.SingleOrDefault(p => p.TypeName == vechicle.Type).TypId;
            editVehicle.Year = vechicle.Year;
            editVehicle.TransmissionId = _transimissions.SingleOrDefault(p => p.TransmissionName == vechicle.Transmission).TransmissionId;
            editVehicle.InteriorId = _interiors.FirstOrDefault(p => p.InteriorName == vechicle.Interior).InteriorId;
            editVehicle.Mileage = vechicle.Mileage;
            editVehicle.VIN = vechicle.VIN;
            editVehicle.MSRP = vechicle.MSRP;
            editVehicle.SalesPrice = vechicle.SalesPrice;
            editVehicle.Description = vechicle.Description;

            editVehicle.FeatureVehicle = vechicle.FeatureVehicle;
            if (editVehicle.Picture != null)
            {
                var oldFile = editVehicle.Picture;
                string path = Path.Combine(HttpContext.Current.Server.MapPath("~/Images"),
                        Path.GetFileName(oldFile));
                File.Delete(path);
            }

            if (vechicle.File != null && vechicle.File.ContentLength > 0)
            {

                string[] fileName = vechicle.File.FileName.Split('.');
                string newName = "inventory-" + editVehicle.Id + "." + fileName.Last();


                string path = Path.Combine(HttpContext.Current.Server.MapPath("~/Images"),
                    Path.GetFileName(newName));

                vechicle.File.SaveAs(path);
                editVehicle.Picture = newName;
            }

            _inventorys.Add(editVehicle);


        }

        public void DeleteVehicle(int id)
        {
            Inventory item = _inventorys.Where(i => i.Id == id).FirstOrDefault();
            if (item != null)
            {
              
                string file = item.Picture;
                string path = Path.Combine(HttpContext.Current.Server.MapPath("~/Images"),
                        Path.GetFileName(file));
                File.Delete(path);

                _inventorys.Remove(item);
                
            }
        }
    }
}
