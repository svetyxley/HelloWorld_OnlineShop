using OnlineShop.Items;
using UserApp;

namespace OnlineShop
{
    internal class ProductIOManager
    {
        public void InputName(InputValidator inputValidator, Product product)
        {
            //Input Name
            do
            {
                Console.Write("Enter ProductName: ");
                product.ProductName = Console.ReadLine();
                if (!inputValidator.IsValidData(product.ProductName))
                {
                    Console.WriteLine("Invalid input. Please enter product name.");
                    Console.WriteLine();
                }
            } while (!inputValidator.IsValidData(product.ProductName));
        }

        public void InputID(InputValidator inputValidator, Product product)
        {
            //Input ID
            do
            {
                Console.Write("Enter ProductID: ");
                product.ProductId = Int32.Parse(Console.ReadLine());
                if (!inputValidator.IsValidData(product.ProductId))
                {
                    Console.WriteLine("Invalid input. Please enter a valid first name.");
                    Console.WriteLine();
                }
            } while (!inputValidator.IsValidData(product.ProductName));
        }
    }
}
