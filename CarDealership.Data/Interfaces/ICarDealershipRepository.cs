using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Model.DataModel;
using CarDealership.Model.ViewModel;

namespace CarDealership.Data.Interfaces
{
    public interface ICarDealershipRepository
    {
        IEnumerable<BodyStyle> GetAllBodyStyles();
        IEnumerable<Color> GetAllColors();
        IEnumerable<Interior> GetAllInteriors();
        IEnumerable<Make> GetAllMakes();
        IEnumerable<Mdle> GetAllModels();
        IEnumerable<Transmission> GetAllTransmissions();
        IEnumerable<Typ> GetAllTypes();
        IEnumerable<VechicleViewModel> GetAll();
        IEnumerable<SpecialAd> GetAllSpecials();
        IEnumerable<VechicleViewModel> GetAllFeatured();
        IEnumerable<Mdle> GetModelsForSpecificMake(string make);
        IEnumerable<VechicleViewModel> GetAllPurchasedVehicle();
        IEnumerable<VechicleViewModel> GetAllNonPurchasedVehicle();
        IEnumerable<PurchaseType> GetAllPurchaseTypes();
       

        BodyStyle GetBodyStyleById(int id);
        Color GetColorsById(int id);
        Interior GetInteriorsById(int id);
        Make GetMakesById(int id);
        Mdle GetModelsById(int id);
        Transmission GetTransmissionsById(int id);
        Typ GetTypesById(int id);
        VechicleViewModel GetInventorysById(int id);
        SpecialAd GetSpecialById(int id);


        Make AddMake(string makeName, int adminId);
        Mdle AddModel(string modelName,int makeId,int adminId);
        SpecialAd AddSpecial(string title, string description);
        VechicleViewModel AddVechicle(AddVehicleViewModel vechicle);
        void EditVechicle(VechicleViewModel vechicle);
        void DeleteVehicle(int id);
        void RemoveSpecial(int id);


        IEnumerable<VechicleViewModel> FilterInventoryByMake(string makeName);
        IEnumerable<VechicleViewModel> FilterInventoryByModel(string modelName);
        IEnumerable<VechicleViewModel> FilterInventoryByYear(int year);


        void ContactUs(ContactUs contactInfo);
        void Purchased(PurchaseInfo purchase, int salesId);
      
      
    }
}
