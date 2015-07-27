using System;
namespace Quinterest2.PermissionHelper
{
    public interface IBoardServices
    {
        void Create(Quinterest2.Models.Board board, string userId);
        void Delete(int id, string userId);
        void Edit(Quinterest2.Models.Board board, string userId);
        Quinterest2.Models.Board Find(int id);
    }
}
