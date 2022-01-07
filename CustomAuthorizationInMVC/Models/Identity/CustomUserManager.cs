using CustomAuthorizationInMVC.Models.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using CustomAuthorizationInMVC.Extentions;

namespace CustomAuthorizationInMVC.Models.Identity
{
    public class CustomUserManager : UserManager<CustomUser, int>
    {
        public CustomUserManager(IUserStore<CustomUser, int> store) : base(store)
        {

        }

        public static CustomUserManager Create(IdentityFactoryOptions<CustomUserManager> options, IOwinContext context)
        {
            var manager = new CustomUserManager(new CustomUserStore(context.Get<AppDbContext>()));

            manager.UserValidator = new UserValidator<CustomUser, int>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            manager.RegisterTwoFactorProvider("PhoneCode", new PhoneNumberTokenProvider<CustomUser, int>
            {
                MessageFormat = "Your security code is: {0}"
            });

            manager.RegisterTwoFactorProvider("EmailCode", new EmailTokenProvider<CustomUser, int>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is: {0}"
            });

            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<CustomUser, int>(dataProtectionProvider.Create("ASP.NET Identity"));
            }

            return manager;
        }

        public override Task<IdentityResult> ConfirmEmailAsync(int userId, string token)
        {
            return base.ConfirmEmailAsync(userId, token);
        }

        public override Task<IdentityResult> RemoveLoginAsync(int userId, UserLoginInfo login)
        {
            return base.RemoveLoginAsync(userId, login);
        }

    }
}