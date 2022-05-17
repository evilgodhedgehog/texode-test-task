using Texode_test_task.BLL.Models;

namespace Texode_test_task.BLL.Services.Interfaces
{
    public interface IPhoneService
    {
        IEnumerable<PhoneDto> Get();

        PhoneDto Get(int id);

        void Add(PhoneDto phone);

        void Update(PhoneDto phone);

        void Delete(int id);
    }
}
