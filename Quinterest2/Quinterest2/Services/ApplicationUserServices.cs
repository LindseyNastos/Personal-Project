using CoderCamps;
using Quinterest2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quinterest2.Services
{
    public class ApplicationUserServices : Quinterest2.Services.IApplicationUserServices
    {
        private IGenericRepository _repo;

        public ApplicationUserServices(IGenericRepository repo)
        {
            _repo = repo;
        }

        public ApplicationUser Find(string id)
        {
            return _repo.Query<ApplicationUser>()
                .Include(u => u.Boards)
                .Include(u => u.Pins)
                .Where(u => u.Id == id)
                .FirstOrDefault();
        }

        public int QNumBoards(string userId) 
        {
            var user = this.Find(userId);
            var numBoards = user.Boards.Count();
            user.NumBoards = numBoards;
            _repo.SaveChanges();

            return numBoards;
        }

        public int QNumPins(string userId)
        {
            var user = this.Find(userId);
            var numPins = _repo.Query<Pin>()
                .Where(p => p.UserId == userId)
                .Where(p => p.IsActive == true)
                .Count();
            user.NumPins = numPins;
            _repo.SaveChanges();

            return numPins;
        }

        public void QNumPinsOnBoard(string userId)
        {
            var boards = this.Find(userId).Boards.ToList();

            foreach (var board in boards)
            {
                board.NumPinsOnBoard = _repo.Query<Pin>()
                    .Where(p => p.IsActive == true)
                    .Where(p => p.BoardId == board.Id)
                    .Count();
            }
            _repo.SaveChanges();
        }

        public void Edit(ApplicationUser user)
        {
            var original = this.Find(user.Id);
            original.DisplayName = user.DisplayName;
            original.ImageUrl = user.ImageUrl;
            _repo.SaveChanges();
        }

        public IList<Flag> FlagList()
        {
            return _repo.Query<Flag>()
                .Include(f => f.Pin)
                .Where(f => f.Pin.IsActive == true)
                .Include(f => f.User)
                .ToList();

        }
        
    }
}