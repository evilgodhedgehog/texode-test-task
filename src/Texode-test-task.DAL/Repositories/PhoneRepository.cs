using Texode_test_task.DAL.Data;
using Texode_test_task.DAL.Models;
using Texode_test_task.DAL.Repositories.Interfaces;

namespace Texode_test_task.DAL.Repositories
{
    public class PhoneRepository : IPhoneRepository
    {
        private List<Phone> _phones = new List<Phone>();
        private string url = "testData.json";

        private void ReadFromFile()
        {
            _phones = FileContext<Phone>.ReadData(url).ToList();
        }

        public void Add(Phone phone)
        {
            ReadFromFile();

            _phones.Add(phone);
        }

        public void Delete(int id)
        {
            ReadFromFile();

            var phone = _phones.Find(phone => phone.Id == id);

            if(phone != null)
            {
                _phones.Remove(phone);
            }
        }

        public IEnumerable<Phone> Get()
        {
            ReadFromFile();

            return _phones;
        }

        public Phone Get(int id)
        {
            ReadFromFile();

            var phone = _phones.Find(phone => phone.Id == id);

            phone = phone ?? throw new ArgumentNullException(nameof(phone));
            
            return phone;
        }

        public void Update(Phone phone)
        {
            ReadFromFile();

            var modifiedPhone = _phones.Find(modifiedPhone => modifiedPhone.Id == phone.Id);

            if(modifiedPhone != null)
            {
                modifiedPhone.Manufacturer = phone.Manufacturer;
                modifiedPhone.Model = phone.Model;
                modifiedPhone.ImageLink = phone.ImageLink;
                modifiedPhone.Price = phone.Price;
            }
        }

        public void SaveChanges()
        {
            FileContext<Phone>.WriteData(_phones, url);
        }
    }
}
