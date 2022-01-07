using CustomAuthorizationInMVC.Models.Context;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomAuthorizationInMVC.Models.Identity
{
    public class CustomUserStore : UserStore<CustomUser, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(AppDbContext context) : base(context)
        {

        }
    }
}