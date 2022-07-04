using Broker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Broker.Helpers
{
    public class AppUserClaimsPrincipalFactory:UserClaimsPrincipalFactory<User,IdentityRole>
    {
        public AppUserClaimsPrincipalFactory(UserManager<User> userManager,RoleManager<IdentityRole> roleManager,IOptions<IdentityOptions> options)
        :base(userManager,roleManager,options)
        {

        }
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        {
            var identity=await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim(("FullName") , user.FullName ?? ""));
            return identity;
        }
    }
}
