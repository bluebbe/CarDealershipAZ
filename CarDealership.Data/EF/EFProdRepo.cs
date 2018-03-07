using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Data.Interfaces;
using CarDealership.Model.DataModel;
using CarDealership.Model.ViewModel;
using System.IO;
using System.Web.Hosting;
using Microsoft.AspNet.Identity.EntityFramework;
using CarDealership.Data.Identity;
using Microsoft.AspNet.Identity;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CarDealership.Data;
namespace CarDealership.Data.EF
{
    public class EFProdRepo : IdentityDbContext<AppUser>, ICarDealershipRepository
    {
        public DbSet<BodyStyle> BodyStyles { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ContactUs> ContactUs{ get; set; }
        public DbSet<Interior> Interiors { get; set; }
        public DbSet<Inventory> Inventorys { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Mdle> Models { get; set; }
        public DbSet<PurchaseType> PurchaseTypes { get; set; }
        public DbSet<SpecialAd> Specials { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<Typ> Typs { get; set; }
        //public DbSet<SalesPerson> SalePersons { get; set; }
        public DbSet<UserInfo> UsersInfo { get; set; }





        public EFProdRepo() : base("CarDealership")
        {
            
        }

        public IEnumerable<BodyStyle> GetAllBodyStyles()
        {
            return BodyStyles;
        }

        public IEnumerable<Color> GetAllColors()
        {
            return Colors;
        }

        public IEnumerable<Interior> GetAllInteriors()
        {
            return Interiors;
        }

        public IEnumerable<Make> GetAllMakes()
        {

            return Makes ;
        }

        public IEnumerable<Mdle> GetAllModels()
        {
            return Models.ToList();
        }

        public IEnumerable<Transmission> GetAllTransmissions()
        {
            return Transmissions;
        }

        public IEnumerable<Typ> GetAllTypes()
        {
            return Typs;
        }

        public IEnumerable<VechicleViewModel> GetAll()
        {
            List<VechicleViewModel> repo = new List<VechicleViewModel>();

            return Inventorys.Include("Mdles").Include("Typs").Include("BodyStyles")
                .Include("Transmissions").Include("Colors").Include("Interiors")
                .Include("PurchaseTypes").Select(i => new VechicleViewModel
                {
                    InventoryId = i.Id,
                    Make = i.Mdles.Makes.MakeName,
                    Model = i.Mdles.ModelName,
                    Type = i.Typs.TypeName,
                    BodyStyle = i.BodyStyles.BodyStyleName,
                    Year = i.Year,
                    Transmission = i.Transmissions.TransmissionName,
                    Color = i.Colors.ColorName,
                    Interior = i.Interiors.InteriorName,
                    Mileage = i.Mileage,
                    VIN = i.VIN,
                    MSRP = i.MSRP,
                    SalesPrice = i.SalesPrice,
                    Description = i.Description,
                    Picture = i.Picture,
                    FeatureVehicle = i.FeatureVehicle,
                    StillAvailable = i.PurchaseTypeId == null ? "Yes" : "No",
                    SalesId = i.SalesPersonId,
                    PurchasedPrice = i.PurchasePrice,
                    PurhasedDate = i.PurchaseDate
                    

                });

            
        }

        public IEnumerable<SpecialAd> GetAllSpecials()
        {
         

            List<SpecialAd> ads = new List<SpecialAd>();


            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString =
                     Settings.GetConnectionString();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "RetreiveAds";

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        SpecialAd ad = new SpecialAd();
                        ad.SpecialAdId = (int)dr["SpecialAdId"];
                        ad.Title = dr["Title"].ToString();
                        ad.Description = dr["Description"].ToString();
                        ads.Add(ad);
                       
                    }
                }

                
            }

            return ads;
           
        }

        public IEnumerable<VechicleViewModel> GetAllFeatured()
        {
            return GetAll().Where(i => i.FeatureVehicle.Equals(true));
        }

        public IEnumerable<Mdle> GetModelsForSpecificMake(string make)
        {
            int makesId = Makes.Where(p => p.MakeName == make).FirstOrDefault().MakeId;

            return Models.Where(m => m.MakeId == makesId);
        }

        public IEnumerable<VechicleViewModel> GetAllPurchasedVehicle()
        {
            return (this).GetAll().Where(p => p.StillAvailable == "No");
        }

        public IEnumerable<VechicleViewModel> GetAllNonPurchasedVehicle()
        {
            return (this).GetAll().Where(p => p.StillAvailable == "Yes");
        }

        public IEnumerable<PurchaseType> GetAllPurchaseTypes()
        {
            return PurchaseTypes;
        }

        public BodyStyle GetBodyStyleById(int id)
        {
            return BodyStyles.Where(i => i.BodyStyleId == id).FirstOrDefault();
        }

        public Color GetColorsById(int id)
        {
            return Colors.Where(c => c.ColorId == id).FirstOrDefault();
        }

        public Interior GetInteriorsById(int id)
        {
            return Interiors.Where(i => i.InteriorId == id).FirstOrDefault();
        }

        public Make GetMakesById(int id)
        {
            return Makes.Where(m => m.MakeId == id).FirstOrDefault();
        }

