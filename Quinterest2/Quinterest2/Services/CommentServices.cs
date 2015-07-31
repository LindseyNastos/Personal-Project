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

        public Pin FindPin(int pinId)
        {
            return _repo.Query<Pin>()
                .Where(p => p.Id == pinId)
                .Include(p => p.Comments)
                .Include(p =>p.User)
                .FirstOrDefault();
        }

        public ApplicationUser FindUser(string userId)
        {
            return _repo.Query<ApplicationUser>()
                .Where(a => a.Id == userId)
                .Include(a => a.DisplayName)
                .FirstOrDefault();
        }

        public void Create(Comment comment, int pinId, string userId)
        {
            comment.PinId = pinId;
            comment.UserId = userId;
            comment.DateTime = DateTime.Now;
            _repo.Add(comment);
            _repo.SaveChanges();
        }


    }
}