using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web.Http.Cors;
using CarDealership.Data.Factories;
using CarDealership.Model.ViewModel;
using CarDealership.Model.DataModel;

namespace CarDealership.UI.ControllersAPI
{
    [EnableCors(origins: "http://localhost:50084", headers: "*", methods: "*")]
    public class CarDearlershipAPIController : ApiController
    {
        [Route("vehicles")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllVechicles()
        {

            var repo = CarDearlershipRespoFacotory.GetRepository();
            List<VechicleViewModel> listings = repo.GetAll().ToList();


            return Json(listings, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }



        [Route("vehicle/search/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetVechicleById(int id)
        {
            var repo = CarDearlershipRespoFacotory.GetRepository();
            VechicleViewModel listings = repo.GetInventorysById(id);


            return Json(listings, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }

        [Route("vehicle/year/search/{year}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetVechicleByYear(int year)
        {
            var repo = CarDearlershipRespoFacotory.GetRepository();
            List<VechicleViewModel> listings = repo.FilterInventoryByYear(year).ToList();


            return Json(listings, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }

        [Route("vehicle/make/search/{makeName}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetVechicleByMake(string makeName)
        {
            var repo = CarDearlershipRespoFacotory.GetRepository();
            List<VechicleViewModel> listings = repo.FilterInventoryByMake(makeName).ToList();


            return Json(listings, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }


        [Route("vehicle/model/search/{modelName}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetVechicleByModel(string modelName)
        {
            var repo = CarDearlershipRespoFacotory.GetRepository();
            List<VechicleViewModel> listings = repo.FilterInventoryByModel(modelName).ToList();


            return Json(listings, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }
        [Route("specials")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllSpecials()
        {
            var repo = CarDearlershipRespoFacotory.GetRepository();
            List<SpecialAd> listings = repo.GetAllSpecials().ToList();


            return Json(listings, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }



        [Route("makes")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllMakes()
        {
            var repo = CarDearlershipRespoFacotory.GetRepository();
            List<Make> listings = repo.GetAllMakes().ToList();


            return Json(listings, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

        }

        
        [Route("models/{make}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GiveAllModelsForSpecificMake(string make)
        {
            IEnumerable<Mdle> models = CarDearlershipRespoFacotory.GetRepository().GetModelsForSpecificMake(make);
            return Json(models, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }


        [Route("sales/search")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetSales([FromUri] int parm,[FromUri] string fromDate, [FromUri] string toDate)
        {
           
         
            
            var purchased = CarDearlershipRespoFacotory.GetRepository().GetAllPurchasedVehicle();

            if (fromDate != null)
            { DateTime fDate = DateTime.Parse(fromDate);
                purchased = purchased.Where(df => df.PurhasedDate >= fDate);
            }

            if (toDate != null)
            {
                DateTime tDate = DateTime.Parse(toDate).AddDays(1);
                purchased = purchased.Where(df => df.PurhasedDate <= tDate);
            }
            
            List<TotalSalesVM> totalSales = new List<TotalSalesVM>();
           
           
            if(parm != 0)
            {
                purchased = purchased.Where(u => u.SalesId == parm);
                TotalSalesVM user = new TotalSalesVM();

                user.Id = parm;
                user.TotalSales = purchased.Sum(m => m.PurchasedPrice).Value;
                user.TotalCount = purchased.Count();

                totalSales.Add(user);
            }
            else
            {
                var salesPeople = purchased.Select(u => new { u.SalesId }).Distinct().ToList();

                foreach (var person in salesPeople)
                {
                    TotalSalesVM user = new TotalSalesVM();

                    user.Id = person.SalesId.Value;
                    user.TotalSales = purchased.Where(u => u.SalesId == user.Id).Sum(m => m.PurchasedPrice).Value;
                    user.TotalCount = purchased.Where(u => u.SalesId == user.Id).Count();

                    totalSales.Add(user);

                }


            }





            return Json(totalSales, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }








        [Route("inventory/new/search")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetSearchResult([FromUri]VechicleSearchParmViewMode parm)
        {
            var inventory = CarDearlershipRespoFacotory.GetRepository().GetAllNonPurchasedVehicle();


            if (parm.Type != null)
            { inventory = inventory.Where(t => t.Type == parm.Type); }




            if (parm.StillAvailable == true)
            {
                inventory = inventory.Where(a => a.StillAvailable == "Yes");


            }
            if (parm.StillAvailable == false)
            {
                inventory = inventory.Where(a => a.StillAvailable == "No");
            }

            

            if (parm.KeyWords == null) parm.KeyWords = "";

            string[] keyword = parm.KeyWords.Split(' ');

            List<VechicleViewModel> searchInventoryPerKeyword = new List<VechicleViewModel>();


            foreach (var word in keyword)
            {

                var modelSearch = inventory;
                var makeSearch = inventory;


                if (word != "")
                {
                    modelSearch = modelSearch.Where(m => m.Model.Equals(word, StringComparison.OrdinalIgnoreCase));
                    makeSearch = makeSearch.Where(m => m.Make.Equals(word, StringComparison.OrdinalIgnoreCase));
                }




                if (parm.MinYear != null)
                {
                    modelSearch = modelSearch.Where(yMin => yMin.Year > parm.MinYear);
                    makeSearch = makeSearch.Where(yMin => yMin.Year > parm.MinYear);

                }
                if (parm.MaxYear != null)

                {
                    modelSearch = modelSearch.Where(yMax => yMax.Year < parm.MaxYear);
                    makeSearch = makeSearch.Where(yMax => yMax.Year < parm.MaxYear);

                }
                if (parm.MinPrice != null)
                {
                    modelSearch = modelSearch.Where(pMin => pMin.SalesPrice > parm.MinPrice);
                    makeSearch = makeSearch.Where(pMin => pMin.SalesPrice > parm.MinPrice);
                }

                if (parm.MaxPrice != null)
                {
                    modelSearch = modelSearch.Where(pMax => pMax.SalesPrice < parm.MaxPrice);
                    makeSearch = makeSearch.Where(pMax => pMax.SalesPrice < parm.MaxPrice);
                }



                searchInventoryPerKeyword.AddRange(modelSearch);
                searchInventoryPerKeyword.AddRange(makeSearch);

            }

            var output = searchInventoryPerKeyword.

                         Select(s => new { s.InventoryId, s.BodyStyle, s.Color, s.Description, s.File,
                             s.Interior, s.Make, s.Model, s.Mileage, s.MSRP, s.Picture, s.SalesPrice,s.Transmission, s.Type,s.VIN, s.Year }).Distinct() ;
            var output2 = output.OrderByDescending(p => p.SalesPrice).Take(20);

            return Json(output, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }
    }
}

