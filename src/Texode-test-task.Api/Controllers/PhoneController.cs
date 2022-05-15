using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Texode_test_task.BLL.Models;
using Texode_test_task.BLL.Services.Interfaces;

namespace Texode_test_task.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly IPhoneService _phoneService;

        public PhoneController(IPhoneService phoneService)
        {
            _phoneService = phoneService ?? throw new ArgumentNullException(nameof(phoneService));
        }

        [HttpPost]
        public async Task AddPhone(PhoneDto phone)
        {
            Console.WriteLine("Suc");
            await _phoneService.AddPhone(phone);
        }

        [HttpGet]
        public IEnumerable<PhoneDto> GetAll()
        {
            return _phoneService.GetAll();
        }

        [HttpGet("{id}")]
        public PhoneDto GetById(int id)
        {
            return _phoneService.GetById(id);
        }

        public void DeletePost(int id)
        {
            _phoneService.DeletePhone(id);
        }
    }
}
