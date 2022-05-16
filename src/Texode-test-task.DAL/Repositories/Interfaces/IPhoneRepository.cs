﻿using Texode_test_task.DAL.Models;

namespace Texode_test_task.DAL.Repositories.Interfaces
{
    public interface IPhoneRepository
    {
        IEnumerable<Phone> GetAll();

        Phone GetById(int id);

        void AddPhone(Phone phone);

        void UpdatePhone(Phone phone);

        void DeletePhone(int id);

        void SaveChanges();
    }
}
