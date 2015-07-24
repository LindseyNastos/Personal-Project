using System;
namespace Quinterest2.Services
{
    public interface IPinServices
    {
        System.Collections.Generic.IList<Quinterest2.Models.Board> BoardList();
        System.Collections.Generic.IList<Quinterest2.Models.Category> CategoryList();
        void Create(Quinterest2.Models.Pin pin);
        void Delete(int id);
        void Edit(Quinterest2.Models.Pin pin);
        Quinterest2.Models.Pin Find(int id);
        System.Collections.Generic.IList<Quinterest2.Models.Pin> List();
        void PinToBoard(int id, Quinterest2.Models.Pin pin);
    }
}
