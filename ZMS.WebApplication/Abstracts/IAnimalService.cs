﻿using System;
using System.Collections.Generic;
using ZMS.Models;

namespace ZMS.WebApplication.Abstracts
{
    public interface IAnimalService : IDisposable
    {
        Animal Get(int id);
        IEnumerable<Animal> GetAll();
        void AddNew(Animal item);
        void Feed(int id);
        void FeedAll();
        void AttachCaretaker(int animalId, int caretakerId);
        IEnumerable<Animal> Filter(Func<Animal,bool> filter);
    }
}