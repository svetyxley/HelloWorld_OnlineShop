using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OnlineShop.EntityServices
{
    public static class JsonController<T>
    {
        public static void Add(T source)
        {
            List<T> list = ReadFromFile();

            list.Add(source);

            WriteToFile(list);
        }

        public static void WriteToFile(List<T> list)
        {
            using (FileStream fs = new FileStream($"{typeof(T).Name}.json", FileMode.Create))
            {
                JsonSerializer.Serialize(fs, list);
            }
        }

        public static List<T> ReadFromFile()
        {
            string filePath = $"{typeof(T).Name}.json";

            if (!File.Exists(filePath))
            {
                return new List<T>();
            }

            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                try
                {
                    return JsonSerializer.Deserialize<List<T>>(fs) ?? new List<T>();
                }
                catch (JsonException)
                {
                    return new List<T>();
                }
            }
        }
    }
}

