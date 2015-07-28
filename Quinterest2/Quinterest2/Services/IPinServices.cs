﻿using System;
namespace Quinterest2.Services
{
    public interface IPinServices
    {
        System.Collections.Generic.IList<Quinterest2.Models.Board> BoardList(string userId);
        System.Collections.Generic.IList<Quinterest2.Models.Category> CategoryList();
        void Create(Quinterest2.Models.Pin pin, string userId, int boardId);
        void Delete(int id, string userId, int boardId);
        void Edit(Quinterest2.Models.Pin pin);
        Quinterest2.Models.Pin Find(int id);
        Quinterest2.Models.Board FindBoard(int id);
        string FindPinUserId(int pinId);
        Quinterest2.Models.ApplicationUser FindUser(string userId);
        string FindUserName(string userId);
        System.Collections.Generic.IList<Quinterest2.Models.Pin> List();
        Quinterest2.Views.Pins.IndexVM Pages(int pageIndex);
        void PinIt(Quinterest2.Models.Pin pin, string userId, int boardId);
        System.Collections.Generic.IList<Quinterest2.Models.Pin> SearchResults(string everything);
    }
}
