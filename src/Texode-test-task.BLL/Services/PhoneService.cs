using Texode_test_task.BLL.Mappers;
using Texode_test_task.BLL.Models;
using Texode_test_task.BLL.Services.Interfaces;
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

        public void Add(PhoneDto phone)
        {
            _phoneRepository.Add(phone.MapToDomain());
            _phoneRepository.SaveChanges();
        }

        public void Delete(int id)
        {
            _phoneRepository.Delete(id);
            _phoneRepository.SaveChanges();
        }

        public IEnumerable<PhoneDto> Get()
        {
            return _phoneRepository.Get().MapToDto();
        }

        public PhoneDto Get(int id)
        {
            return _phoneRepository.Get(id).MapToDto();
        }

        public void Update(PhoneDto phone)
        {
            _phoneRepository.Update(phone.MapToDomain());
            _phoneRepository.SaveChanges();
        }
    }
}
