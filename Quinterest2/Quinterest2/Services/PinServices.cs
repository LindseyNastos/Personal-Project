using CoderCamps;
using Quinterest2.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web;
using Quinterest2.Views.Pins;

namespace Quinterest2.Services
{
    public class PinServices : Quinterest2.Services.IPinServices
    {
        private IGenericRepository _repo;

        public PinServices(IGenericRepository repo)
        {
            _repo = repo;
        }

        public IList<Pin> List()
        {
            return _repo.Query<Pin>().Include(p => p.Category).Include(p => p.Board).ToList();
        }

        public IndexVM Pages(int pageIndex)
        {
            const int ITEMS_PER_PAGE = 20;
            var pages = ((from p in _repo.Query<Pin>() select p).OrderBy(p => p.Id).Skip(pageIndex * ITEMS_PER_PAGE).Take(ITEMS_PER_PAGE).ToList());
            var numContacts = (from p in _repo.Query<Pin>() select p).Count();
            return new IndexVM
            {
                Pins = pages,
                PinCount = numContacts
            };
        }

        public Pin Find(int id)
        {
            return _repo.Query<Pin>().Include(p => p.Board).Where(p => p.Id == id).FirstOrDefault();
        }

        public Board FindBoard(int id)
        {
            return _repo.Query<Board>().Where(p => p.Id == id).FirstOrDefault();
        }

        public ApplicationUser FindUser(string userId)
        {
            return _repo.Query<ApplicationUser>().Where(u => u.Id == userId).FirstOrDefault();
        }

        public string FindUserName(string userId)
        {
            var thisUser = this.FindUser(userId);
            return thisUser.DisplayName;
        }

        public string FindPinUserId(int pinId)
        {
            var pin = this.Find(pinId);
            return pin.UserId;
        }

        public void Create(Pin pin, string userId, int boardId)
        {
            var originalUser = _repo.Query<ApplicationUser>().Where(u => u.Id == userId).Include(u => u.Pins).FirstOrDefault();
            pin.UserId = userId;
            originalUser.Pins.Add(pin);
            originalUser.NumPins = _repo.Query<Pin>().Where(p => p.UserId == userId).Count() + 1;
            var currentBoard = _repo.Query<Board>().Where(b => b.Id == boardId).Include(b => b.Pins).FirstOrDefault();
            currentBoard.NumPinsOnBoard = _repo.Query<Pin>().Where(p => p.BoardId == boardId).Count() + 1;
            _repo.SaveChanges();
        }

        public IList<Category> CategoryList()
        {
            return _repo.Query<Category>().ToList();
        }

        public IList<Board> BoardList(string userId)
        {
            return _repo.Query<Board>().Where(b => b.UserId == userId).ToList();
        }

        public void PinIt(Pin pin, string userId, int boardId)
        {
            var newPin = new Pin
            {
                Title = pin.Title,
                Board = pin.Board,
                BoardId = pin.BoardId,
                Category = pin.Category,
                CategoryId = pin.CategoryId,
                ImageUrl = pin.ImageUrl,
                Website = pin.Website,
                ShortDescription = pin.ShortDescription,
                LongDescription = pin.LongDescription,
                UserId = userId
            };

            var originalUser = _repo.Query<ApplicationUser>().Where(u => u.Id == userId).Include(u => u.Pins).FirstOrDefault();
            originalUser.Pins.Add(newPin);
            originalUser.NumPins = _repo.Query<Pin>().Where(p => p.UserId == userId).Count() + 1;
            var currentBoard = _repo.Query<Board>().Where(b => b.Id == boardId).Include(b => b.Pins).FirstOrDefault();
            currentBoard.NumPinsOnBoard = _repo.Query<Pin>().Where(p => p.BoardId == boardId).Count() + 1;

            _repo.SaveChanges();
        }

        public void Edit(Pin pin)
        {
            var original = this.Find(pin.Id);
            original.Title = pin.Title;
            original.BoardId = pin.BoardId;
            original.CategoryId = pin.CategoryId;
            original.ImageUrl = pin.ImageUrl;
            original.Website = pin.Website;
            original.ShortDescription = pin.ShortDescription;
            original.LongDescription = pin.LongDescription;

            var oldBoard = _repo.Query<Board>().Where(b => b.Id == original.BoardId).Include(b => b.Pins).FirstOrDefault();
            oldBoard.NumPinsOnBoard = _repo.Query<Pin>().Where(p => p.BoardId == original.BoardId).Count() - 1;

            var newBoard = _repo.Query<Board>().Where(b => b.Id == pin.BoardId).Include(b => b.Pins).FirstOrDefault();
            newBoard.NumPinsOnBoard = _repo.Query<Pin>().Where(p => p.BoardId == pin.BoardId).Count() + 1;

            _repo.SaveChanges();
        }

        public void Delete(int id, string userId, int boardId)
        {

            var originalUser = _repo.Query<ApplicationUser>().Where(u => u.Id == userId).Include(u => u.Boards).FirstOrDefault();
            originalUser.NumBoards = _repo.Query<Pin>().Where(b => b.UserId == userId).Count() - 1;

            var currentBoard = _repo.Query<Board>().Where(b => b.Id == boardId).Include(b => b.Pins).FirstOrDefault();
            currentBoard.NumPinsOnBoard = _repo.Query<Pin>().Where(p => p.BoardId == boardId).Count() - 1;

            _repo.Delete<Pin>(id);
            _repo.SaveChanges();
        }

    }
}