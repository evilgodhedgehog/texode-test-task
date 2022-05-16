using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Texode_test_task.BLL.Mappers;
using Texode_test_task.BLL.Models;
using Texode_test_task.BLL.Services.Interfaces;
using Texode_test_task.DAL.Cards;
using Texode_test_task.DAL.Repositories.Interfaces;

namespace Texode_test_task.BLL.Services
{
    public class PhoneService : IPhoneService
    {
        private readonly IPhoneRepository _phoneRepository;

        public PhoneService(IPhoneRepository phoneRepository)
        {
            _phoneRepository = phoneRepository ?? throw new ArgumentNullException(nameof(phoneRepository));
        }

        public void AddPhone(PhoneDto phone)
        {
            _phoneRepository.AddPhone(phone.MapDtoTo());
            _phoneRepository.SaveChanges();
        }

        public void DeletePhone(int id)
        {
            _phoneRepository.DeletePhone(id);
            _phoneRepository.SaveChanges();
        }

        public IEnumerable<PhoneDto> GetAll()
        {
            return _phoneRepository.GetAll().MapToDto();
        }

        public PhoneDto GetById(int id)
        {
            return _phoneRepository.GetById(id).MapToDto();
        }

        public void UpdatePhone(PhoneDto phone)
        {
            _phoneRepository.UpdatePhone(phone.MapDtoTo());
            _phoneRepository.SaveChanges();
        }
    }
}
