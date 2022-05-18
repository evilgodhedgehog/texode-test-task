using Texode_test_task.BLL.Models;

namespace Texode_test_task.Api.ViewModels
{
    public class PhoneViewModel
    {
        public int Id { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public string ImageLink { get; set; }

        public decimal Price { get; set; }
    }
}
