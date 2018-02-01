using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarDealership.Model.ViewModel;
using CarDealership.Data.Factories;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using CarDealership.Data.Identity;

namespace CarDealership.UI.Controllers
{
    [Authorize(Roles = "admin,sales")]
    public class SalesController : Controller
    {
        // GET: Sales
        [HttpGet]
        public ActionResult Index()
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
        public ActionResult Purchase(int id)
        {

            PurchaseViewModel purchase = new PurchaseViewModel();
            purchase.PurchasingVechicle = CarDearlershipRespoFacotory.GetRepository().GetInventorysById(id);
            purchase.PurchaseType = CarDearlershipRespoFacotory.GetRepository().GetAllPurchaseTypes();
            return View(purchase);
        }

        [HttpPost]
        public ActionResult Purchase(PurchaseInfo purchaseInfo)
        {
            var salesId = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>()
                .FindById(User.Identity.GetUserId()).UsersInfo.Id;
            CarDearlershipRespoFacotory.GetRepository().Purchased(purchaseInfo,salesId);


            return RedirectToAction("Index", "Sales");
        }
    }
}