using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Texode_test_task.DAL.Cards;
using Texode_test_task.DAL.Models;
using Texode_test_task.DAL.Repositories.Interfaces;

namespace Texode_test_task.DAL.Repositories
{
    public class PhoneRepository : IPhoneRepository
    {
        private List<Phone> _phones = new List<Phone>();

        public Task AddPhone(Phone phone)
        {
            throw new NotImplementedException();
        }

        public void DeletePhone(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Phone> GetAll()
        {
            ReadData readData = new ReadData();
            readData.Run();
            return _phones;
        }

        public Phone GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdatePhone(Phone phone)
        {
            throw new NotImplementedException();
        }
    }
}
