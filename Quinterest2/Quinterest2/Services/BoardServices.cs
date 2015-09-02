using CoderCamps;
using Quinterest2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quinterest2.Services
{
    public class BoardServices : Quinterest2.Services.IBoardServices
    {
        private IGenericRepository _repo;

        public BoardServices(IGenericRepository repo)
        {
            _repo = repo;
        }

        public Board Find(int boardId)
        {
            var model = _repo.Query<Board>().Where(b => b.Id == boardId).FirstOrDefault();
            model.Pins = _repo.Query<Pin>().Where(p => p.IsActive == true && p.BoardId == model.Id).ToList();
            return model;
        }

        public int BoardCount(string userId)
        {
            return _repo.Query<ApplicationUser>()
                .Include(u => u.Boards)
                .Where(u => u.Id == userId)
                .FirstOrDefault()
                .Boards.Count();
        }

        public int TotalPins(string userId)
        {
            return _repo.Query<ApplicationUser>()
                .Include(u => u.Pins)
                .Where(u => u.Id == userId)
                .FirstOrDefault()
                .Pins.Count();
        }

        public int UpdatePinCount(int boardId)
        {
            var count = _repo.Query<Pin>()
                .Where(p => p.IsActive == true)
                .Where(p => p.BoardId == boardId)
                .Count();
            var board = _repo.Find<Board>(boardId);
            board.NumPinsOnBoard = count;
            _repo.SaveChanges();
            return count;
        }

        public void Create(Board board, string userId)
        {
            var originalUser = _repo.Query<ApplicationUser>()
                .Where(u => u.Id == userId)
                .Include(u => u.Boards)
                .FirstOrDefault();

            board.UserId = userId;
            originalUser.Boards.Add(board);
            _repo.SaveChanges();
        }

        public void Edit(Board board, string userId)
        {
            var original = this.Find(board.Id);

            original.BoardName = board.BoardName;
            original.Description = board.Description;
            original.ImageUrl = board.ImageUrl; 

            var originalUser = _repo.Query<ApplicationUser>()
                .Where(u => u.Id == userId)
                .Include(u => u.Boards)
                .FirstOrDefault();

            _repo.SaveChanges();
        }

        public void Delete(int id, string userId)
        {
            var originalUser = _repo.Query<ApplicationUser>()
                .Where(u => u.Id == userId)
                .Include(u => u.Boards)
                .FirstOrDefault();

            _repo.Delete<Board>(id);
            originalUser.NumPins = this.TotalPins(userId);
            _repo.SaveChanges();
        }

    }
}