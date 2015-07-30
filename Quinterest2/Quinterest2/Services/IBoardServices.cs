using System;
namespace Quinterest2.Services
{
    public interface IBoardServices
    {
        int BoardCount(string userId);
        void Create(Quinterest2.Models.Board board, string userId);
        void Delete(int id, string userId);
        void Edit(Quinterest2.Models.Board board, string userId);
        Quinterest2.Models.Board Find(int boardId);
        int TotalPins(string userId);
    }
}
