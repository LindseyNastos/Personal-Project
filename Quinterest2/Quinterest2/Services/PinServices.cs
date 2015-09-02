using CoderCamps;
using Quinterest2.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web;
using Quinterest2.Views.Pins;
using Quinterest2.PermissionsHelper;

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
            var pins = _repo.Query<Pin>()
                .Include(p => p.Category)
                .Include(p => p.Board)
                .ToList();

            //var rnd = new System.Random();
            //var pinNumbers = Enumerable.Range(0, pins.Count()).OrderBy(f => rnd.Next());

            //var randomPins = new List<Pin>();

            //foreach (var number in pinNumbers)
            //{
            //    randomPins.Add(pins[number]);
            //}

            //return randomPins;

            return pins;
        }

        public int UpdatePinCount(int boardId)
        {
            var count = _repo.Query<Pin>()
                .Where(p => p.BoardId == boardId)
                .Count();
            var board = _repo.Find<Board>(boardId);
            board.NumPinsOnBoard = count;
            _repo.SaveChanges();
            return count;
        }

        public int UpdateFlagCount(int pinId)
        {
            var count = _repo.Query<Flag>()
                .Where(f => f.PinId == pinId)
                .Count();
            var pin = _repo.Find<Pin>(pinId);
            pin.NumFlags = count;
            _repo.SaveChanges();
            return count;
        }

        public IList<Comment> CommentList(int pinId)
        {
            return _repo.Query<Comment>()
                .Include(c => c.User)
                .Where(c => c.PinId == pinId)
                .ToList();
        }


        public IndexVM SearchResults(string userId, string everything, int pageIndex)
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
                PinCount = numPins,
                CurrentUserId = userId
            };
        }

        public IndexVM CategoryPages(string userId, int pageIndex, int id)
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
                PinCount = numPins,
                CurrentUserId = userId
            };
        }


        public IndexVM Pages(string userId, int pageIndex)
        {
            const int ITEMS_PER_PAGE = 20;


            //var rnd = new System.Random();
            //var pinNumbers = Enumerable.Range(0, pins.Count()).OrderBy(f => rnd.Next());



            var pages = _repo.Query<Pin>()
                .OrderBy(p => p.Id)
                .Skip(pageIndex * ITEMS_PER_PAGE)
                .Take(ITEMS_PER_PAGE)
                .ToList();

            var numPins = _repo.Query<Pin>().Count();

            var previous = 0;

            if (pageIndex > 0)
            {
                previous = pageIndex - 1;
            }

            return new IndexVM
            {
                Pins = pages,
                PinCount = numPins,
                Previous = previous,
                CurrentUserId = userId
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
            var name = thisUser.DisplayName;
            return name;
        }

        public string FindPinUserId(int pinId)
        {
            var pin = this.Find(pinId);
            var userId = pin.UserId;
            return userId;
        }



        public void Create(Pin pin, string userId)
        {
            var originalUser = this.FindUser(userId);
            pin.UserId = userId;
            originalUser.Pins.Add(pin);
            pin.Board = this.FindBoard(pin.BoardId);
            var board = pin.Board;
            _repo.SaveChanges();

            this.UpdatePinCount(board.Id);
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

            var currentUser = this.FindUser(userId);

            var newNote = new Notification()
            {
                DateTime = DateTime.Now,
                Message = currentUser.DisplayName + " has pinned your pin!",
                UserId = _repo.Query<Pin>().Where(p => p.Id == pin.Id).FirstOrDefault().UserId,
                User = pin.User,
                PinId = pin.Id,
            };

            _repo.Add<Pin>(newPin);
            _repo.Add<Notification>(newNote);
            _repo.SaveChanges();

            this.UpdatePinCount(boardId);
        }

        public void Edit(Pin pin)
        {
            var original = this.Find(pin.Id);
            var originalBoardId = original.BoardId;
            original.Title = pin.Title;
            original.BoardId = pin.BoardId;
            original.CategoryId = pin.CategoryId;
            original.ImageUrl = pin.ImageUrl;
            original.Website = pin.Website;
            original.ShortDescription = pin.ShortDescription;
            original.LongDescription = pin.LongDescription;

            _repo.SaveChanges();

            if (originalBoardId != pin.BoardId)
            {
                this.UpdatePinCount(originalBoardId);
                this.UpdatePinCount(pin.BoardId);
            }
        }

        public void Delete(int id)
        {
            if (ClaimsHelper.UserIsAdmin())
            {
                var userId = this.FindPinUserId(id);

                var newNote = new Notification()
                {
                    DateTime = DateTime.Now,
                    Message = "Your pin has been removed due to inappropriate content.",
                    UserId = userId,
                };
                _repo.Add<Notification>(newNote);
                _repo.SaveChanges();
            }

            var board = this.Find(id).Board;
            _repo.Delete<Pin>(id);
            _repo.SaveChanges();
            this.UpdatePinCount(board.Id);
        }

        public void FlagThis(int pinId, string userId)
        {
            var flag = new Flag
            {
                DateTime = DateTime.Now,
                UserId = userId,
                User = this.FindUser(userId),
                PinId = pinId,
                Pin = this.Find(pinId)
            };

            var pinUserId = this.FindPinUserId(pinId);

            var newNote = new Notification()
            {
                DateTime = DateTime.Now,
                Message = "Your pin has been flagged for review.",
                UserId = pinUserId,
                User = this.FindUser(pinUserId),
                PinId = pinId
            };

            _repo.Add<Flag>(flag);
            _repo.Add<Notification>(newNote);
            _repo.SaveChanges();

            this.UpdateFlagCount(pinId);

        }
        public IList<Notification> GetNotifications(string userId)
        {
            return _repo.Query<Notification>()
                .Where(n => n.UserId == userId)
                .Include(n => n.User)
                .Include(n => n.Pin)
                .ToList();
        }
    }


}