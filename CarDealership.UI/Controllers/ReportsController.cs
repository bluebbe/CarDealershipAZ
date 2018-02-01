using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarDealership.Data.Factories;
using CarDealership.Model.ViewModel;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using CarDealership.Data.Identity;
using CarDealership.Data.EF;

namespace CarDealership.UI.Controllers
{
    [Authorize(Roles = "admin")]
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sales()
        {

            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>() ;
            var rolManager = HttpContext.GetOwinContext().GetUserManager<RoleManager<AppRole>>();
           
            //var usersInRole = rolManager.Roles.Where(r => r.Name == "sales").FirstOrDefault().Users.ToList();
            List<UserFormVM> users = new List<UserFormVM>();
            foreach(var user in userManager.Users.ToList())

            {
               

                // user = userManager.FindById(userId.UserId);

                if (user.UserName != "admin" && user.UserName != "sales")
                {
                    UserFormVM item = new UserFormVM();
                    item.FirstName = user.UsersInfo.FirstName;
                    item.LastName = user.UsersInfo.LastName;
                    item.UserId = user.UsersInfo.Id.ToString();


                    users.Add(item);
                }



            }

            return View(users);
        }

        public ActionResult Inventory()
        {

            var vehicles = CarDearlershipRespoFacotory.GetRepository().GetAllNonPurchasedVehicle();

            var newVehicles = vehicles.Where(t => t.Type == "New").GroupBy(g => g.Model);
            var usedVehicles = vehicles.Where(t => t.Type == "Used").GroupBy(g => g.Model);

            InventoryReportsVM report = new InventoryReportsVM();
            report.New = new List<ReportViewModel>();
            report.Used = new List<ReportViewModel>();

            foreach (var model in newVehicles)
            {

                var makes = model.GroupBy(g => g.Make);

                foreach (var make in makes)
                {
                    var years = make.GroupBy(g => g.Year);

                    foreach (var year in years)

                    {
                        ReportViewModel listing = new ReportViewModel();

                        listing.Count = year.Count();
                        listing.StockValue = year.Sum(m => m.MSRP);
                        var item = year.Distinct().First();

                        listing.Make = item.Make;
                        listing.Model = item.Model;
                        listing.Year = item.Year;
                        report.New.Add(listing);

                    }


                }

            }


            foreach (var model in usedVehicles)
            {

                var makes = model.GroupBy(g => g.Make);

                foreach (var make in makes)
                {
                    var years = make.GroupBy(g => g.Year);

                    foreach (var year in years)

                    {
                        ReportViewModel listing = new ReportViewModel();

                        listing.Count = year.Count();
                        listing.StockValue = year.Sum(m => m.MSRP);
                        var item = year.Distinct().First();

                        listing.Make = item.Make;
                        listing.Model = item.Model;
                        listing.Year = item.Year;
                        report.Used.Add(listing);

                    }


                }

            }

            return View(report);
        }
    }
}