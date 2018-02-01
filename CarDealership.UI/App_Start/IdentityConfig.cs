using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;  //Missingg Namaspace to resolve context.Get Issue
using Microsoft.AspNet.Identity.EntityFramework;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin;
using CarDealership.Data.Identity;
using CarDealership.Data.EF;

namespace CarDealership.UI.App_Start
{
    public class IdentityConfig
    {
       
            public void Configuration(IAppBuilder app)
            {
            app.CreatePerOwinContext(() => new EFProdRepo());

            app.CreatePerOwinContext<UserManager<AppUser>>(
                (options, context) => new UserManager<AppUser>(
                    new UserStore<AppUser>(context.Get<EFProdRepo>())));

            app.CreatePerOwinContext<RoleManager<AppRole>>((options, context) =>
                new RoleManager<AppRole>(
                    new RoleStore<AppRole>(context.Get<EFProdRepo>())));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString("/Account/Login"),
                });
            }
        
    }
}