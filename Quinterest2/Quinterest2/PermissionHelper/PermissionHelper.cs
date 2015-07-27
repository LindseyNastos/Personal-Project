﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Quinterest2.PermissionHelper
{
    public class PermissionHelper
    {
        public static bool UserIsAdmin()
        {

            var user = HttpContext.Current.User.Identity as ClaimsPrincipal;

            return user.HasClaim("IsAdmin", "true");
        }
    }
}