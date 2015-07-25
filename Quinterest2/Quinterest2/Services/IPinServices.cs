using System;
namespace Quinterest2.Services
{
    public interface IPinServices
    {
        System.Collections.Generic.IList<Quinterest2.Models.Board> BoardList(string userId);
        System.Collections.Generic.IList<Quinterest2.Models.Category> CategoryList();
        void Create(Quinterest2.Models.Pin pin, string userId);
        void Delete(int id);
        void Edit(Quinterest2.Models.Pin pin);
        Quinterest2.Models.Pin Find(int id);
        Quinterest2.Models.Board FindBoard(int id);
        System.Collections.Generic.IList<Quinterest2.Models.Pin> List();
        void PinIt(Quinterest2.Models.Pin pin, Quinterest2.Models.ApplicationUser user, Quinterest2.Models.Board board);
    }
}
