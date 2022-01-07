using CustomAuthorizationInMVC.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomAuthorizationInMVC.Models.Context
{
    public class AppDbContext : IdentityDbContext<CustomUser, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public AppDbContext():base("DefaultConnection")
        {

        }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
    }
}