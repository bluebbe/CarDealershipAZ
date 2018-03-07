using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarDealership.Model.ViewModel;
using CarDealership.Data.Factories;

namespace CarDealership.UI.Controllers
{
    [AllowAnonymous]
    public class InventoryController : Controller
    {
        // GET: Inventory
        [HttpGet]
        public ActionResult Details(int id)
        {
            VechicleViewModel repo = CarDearlershipRespoFacotory.GetRepository().GetInventorysById(id);

            repo.Picture = AZBlobStorage.Location() + repo.Picture;

            return View(repo);
        }


        [HttpPost]
        public ActionResult Details(string vin)
        {

            return RedirectToAction("Contact", "Homme", vin);
        }

        [HttpGet]
        public ActionResult New()
        {
            VechicleSearchViewModel search = new VechicleSearchViewModel();
            search.PriceOptions = new List<int>();
            search.YearOptions = new List<int>();

            for (int multiple = 1; multiple < 6; multiple++)
            {
                search.PriceOptions.Add(10000 * multiple);


            }

            for (int step = 10; step < 50; step += 10)
            {
                search.YearOptions.Add(1980 + step);

            }


            return View(search);
        }

        [HttpGet]

        public ActionResult Used()
        {
            VechicleSearchViewModel search = new VechicleSearchViewModel();
            search.PriceOptions = new List<int>();
            search.YearOptions = new List<int>();

            for (int multiple = 1; multiple < 6; multiple++)
            {
                search.PriceOptions.Add(10000 * multiple);


            }

            for (int step = 10; step < 50; step += 10)
            {
                search.YearOptions.Add(1980 + step);

            }


            return View(search);
        }
    }
}