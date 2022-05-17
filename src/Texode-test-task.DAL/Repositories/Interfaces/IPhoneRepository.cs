using Texode_test_task.DAL.Models;

namespace Texode_test_task.DAL.Repositories.Interfaces
{
    public interface IPhoneRepository
    {
        IEnumerable<Phone> Get();

        Phone Get(int id);

        void Add(Phone phone);

        void Update(Phone phone);

        void Delete(int id);

        void SaveChanges();
    }
}
