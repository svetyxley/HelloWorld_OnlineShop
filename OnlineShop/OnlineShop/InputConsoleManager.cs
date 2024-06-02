namespace OnlineShop
{
    public class InputConsoleManager
    {
        public string InputName(InputValidator inputValidator, string type)
        {
            string name;
            //Input Name
            do
            {
                Console.Write($"Enter {type} name: ");
                name = Console.ReadLine();
                if (!inputValidator.IsValidDataName(name))
                {
                    Console.WriteLine($"Invalid input. Enter {type} name");
                    Console.WriteLine();
                }
            } while (!inputValidator.IsValidDataName(name));
            return name;
        }
        public string InputEDRPU(InputValidator inputValidator, string type)
        {
            string codeEDRPOU;
            //Input Name
            do
            {
                Console.Write($"Enter {type} code EDRPOU: ");
                codeEDRPOU = Console.ReadLine();
                if (!inputValidator.IsValidDataEDRPOU(codeEDRPOU))
                {
                    Console.WriteLine($"Invalid input. Enter {type} code EDRPU.");
                    Console.WriteLine();
                }
            } while (!inputValidator.IsValidDataEDRPOU(codeEDRPOU));
            return codeEDRPOU;
        }
    }
}

