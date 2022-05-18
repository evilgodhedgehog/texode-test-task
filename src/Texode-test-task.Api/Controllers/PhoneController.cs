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
        public IActionResult Add(PhoneViewModel phone)
        {
            if (phone == null || phone.Id <= 0)
            {
                return BadRequest();
            }

            _phoneService.Add(phone.MapToDto());

            return Created("~phone", phone);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_phoneService.Get().MapToView());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            return Ok(_phoneService.Get(id).MapToView());
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            _phoneService.Delete(id);

            return NoContent();
        }

        [HttpPut]
        public IActionResult Udpate(PhoneViewModel phone)
        {
            if (phone == null || phone.Id <= 0)
            {
                return BadRequest();
            }

            _phoneService.Update(phone.MapToDto());

            return Ok();
        }
    }
}
