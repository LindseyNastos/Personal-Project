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
            return _repo.Query<Pin>()
                .Include(p => p.Category)
                .Include(p => p.Board)
                .ToList();
        }


        public IList<Comment> CommentList(int pinId)
        {
            return _repo.Query<Comment>()
                .Include(c => c.User)
                .Where(c => c.PinId == pinId)
                .ToList();
        }


        public IndexVM SearchResults(string everything, int pageIndex)
        {
            const int ITEMS_PER_PAGE = 20;

            var pages = _repo.Query<Pin>()
                .Where(p => p.Category.Name.Contains(everything) || 
                    p.ShortDescription.Contains(everything) || 
                    p.LongDescription.Contains(everything) || 
                    p.Title.Contains(everything) || 
                    p.Website.Contains(everything) || 
                    p.Board.BoardName.Contains(everything))
                .OrderBy(p => p.Id).Skip(pageIndex * ITEMS_PER_PAGE)
                .Take(ITEMS_PER_PAGE)
                .ToList();

            var numPins = _repo.Query<Pin>()
                .Where(p => p.Category.Name.Contains(everything) || 
                    p.ShortDescription.Contains(everything) || 
                    p.LongDescription.Contains(everything) || 
                    p.Title.Contains(everything) || 
                    p.Website.Contains(everything) || 
                    p.Board.BoardName.Contains(everything))
                    .Count();

            return new IndexVM
            {
                Pins = pages,
                PinCount = numPins
            };
        }

        public IndexVM CategoryPages(int pageIndex, int id)
        {
            const int ITEMS_PER_PAGE = 20;
      
            var pages = _repo.Query<Pin>()
                .Where(p => p.CategoryId == id)
                .OrderBy(p => p.Id)
                .Skip(pageIndex * ITEMS_PER_PAGE)
                .Take(ITEMS_PER_PAGE)
                .ToList();

            var numPins = _repo.Query<Pin>()
                .Where(p => p.CategoryId == id)
                .Count();

            return new IndexVM
            {
                Pins = pages,
                PinCount = numPins
            };
        }


        public IndexVM Pages(int pageIndex)
        {
            const int ITEMS_PER_PAGE = 20;
            
            var pages = _repo.Query<Pin>()
                .OrderBy(p => p.Id)
                .Skip(pageIndex * ITEMS_PER_PAGE)
                .Take(ITEMS_PER_PAGE)
                .ToList();

            var numPins = _repo.Query<Pin>().Count();

            return new IndexVM
            {
                Pins = pages,
                PinCount = numPins
            };
        }

        public Pin Find(int id)
        {
            return _repo.Query<Pin>()
                .Include(p => p.Board)
                .Where(p => p.Id == id)
                .FirstOrDefault();
        }

        public int PinCount(int boardId)
        {
            return this.FindBoard(boardId).Pins.Count();
        }


        //public int TotalPins(string userId)
        //{
        //    return _repo.Query<ApplicationUser>().Include(u => u.Pins).Where(u => u.Id == userId).FirstOrDefault().Pins.Count();
        //}

        

        public Board FindBoard(int boardId)
        {
            return _repo.Query<Board>()
                .Where(b => b.Id == boardId)
                .Include(b => b.Pins)
                .FirstOrDefault();
        }

        public ApplicationUser FindUser(string userId)
        {
            return _repo.Query<ApplicationUser>()
                .Where(u => u.Id == userId)
                .Include(u => u.Pins)
                .FirstOrDefault();
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



        public void Create(Pin pin, string userId)
        {
            var originalUser = this.FindUser(userId);
            pin.UserId = userId;
            originalUser.Pins.Add(pin);
            pin.Board = this.FindBoard(pin.BoardId);
            var board = pin.Board;
            //board.NumPinsOnBoard = this.PinCount(pin.BoardId) + 1;
            _repo.SaveChanges();
        }

        public IList<Category> CategoryList()
        {
            return _repo.Query<Category>().ToList();
        }

        public IList<Pin> PinsByCategory(int id)
        { 
            return _repo.Query<Pin>()
                .Where(p => p.CategoryId == id)
                .ToList();
        }

        public IList<Board> BoardList(string userId)
        {
            return _repo.Query<Board>()
                .Where(b => b.UserId == userId)
                .ToList();
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

            var originalUser = this.FindUser(userId);
            originalUser.Pins.Add(newPin);
            //newPin.Board.NumPinsOnBoard = this.PinCount(boardId) + 1;

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

            if (original.BoardId != pin.BoardId)
            {
                var originalBoard = _repo.Find<Board>(original.BoardId);
                //originalBoard.NumPinsOnBoard = this.PinCount(originalBoard.Id) + 1;
                var board = this.FindBoard(pin.BoardId);
                //board.NumPinsOnBoard = this.PinCount(pin.BoardId) + 1;
            }
            _repo.SaveChanges();
        }

        public void Delete(int id)
        {
            var board = this.Find(id).Board;
            _repo.Delete<Pin>(id);
            //board.NumPinsOnBoard = this.PinCount(board.Id);
            _repo.SaveChanges();
        }

    }
}