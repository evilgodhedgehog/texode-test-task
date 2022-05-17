using Texode_test_task.Api.ViewModels;
using Texode_test_task.BLL.Models;

namespace Texode_test_task.Api.Mappers
{
    public static class PhoneDtoMappers
    {
        public static IEnumerable<PhoneViewModel> MapToView(this IEnumerable<PhoneDto> phones)
        {
            foreach (var phone in phones)
            {
                yield return new PhoneViewModel
                {
                    Id = phone.Id,
                    Manufacturer = phone.Manufacturer,
                    Model = phone.Model,
                    ImageLink = phone.ImageLink,
                    Price = phone.Price,
                };
            }
        }

        public static PhoneViewModel MapToView(this PhoneDto phone)
        {
            return new PhoneViewModel
            {
                Id = phone.Id,
                Manufacturer = phone.Manufacturer,
                Model = phone.Model,
                ImageLink = phone.ImageLink,
                Price = phone.Price,
            };
        }

        public static PhoneDto MapToDto(this PhoneViewModel phone)
        {
            return new PhoneDto
            {
                Id = phone.Id,
                Manufacturer = phone.Manufacturer,
                Model = phone.Model,
                ImageLink = phone.ImageLink,
                Price = phone.Price,
            };
        }
    }
}
