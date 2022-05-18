using Texode_test_task.BLL.Models;
using Texode_test_task.DAL.Models;

namespace Texode_test_task.BLL.Mappers
{
    public static class PhoneMappers
    {
        public static IEnumerable<PhoneDto> MapToDto(this IEnumerable<Phone> phones)
        {
            foreach (var phone in phones)
            {
                yield return new PhoneDto
                {
                    Id = phone.Id,
                    Manufacturer = phone.Manufacturer,
                    Model = phone.Model,
                    ImageLink = phone.ImageLink,
                    Price = phone.Price,
                };
            }
        }

        public static PhoneDto MapToDto(this Phone phone)
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

        public static Phone MapToDomain(this PhoneDto phone)
        {
            return new Phone
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
