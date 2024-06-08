﻿using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Text.Json.Serialization;

namespace OnlineShop.EntityServices
{
    public static class JsonController<T>
    {


        public static void WriteToFile(T source)
        {
            using (FileStream fs = new FileStream($"{typeof(T).Name}.json", FileMode.Append))
            {
                List<T> list = ReadFromFile();

                list.Add(source);

                JsonSerializerOptions options = new JsonSerializerOptions();
                options.WriteIndented = true;

                if (source != null)
                {
                    JsonSerializer.SerializeAsync(fs, list, options);
                }
                
                fs.Close();
            }
        }

        public static List<T> ReadFromFile()
        {
            // Чтение и десериализация файла
            using (FileStream fs = new FileStream($"{typeof(T).Name}.json", FileMode.OpenOrCreate, FileAccess.Read))
            {

                List<T> result = JsonSerializer.Deserialize<List<T>>(fs);
                return result;
            }
        }

    }
    
}

