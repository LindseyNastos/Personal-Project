using CoderCamps;
using Quinterest2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quinterest2.Services
{
    public class CommentServices : Quinterest2.Services.ICommentServices
    {
        private IGenericRepository _repo;

        public CommentServices(IGenericRepository repo)
        {
            _repo = repo;
        }


        public IList<Comment> CommentList(int pinId)
        { 
            return _repo.Query<Comment>()
                .Include(c => c.User)
                .Where(c => c.PinId == pinId)
                .ToList();
        }

        public Comment FindComment(int commentId)
        {
            return _repo.Find<Comment>(commentId);
        }

        public Pin FindPin(int pinId)
        {
            return _repo.Query<Pin>()
                .Where(p => p.IsActive == true)
                .Where(p => p.Id == pinId)
                .Include(p => p.Comments)
                .Include(p =>p.User)
                .FirstOrDefault();
        }

        public ApplicationUser FindUser(string userId)
        {
            return _repo.Query<ApplicationUser>()
                .Where(a => a.Id == userId)
                .FirstOrDefault();
        }

        public void Create(Comment comment, int pinId, string userId)
        {
            comment.PinId = pinId;
            comment.UserId = userId;
            comment.DateTime = DateTime.Now;

            var currentUser = this.FindUser(userId);
            var pin = this.FindPin(pinId);


            var newNote = new Notification()
            {
                DateTime = DateTime.Now,
                Message = currentUser.DisplayName + " has left a comment on your pin:  " + comment.Words,
                UserId = pin.UserId,
                PinId = pin.Id,
            };

            _repo.Add<Comment>(comment);
            _repo.Add<Notification>(newNote);
            _repo.SaveChanges();
        }

        public void Delete(int id)
        {
            _repo.Delete<Comment>(id);
            _repo.SaveChanges();
        }

    }
}