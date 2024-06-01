namespace OnlineShop
{
    internal class InputConsoleManager
    {
        public string InputName(InputValidator inputValidator)
        {
            string name;
            //Input Name
            do
            {
                Console.Write("Enter Name: ");
                name = Console.ReadLine();
                if (!inputValidator.IsValidData(name))
                {
                    Console.WriteLine("Invalid input. Please enter name.");
                    Console.WriteLine();
                }
            } while (!inputValidator.IsValidData(name));
            return name;
        }
        public string InputEDRPU(InputValidator inputValidator)
        {
            string codeEDRPU;
            //Input Name
            do
            {
                Console.Write("Enter code EDRPU: ");
                codeEDRPU = Console.ReadLine();
                if (!inputValidator.IsValidData(codeEDRPU))
                {
                    Console.WriteLine("Invalid input. Please enter name.");
                    Console.WriteLine();
                }
            } while (!inputValidator.IsValidData(codeEDRPU));
            return codeEDRPU;
        }
    }
}

