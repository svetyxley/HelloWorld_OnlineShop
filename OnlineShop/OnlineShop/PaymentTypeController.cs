using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OnlineShop
{
    internal static class PaymentTypeController
    {
        
        public static void AddPaymentType (this PaymentType p, string name)
        {
            WriteToFile(new PaymentType(name));
        }

        public static List<PaymentType> ShowAll()
        {
            List <PaymentType> resutl = ReadFromFile();
            return resutl;
        }





        public static void WriteToFile (this PaymentType p)
        {
            using (FileStream fs = new FileStream("PaymentType.json", FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize<PaymentType>(fs, p);
            }
        }

        public static List<PaymentType> ReadFromFile()
        {
            using (FileStream fs = new FileStream("PaymentType.json", FileMode.Open))
            {
               List<PaymentType> result = JsonSerializer.Deserialize<List<PaymentType>>(fs);
               return result;
            }
        }
    }
}
