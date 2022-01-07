using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomAuthorizationInMVC.Models.Identity
{
    public class CustomUserClaim : IdentityUserClaim<int>
    {
        public virtual CustomUser CustomUser { get; set; }
    }
}