        public Mdle GetModelsById(int id)
        {
            return Models.Where(m => m.MdleId == id).FirstOrDefault();
        }

        public Transmission GetTransmissionsById(int id)
        {
            return Transmissions.Where(i => i.TransmissionId == id).FirstOrDefault();
        }

        public Typ GetTypesById(int id)
        {
            return Typs.Where(i => i.TypId == id).FirstOrDefault();
        }

        public VechicleViewModel GetInventorysById(int id)
        {
            VechicleViewModel temp = Inventorys.Where(p => p.Id == id).Include("Mdles").Include("Typs").Include("BodyStyles")
                .Include("Transmissions").Include("Colors").Include("Interiors")
                .Include("PurchaseTypes").Select(i => new VechicleViewModel
                {
                    InventoryId = i.Id,
                    Make = i.Mdles.Makes.MakeName,
                    Model = i.Mdles.ModelName,
                    Type = i.Typs.TypeName,
                    BodyStyle = i.BodyStyles.BodyStyleName,
                    Year = i.Year,
                    Transmission = i.Transmissions.TransmissionName,
                    Color = i.Colors.ColorName,
                    Interior = i.Interiors.InteriorName,
                    Mileage = i.Mileage,
                    VIN = i.VIN,
                    MSRP = i.MSRP,
                    SalesPrice = i.SalesPrice,
                    Description = i.Description,
                    Picture = i.Picture,
                    FeatureVehicle = i.FeatureVehicle,
                    StillAvailable = i.PurchaseTypeId == null ? "Yes" : "No"


                }).FirstOrDefault();

            return temp;
        }

        public SpecialAd GetSpecialById(int id)
        {
            return Specials.Where(i => i.SpecialAdId == id).FirstOrDefault();
        }

        public Make AddMake(string makeName, int adminId)
        {

          
           
            Make newMake = new Make();
            newMake.MakeId = Makes.Max(i => i.MakeId) + 1;
            newMake.MakeName = makeName;
            newMake.AdminId = adminId;
            newMake.Created = DateTime.Now;
            Makes.Add(newMake);
            (this).SaveChanges();
            return newMake;
        }

        public Mdle AddModel(string modelName, int makeId, int adminId)
        {

            Mdle model = Models.Where(m => m.ModelName == modelName).FirstOrDefault();

            if (model == null)
            {
                Mdle newModel = new Mdle();
                newModel.MdleId = Models.Max(i => i.MdleId) + 1;
                newModel.ModelName = modelName;
                newModel.MakeId = makeId;
                newModel.Created = DateTime.Now;
                newModel.AdminId = adminId;
                Models.Add(newModel);
                (this).SaveChanges();
                return Models.Where(m => m.ModelName == modelName).First();

            }
            else return model;
        }

        public SpecialAd AddSpecial(string title, string description)
        {
            SpecialAd special = new SpecialAd();

            special.SpecialAdId = Specials.Max(i => i.SpecialAdId) + 1;
            special.Title = title;
            special.Description = description;

            Specials.Add(special);
            (this).SaveChanges();
            return special;
        }

        public VechicleViewModel AddVechicle(AddVehicleViewModel vechicle)
        {
           
            Inventory newInventory = new Inventory();
            Storage storage = new Storage();
            newInventory.Id = Inventorys.Max(i => i.Id) + 1;
            newInventory.Mdles = GetAllModels().First(m => m.Makes.MakeName == vechicle.Make);
            newInventory.MdleId = newInventory.Mdles.MdleId;
            newInventory.TypId = GetAllTypes().SingleOrDefault(t => t.TypeName == vechicle.Type).TypId;
            newInventory.BodyStyleId = GetAllBodyStyles().SingleOrDefault(b => b.BodyStyleName == vechicle.BodyStyle).BodyStyleId;
            newInventory.Year = vechicle.Year;
            newInventory.TransmissionId = GetAllTransmissions().Where(t => t.TransmissionName == vechicle.Transmission).Single().TransmissionId;
            newInventory.ColorId = GetAllColors().Where(c => c.ColorName == vechicle.Color).Single().ColorId;
            newInventory.InteriorId = GetAllInteriors().Where(i => i.InteriorName == vechicle.Interior).Single().InteriorId;
            newInventory.Mileage = vechicle.Mileage;
            newInventory.VIN = vechicle.VIN;
            newInventory.MSRP = vechicle.MSRP;
            newInventory.SalesPrice = vechicle.SalesPrice;
            newInventory.Description = vechicle.Description;
           
            if (vechicle.File != null && vechicle.File.ContentLength > 0)
            {
                newInventory.PictureData =  ConvertPostedFileToByteArray(vechicle.File);

                string[] fileName = vechicle.File.FileName.Split('.');
                string newName = "inventory-" + newInventory.Id + "." + fileName.Last();


                //string path = Path.Combine(HttpContext.Current.Server.MapPath("~/Images"),
                //    Path.GetFileName(newName));

                string storeBlogFile = storage.SavingImage(newInventory.PictureData,newName);
              

                //vechicle.File.SaveAs(path);

                newInventory.Picture = newName;
                //newInventory.PictureURL = storage.UriFor(storeGUID);
            }

            Inventorys.Add(newInventory);
           
            (this).SaveChanges();


            return GetInventorysById(newInventory.Id);
        }

