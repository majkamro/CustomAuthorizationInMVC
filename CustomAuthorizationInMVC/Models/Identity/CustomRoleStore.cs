using CustomAuthorizationInMVC.Models.Context;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomAuthorizationInMVC.Models.Identity
{
    public class CustomRoleStore : RoleStore<CustomRole, int, CustomUserRole>
    {
        public CustomRoleStore(AppDbContext context) : base(context)
        {

        }
    }
}