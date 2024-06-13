using OnlineShop.Records;

namespace OnlineShop
{
    public class OutputManager
    {
       public void OutputToConsole (string message, string type) 
       {
            Console.WriteLine($"{type} {message}");
            Console.WriteLine(); 
       }
    }
}
