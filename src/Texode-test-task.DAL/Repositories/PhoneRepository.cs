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

        public PhoneRepository()
        {
            _phones = DataStream.ReadData().ToList();
        }

        public void AddPhone(Phone phone)
        {
            phone = phone ?? throw new ArgumentNullException(nameof(phone));

            if(phone != null)
            {
                _phones.Add(phone);
            }
        }

        public void DeletePhone(int id)
        {
            var isEmpty = _phones.Find(phone => phone.Id == id);

            if(isEmpty != null)
            {
                _phones.Remove(isEmpty);
            }
        }

        public IEnumerable<Phone> GetAll()
        {
            return _phones;
        }

        public Phone GetById(int id)
        {
            var isEmpty = _phones.Find(phone => phone.Id == id);

            if (isEmpty != null)
            {
                return isEmpty;
            }
            else
            {
                return null;
            }
        }

        public void UpdatePhone(Phone phone)
        {
            phone = phone ?? throw new ArgumentNullException(nameof(phone));

            Phone phoneModify = _phones.Find(phoneModify => phoneModify.Id == phone.Id);

            if(phoneModify != null)
            {
                phoneModify.Manufacturer = phone.Manufacturer;
                phoneModify.Model = phone.Model;
                phoneModify.ImageLink = phone.ImageLink;
                phoneModify.Price = phone.Price;
            }
        }

        public void SaveChanges()
        {
            DataStream.WriteData(_phones);
        }
    }
}
