using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarDealership.Model.DataModel;
using CarDealership.Model.ViewModel;
using CarDealership.Data.Factories;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using CarDealership.Data.Identity;

namespace CarDealership.UI.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Specials()
        {
            var special = CarDearlershipRespoFacotory.GetRepository().GetAllSpecials();

            return View(special);

        }
        [HttpPost]
        public ActionResult SpecialsSave(string title, string description)

        {
            CarDearlershipRespoFacotory.GetRepository().AddSpecial(title, description);

            return RedirectToAction("Specials");
        }

        [HttpPost]
        public ActionResult SpecialsDelete(int specialId)

        {
            CarDearlershipRespoFacotory.GetRepository().RemoveSpecial(specialId);

            return RedirectToAction("Specials");
        }

        [HttpGet]
        public ActionResult AddVehicle()
        {
            VechicleFormViewModel form = new VechicleFormViewModel();
            form.BodyStyle = CarDearlershipRespoFacotory.GetRepository().GetAllBodyStyles();
            form.Color = CarDearlershipRespoFacotory.GetRepository().GetAllColors();
            form.Interior = CarDearlershipRespoFacotory.GetRepository().GetAllInteriors();
            form.Transmission = CarDearlershipRespoFacotory.GetRepository().GetAllTransmissions();
            form.Types = CarDearlershipRespoFacotory.GetRepository().GetAllTypes();
            form.Make = CarDearlershipRespoFacotory.GetRepository().GetAllMakes();

            return View(form);
        }

        [HttpPost]
        public ActionResult AddVehicle(AddVehicleViewModel addVechicle)
        {

            var addedVechicle = CarDearlershipRespoFacotory.GetRepository().AddVechicle(addVechicle);

            return RedirectToAction("EditVehicle", "Admin", new { id = addedVechicle.InventoryId });
        }

        [HttpGet]
        public ActionResult EditVehicle(int id)
        {
            EditVehicleVM editVehicle = new EditVehicleVM();

            editVehicle.selectVehicle = CarDearlershipRespoFacotory.GetRepository().GetInventorysById(id);

            editVehicle.form = new VechicleFormViewModel();
            editVehicle.form.BodyStyle = CarDearlershipRespoFacotory.GetRepository().GetAllBodyStyles();
            editVehicle.form.Color = CarDearlershipRespoFacotory.GetRepository().GetAllColors();
            editVehicle.form.Interior = CarDearlershipRespoFacotory.GetRepository().GetAllInteriors();
            editVehicle.form.Transmission = CarDearlershipRespoFacotory.GetRepository().GetAllTransmissions();
            editVehicle.form.Types = CarDearlershipRespoFacotory.GetRepository().GetAllTypes();
            editVehicle.form.Make = CarDearlershipRespoFacotory.GetRepository().GetAllMakes();
            editVehicle.form.Model = CarDearlershipRespoFacotory.GetRepository().GetModelsForSpecificMake(editVehicle.selectVehicle.Make);

            return View(editVehicle);
        }


        [HttpPost]
        public ActionResult EditVehicle(VechicleViewModel editVechicle, string submit)
        {

            switch (submit)
            {
                case "Save":
                    CarDearlershipRespoFacotory.GetRepository().EditVechicle(editVechicle);
                    break;
                case "Delete":
                    CarDearlershipRespoFacotory.GetRepository().DeleteVehicle(editVechicle.InventoryId);
                    break;

            }



            return RedirectToAction("Vehicles");
        }






        public ActionResult Makes()
        {

            var makes = CarDearlershipRespoFacotory.GetRepository().GetAllMakes();
            List<MakesVM> views = new List<MakesVM>();
            var usrManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();


            foreach (var item in makes)
            {
                MakesVM view = new MakesVM();
                view.Created = item.Created;
                view.MakeId = item.MakeId;
                view.MakeName = item.MakeName;
                view.User = usrManager.Users.Where(p => p.UsersInfo.Id == item.AdminId).First().Email;

                views.Add(view);

            }



            return View(views);
        }

        [HttpPost]
        public ActionResult Makes(string make)
        {


            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser> > ();
            
            int adminId = userManager.FindById(User.Identity.GetUserId()).UsersInfo.Id;


            Make newListing = CarDearlershipRespoFacotory.GetRepository().AddMake(make,adminId);



            return RedirectToAction("makes", "admin");
        }



        public ActionResult Models()
        {
            var usrManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();
          

            ModelMakeViewModel list = new ModelMakeViewModel();

            list.ModelList = new List<ModelsVM>();
            list.MakeList = CarDearlershipRespoFacotory.GetRepository().GetAllMakes();
            var models = CarDearlershipRespoFacotory.GetRepository().GetAllModels();

            foreach (var model in models)
            {
                ModelsVM inventory = new ModelsVM();
                inventory.Created = model.Created;
                inventory.MakeId = model.MakeId;
                inventory.ModelName = model.ModelName;
                inventory.MdleId = model.MdleId;
                inventory.User = usrManager.Users.Where(p => p.UsersInfo.Id == model.AdminId).First().Email;
                inventory.MakeName = CarDearlershipRespoFacotory.GetRepository().GetMakesById(model.MakeId).MakeName;  //model.Makes.MakeName;
                list.ModelList.Add(inventory);

            }
           

            return View(list);
        }

        [HttpPost]
        public ActionResult Models(string model, string make)
        {

            int makeId = CarDearlershipRespoFacotory.GetRepository().GetAllMakes().Where(m => m.MakeName == make).FirstOrDefault().MakeId;
            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();

            int adminId = userManager.FindById(User.Identity.GetUserId()).UsersInfo.Id;

            Mdle newListing = CarDearlershipRespoFacotory.GetRepository().AddModel(model, makeId,adminId);

            return RedirectToAction("models", "admin");
        }


        public ActionResult Vehicles()
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

        public ActionResult Users()
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();

            List<UserFormVM> listofUsers = new List<UserFormVM>();
            var users = userManager.Users.ToList();

            foreach (var item in users)
            {
                if (item.UserName != "admin" && item.UserName != "sales")
                {
                    UserFormVM user = new UserFormVM();
                    var role = userManager.GetRoles(item.Id);
                    user.FirstName = (item.UsersInfo != null) ? item.UsersInfo.FirstName : "No FirstName";
                    user.LastName = (item.UsersInfo != null) ? item.UsersInfo.LastName : "No LastName";
                    user.Email = (item.Email != null) ? item.Email : item.UserName;
                    user.UserId = item.Id;

                    if (item.UsersInfo.IsAccountEnabled == true)
                    {
                        string modifyString = role[0];



                        user.Role = modifyString.Substring(0, 1).ToUpper() + modifyString.Substring(1);
                    }
                    else user.Role = "Disabled";


                    listofUsers.Add(user);


                }



            }




            return View(listofUsers);
        }

        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(UserFormVM form)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();


            var newUser = new AppUser
            {
                UserName = form.Email,
                UsersInfo = new UserInfo { FirstName = form.FirstName, LastName = form.LastName, IsAccountEnabled = (form.Role == "Disabled") ? false : true },
                Email = form.Email


            };

            userManager.Create(newUser, form.Password);

            var user = userManager.FindByEmail(form.Email);
            if (form.Role == "Disabled")
            {
                userManager.AddToRole(user.Id, "sales");

            }
            else
            {

                userManager.AddToRole(user.Id, form.Role.ToLower());
            }


            return RedirectToAction("EditUser", new { id = user.Id });


        }

        public ActionResult EditUser(string id)

        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();


            var user = userManager.FindById(id);

            UserFormVM editForm = new UserFormVM();

            editForm.Email = user.Email;
            editForm.FirstName = user.UsersInfo.FirstName;
            editForm.LastName = user.UsersInfo.LastName;
            editForm.UserId = user.Id;


            editForm.Role = user.UsersInfo.IsAccountEnabled == false ? "Disabled" : userManager.GetRoles(user.Id)[0];
            editForm.RolesAvailable = new List<string> { "Disabled", "Sales", "Admin" };


            return View(editForm);
        }

        [HttpPost]
        public ActionResult EditUser(UserFormVM form)

        {

            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();


            var user = userManager.FindById(form.UserId);


            var oldRoleName = userManager.GetRoles(user.Id)[0];


            if (form.Role == "Disabled")
            {
                user.UsersInfo.IsAccountEnabled = false;



            }
            else
            {


                user.UsersInfo.IsAccountEnabled = true;
                if (oldRoleName != form.Role.ToLower())
                {
                    userManager.RemoveFromRole(user.Id, oldRoleName);
                    userManager.AddToRole(user.Id, form.Role.ToLower());
                }

            }

            user.UserName = form.Email;
            user.Email = form.Email;
           
            user.UsersInfo.FirstName = form.FirstName;
            user.UsersInfo.LastName = form.LastName;

            userManager.Update(user);
            if (form.Password != null)
            {
                userManager.RemovePassword(user.Id);
                userManager.AddPassword(user.Id, form.Password);


            }


            return RedirectToAction("users", "admin");
        }
    }
}