using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Texode_test_task.BLL.Models;

namespace Texode_test_task.BLL.Services.Interfaces
{
    public interface IPhoneService
    {
        IEnumerable<PhoneDto> GetAll();

        PhoneDto GetById(int id);

        Task AddPhone(PhoneDto phone);

        Task UpdatePhone(PhoneDto phone);

        void DeletePhone(int id);
    }
}
