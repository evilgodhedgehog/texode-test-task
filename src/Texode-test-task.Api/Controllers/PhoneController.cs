using Microsoft.AspNetCore.Mvc;
using Texode_test_task.Api.Mappers;
using Texode_test_task.Api.ViewModels;
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
        public void AddPhone(int id, string manufacturer, string model, string imageLink, decimal price)
        {
            PhoneViewModel phone = new PhoneViewModel
            {
                Id = id,
                Manufacturer = manufacturer,
                Model = model,
                ImageLink = imageLink,
                Price = price
            };

            _phoneService.AddPhone(phone.MapViewTo());
        }

        [HttpGet]
        public IEnumerable<PhoneViewModel> GetAll()
        {
            return _phoneService.GetAll().MapToView();
        }

        [HttpGet("{id}")]
        public PhoneViewModel GetById(int id)
        {
            return _phoneService.GetById(id).MapToView();
        }

        [HttpDelete]
        public void DeletePhone(int id)
        {
            _phoneService.DeletePhone(id);
        }

        [HttpPut]
        public void UdpatePhone(int id, string manufacturer, string model, string imageLink, decimal price)
        {
            PhoneViewModel phone = new PhoneViewModel
            {
                Id = id,
                Manufacturer = manufacturer,
                Model = model,
                ImageLink = imageLink,
                Price = price
            };

            _phoneService.UpdatePhone(phone.MapViewTo());
        }
    }
}
