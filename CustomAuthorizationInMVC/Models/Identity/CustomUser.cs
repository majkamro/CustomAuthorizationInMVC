using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomAuthorizationInMVC.Models.Identity
{
    public class CustomUser : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
    }
}