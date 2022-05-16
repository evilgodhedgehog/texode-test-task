using Texode_test_task.BLL.Models;

namespace Texode_test_task.BLL.Services.Interfaces
{
    public interface IPhoneService
    {
        IEnumerable<PhoneDto> GetAll();

        PhoneDto GetById(int id);

        void AddPhone(PhoneDto phone);

        void UpdatePhone(PhoneDto phone);

        void DeletePhone(int id);
    }
}
