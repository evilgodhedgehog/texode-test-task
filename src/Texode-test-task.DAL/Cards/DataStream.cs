using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Texode_test_task.DAL.Models;

namespace Texode_test_task.DAL.Cards
{
    public static class DataStream
    {
        public static IEnumerable<Phone> ReadData()
        {
            StreamReader reader = new StreamReader("testData.json");
            string json = reader.ReadToEnd();
            reader.Close();

            List<Phone> phones = JsonConvert.DeserializeObject<List<Phone>>(json);
            
            return phones;
        }

        public static void WriteData(List<Phone> phones)
        {
            string json = JsonConvert.SerializeObject(phones, Formatting.Indented);
            StreamWriter writer = new StreamWriter("testData.json", false);
            writer.WriteLineAsync(json);
            writer.Close();
        }
    }
}
