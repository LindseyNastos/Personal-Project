using System;
namespace Quinterest2.Services
{
    public interface IBoardServices
    {
        void Create(Quinterest2.Models.Board board, string userId);
        void Delete(int id, string userId);
        void Edit(Quinterest2.Models.Board board);
        Quinterest2.Models.Board Find(int id);
        System.Collections.Generic.IList<Quinterest2.Models.Board> List();
    }
}
