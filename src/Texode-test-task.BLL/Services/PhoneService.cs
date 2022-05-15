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

        public Task AddPhone(PhoneDto phone)
        {
            throw new NotImplementedException();
        }

        public void DeletePhone(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PhoneDto> GetAll()
        {
            return _phoneRepository.GetAll().MapToDto();
        }

        public PhoneDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePhone(PhoneDto phone)
        {
            throw new NotImplementedException();
        }
    }
}
