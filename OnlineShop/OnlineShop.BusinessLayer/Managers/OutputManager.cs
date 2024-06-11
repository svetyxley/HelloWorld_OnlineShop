using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BusinessLayer.Managers
{
    public class OutputManager
    {
        public void OutputToConsole(string message, string type)
        {
            Console.WriteLine($"{type} {message}");
            Console.WriteLine();
        }
    }
}