        public void RemoveSpecial(int id)
        {

           
            SpecialAd item = GetSpecialById(id);
                if (item != null)
            {
                Specials.Remove(item);
                (this).SaveChanges();
            }
         
          
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

        void ICarDealershipRepository.ContactUs(ContactUs contactInfo)
        {
            ContactUs newContact = new ContactUs();
            newContact.ContactUsId = ContactUs.Max(id => id.ContactUsId) + 1;
            newContact.Name = contactInfo.Name;
            newContact.Phone = contactInfo.Phone;
            newContact.Email = contactInfo.Email;
            newContact.Message = contactInfo.Message;

            ContactUs.Add(newContact);
        }

        public void Purchased(PurchaseInfo purchase, int salesId)
        {
            var vechicle = Inventorys.Where(i => i.Id == purchase.VechicleId).First();
            vechicle.PurchasePrice = purchase.Purchase;
            vechicle.PurchaseTypeId = Inventorys.Where(p => p.PurchaseTypes.PurchaseTypeName == purchase.PurchaseType).First().PurchaseTypeId;
            vechicle.FeatureVehicle = false;
            vechicle.PurchaseDate = DateTime.Now;
            vechicle.SalesPersonId = salesId;   
            (this).SaveChanges();
        }

        public void EditVechicle(VechicleViewModel vechicle)
        {
            Storage storage = new Storage();

            var editVehicle = Inventorys.Include("Mdles").Include("Typs").Include("BodyStyles")
                .Include("Transmissions").Include("Colors").Include("Interiors")
                .Include("PurchaseTypes").FirstOrDefault(p => p.Id == vechicle.InventoryId);
            editVehicle.Id = vechicle.InventoryId;
            editVehicle.Mdles.MakeId = Makes.FirstOrDefault(p => p.MakeName == vechicle.Make).MakeId;
            editVehicle.MdleId = Models.FirstOrDefault(p => p.ModelName == vechicle.Model).MdleId;

            editVehicle.BodyStyleId = BodyStyles.FirstOrDefault(p => p.BodyStyleName == vechicle.BodyStyle).BodyStyleId;
            editVehicle.ColorId = Colors.SingleOrDefault(p => p.ColorName == vechicle.Color).ColorId;
            editVehicle.TypId = Typs.SingleOrDefault(p => p.TypeName == vechicle.Type).TypId;
            editVehicle.Year = vechicle.Year;
            editVehicle.TransmissionId = Transmissions.SingleOrDefault(p => p.TransmissionName == vechicle.Transmission).TransmissionId;
            editVehicle.InteriorId = Interiors.FirstOrDefault(p => p.InteriorName == vechicle.Interior).InteriorId;
            editVehicle.Mileage = vechicle.Mileage;
            editVehicle.VIN = vechicle.VIN;
            editVehicle.MSRP = vechicle.MSRP;
            editVehicle.SalesPrice = vechicle.SalesPrice;
            editVehicle.Description = vechicle.Description;

            editVehicle.FeatureVehicle = vechicle.FeatureVehicle;
            if (editVehicle.Picture != null)
            {

                storage.DeleteImage(editVehicle.Picture);
            //    var oldFile = editVehicle.Picture;
                
            //string path = Path.Combine(HttpContext.Current.Server.MapPath("~/Images"),
            //        Path.GetFileName(oldFile));
            //File.Delete(path);
            }

            if (vechicle.File != null && vechicle.File.ContentLength > 0)
            {

                editVehicle.PictureData = ConvertPostedFileToByteArray(vechicle.File);

                string[] fileName = vechicle.File.FileName.Split('.');
                string newName = "inventory-" + editVehicle.Id + "." + fileName.Last();

                string storeBlogFile = storage.SavingImage(editVehicle.PictureData, newName);
                //string path = Path.Combine(HttpContext.Current.Server.MapPath("~/Images"),
                //    Path.GetFileName(newName));

                //vechicle.File.SaveAs(path);
                editVehicle.Picture = newName;
                
            }

            
       

            (this).SaveChanges();
            
        }

        public void DeleteVehicle(int id)
        {
            Storage storage = new Storage();
            Inventory item = Inventorys.Where(i => i.Id == id).FirstOrDefault();
            if (item != null)
            {
                //var file = item.Picture;
                //string path = Path.Combine(HttpContext.Current.Server.MapPath("~/Images"),
                //        Path.GetFileName(file));
                //File.Delete(path);

                storage.DeleteImage(item.Picture);

                Inventorys.Remove(item);
                (this).SaveChanges();
            }
        }

        private byte[] ConvertPostedFileToByteArray(HttpPostedFileBase file)
        {
            byte[] imageByte = null;
            BinaryReader rdr = new BinaryReader(file.InputStream);
            imageByte = rdr.ReadBytes((int)file.ContentLength);
            return imageByte;
        }
    }
}
