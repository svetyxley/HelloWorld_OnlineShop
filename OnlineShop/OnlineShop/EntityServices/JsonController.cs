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

            string fileName = $"{typeof(T).Name}.json";

            // Проверка существования файла
            if (!File.Exists(fileName))
            {
                // Возвращаем пустой список, если файл не существует
                return new List<T>();
            }

            try
            {
                // Чтение и десериализация файла
                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read))
                {
                    // Проверка, что файл не пустой
                    if (fs.Length == 0)
                    {
                        return new List<T>();
                    }

                    return JsonSerializer.Deserialize<List<T>>(fs) ?? new List<T>();
                }
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                Console.WriteLine($"Ошибка при чтении из файла {fileName}: {ex.Message}");
                // Возвращаем пустой список в случае ошибки
                return new List<T>();
            }
        }
    }
    
}

