using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomAuthorizationInMVC.Models.Identity
{
    public class CustomUserRole : IdentityUserRole<int>
    {
        public virtual CustomUser CustomUser { get; set; }
        public virtual CustomRole CustomRole { get; set; }
    }
}