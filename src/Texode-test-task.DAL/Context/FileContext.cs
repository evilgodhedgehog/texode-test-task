using Newtonsoft.Json;

namespace Texode_test_task.DAL.Context
{
    public abstract class FileContext<T>
    {
        public static IEnumerable<T> ReadData(string url)
        {
            List<T> array = new List<T>();

            using (StreamReader reader = new StreamReader(url))
            {
                string json = reader.ReadToEnd();
                array = JsonConvert.DeserializeObject<List<T>>(json);
            }

            return array;
        }

        public static void WriteData(List<T> array, string url)
        {
            string json = JsonConvert.SerializeObject(array, Formatting.Indented);

            using (StreamWriter writer = new StreamWriter(url, false))
            {
                writer.WriteLineAsync(json);
            }
        }
    }
}
