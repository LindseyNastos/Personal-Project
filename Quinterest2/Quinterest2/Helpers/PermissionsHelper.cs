using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Quinterest2.PermissionsHelper
{
    public static class ClaimsHelper
    {
        public static bool UserIsAdmin()
        {
            var user = HttpContext.Current.User as ClaimsPrincipal;

            return user.HasClaim("IsAdmin", "true");
        }
    }
}
