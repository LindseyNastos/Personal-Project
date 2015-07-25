using CoderCamps;
using Quinterest2.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web;

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

        public Pin Find(int id)
        {
            return _repo.Query<Pin>().Include(p => p.Board).Where(p => p.Id == id).FirstOrDefault();
        }

        public Board FindBoard(int id)
        {
            return _repo.Query<Board>().Where(p => p.Id == id).FirstOrDefault();
        }

        public void Create(Pin pin, string userId)
        {
            _repo.Add<Pin>(pin);
            var allPins = _repo.Query<Pin>().Where(p => p.UserId == userId).Count() + 1;
            pin.User.NumPins = allPins;
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

        public void PinIt(Pin pin, ApplicationUser user, Board board)
        {

            var original = new Pin
            {
                Title = pin.Title,
                Category = pin.Category,
                ImageUrl = pin.ImageUrl,
                Website = pin.Website,
                ShortDescription = pin.ShortDescription,
                LongDescription = pin.LongDescription,
                Board = pin.Board,
                BoardId = pin.BoardId,
                User = user
            };

            _repo.Add<Pin>(original);
            _repo.SaveChanges();
        }

        public void Edit(Pin pin)
        {
            var original = this.Find(pin.Id);
            original.Title = pin.Title;
            original.Board = pin.Board;
            original.CategoryId = pin.CategoryId;
            original.ImageUrl = pin.ImageUrl;
            original.Website = pin.Website;
            original.ShortDescription = pin.ShortDescription;
            original.LongDescription = pin.LongDescription;
            _repo.SaveChanges();
        }

        public void Delete(int id)
        {
            _repo.Delete<Pin>(id);
            _repo.SaveChanges();
        }

    }
}