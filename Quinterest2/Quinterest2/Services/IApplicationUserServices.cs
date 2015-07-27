using System;
namespace Quinterest2.PermissionHelper
{
    public interface IApplicationUserServices
    {
        void Edit(Quinterest2.Models.ApplicationUser user);
        Quinterest2.Models.ApplicationUser Find(string id);
        //System.Collections.Generic.IList<Quinterest2.Models.ApplicationUser> List();
    }
}
