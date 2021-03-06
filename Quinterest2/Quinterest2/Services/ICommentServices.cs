﻿using System;
namespace Quinterest2.Services
{
    public interface ICommentServices
    {
        System.Collections.Generic.IList<Quinterest2.Models.Comment> CommentList(int pinId);
        void Create(Quinterest2.Models.Comment comment, int pinId, string userId);
        void Delete(int id);
        Quinterest2.Models.Comment FindComment(int commentId);
        Quinterest2.Models.Pin FindPin(int pinId);
        Quinterest2.Models.ApplicationUser FindUser(string userId);
    }
}
