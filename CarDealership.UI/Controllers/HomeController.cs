using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarDealership.Data.Factories;
using CarDealership.Model.DataModel;
using CarDealership.Model.ViewModel;


namespace CarDealership.UI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var repo = CarDearlershipRespoFacotory.GetRepository();

            HomePageViewModel homeView = new HomePageViewModel();

            homeView.Featured = repo.GetAllFeatured().ToList();
            homeView.Specials = repo.GetAllSpecials().ToList();

            foreach(var vehicle in homeView.Featured)
            {
                vehicle.Picture = AZBlobStorage.Location() + vehicle.Picture;
            }

            return View(homeView);
        }

        [HttpGet]
        public ActionResult Contact(string vin)
        {

            return View(new ContactUsViewModel { VIN = vin });
        }

        [HttpGet]
        public ActionResult Specials()
        {
            List<SpecialAd> special = CarDearlershipRespoFacotory.GetRepository().GetAllSpecials().ToList();

            
            return View(special);
        }

        [HttpPost]
        public ActionResult Contact(ContactInfoViewModel contact)
        {

            CarDearlershipRespoFacotory.GetRepository().ContactUs(
                new ContactUs { Name = contact.Name, Phone = contact.Phone, Email = contact.Email, Message = contact.Message });

            return RedirectToAction("Index", "Home");
        }
    }


}