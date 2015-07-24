using CoderCamps;
using Quinterest2.Models;
using System;
using System.Collections.Generic;
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

        //int id is board id
        public void PinToBoard(int id, Pin pin)
        {
            pin.BoardId = id;
            _repo.Add(pin);
            //_repo.Board.NumPinsOnBoard = _repo.Query<Board>().Where(n => n.BoardId == id).Select(n => n).Count() + 1;
            _repo.SaveChanges();
        }


        public Pin Find(int id)
        {
            return _repo.Find<Pin>(id);
        }

        public void Create(Pin pin)
        {
            _repo.Add<Pin>(pin);
            _repo.SaveChanges();
        }

        public IList<Category> CategoryList()
        {
            return _repo.Query<Category>().ToList();
        }

        public IList<Board> BoardList()
        {
            return _repo.Query<Board>().ToList();
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