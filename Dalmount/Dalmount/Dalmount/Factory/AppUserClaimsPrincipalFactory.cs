﻿using Dalmount.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Dalmount.Factory
{
	public class AppUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<AppUser, IdentityRole>
	{
		public AppUserClaimsPrincipalFactory(UserManager<AppUser> userManager,
		RoleManager<IdentityRole> roleManager,
		IOptions<IdentityOptions> optionsAccessor)
		: base(userManager, roleManager, optionsAccessor)
		{
		}

	}
}
