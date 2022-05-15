using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Texode_test_task.DAL.Models;

namespace Texode_test_task.DAL.Cards
{
    public class ReadData : IReadData
    {
        public async Task Run()
        {
            FileStream fs = new FileStream("testData.json", FileMode.OpenOrCreate);

            Phone? person = await JsonSerializer.DeserializeAsync<Phone>(fs);

            Console.WriteLine(person);
        }
    }
}
