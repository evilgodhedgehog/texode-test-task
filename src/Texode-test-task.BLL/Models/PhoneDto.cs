using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texode_test_task.BLL.Models
{
    public class PhoneDto
    {
        public int Id { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public string ImageLink { get; set; }

        public decimal Price { get; set; }
    }
}
