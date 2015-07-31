using System;
namespace Quinterest2.Services
{
    public interface IApplicationUserServices
    {
        void Edit(Quinterest2.Models.ApplicationUser user);
        Quinterest2.Models.ApplicationUser Find(string id);
        int QNumBoards(string userId);
        int QNumPins(string userId);
        void QNumPinsOnBoard(string userId);
    }
}
