using System.Text.Json;

namespace CoffeeShop.Infrastructure.Helper
{
    public class FileHelper
    {
        string filepath;

        public FileHelper(string filepath)
        {
            this.filepath = filepath;
        }
        public List<T> ReadFromFile<T>()
        {
            if(!File.Exists(filepath))
            {
                return new List<T>();
            }

            string json = File.ReadAllText(filepath);
            return JsonSerializer.Deserialize<List<T>>(json);
        }

        public void WriteIntoFile<T>(List<T> data)
        {
            string directory = Path.GetDirectoryName(filepath);
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(directory);
            }

            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filepath, json);
        }
    }
}
