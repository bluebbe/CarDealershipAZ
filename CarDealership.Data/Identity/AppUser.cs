using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.Data.Identity
{
    public class AppUser : IdentityUser
    {
        public virtual UserInfo UsersInfo { get; set; }
    }

    public class UserInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? IsAccountEnabled { get; set; }

    }
}