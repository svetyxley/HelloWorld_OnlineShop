using System.Text.RegularExpressions;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Guid>()
            {
                Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()
            };
            var s = string.Join(',', list);
            Console.WriteLine(s);

                var inputStr = "qwertyqweioqwerre";

                Console.WriteLine("INPUT STRING: " + inputStr);

                Console.WriteLine("MAX SUBSTRING LENGTH: " + GetMaxLengthDeletedDupSubstring(inputStr, out string output));

                Console.WriteLine("OUTPUT STRING: " + output);

                // OUTPUT
                //
                // INPUT STRING: qwertyqweioqwer
                // MAX SUBSTRING LENGTH: 4
                // OUTPUT STRING: tyioqwer

            int GetMaxLengthDeletedDupSubstring(string input, out string output)
            {
                var matchCharStrings = new string[input.Length];

                var distinctCharStrings = new List<string>();

                var intAppearChars = new List<int>();

                for (int index = 0; index < input.Length; index = index + 1)
                {
                    matchCharStrings[index] = input[index].ToString();

                    if (Regex.Matches(input, matchCharStrings[index]).Count > 1)
                    {
                        distinctCharStrings.Add(matchCharStrings[index]);
                    }
                }

                distinctCharStrings = distinctCharStrings.Distinct().ToList();

                intAppearChars = input.Select(inputChar => distinctCharStrings.Contains(inputChar.ToString()) ? 1 : 0).ToList();

                int currentLength;

                int maxLength = 0;

                for (int index = 1; index < input.Length; index = index + 1)
                {
                    if (intAppearChars[index] != 0)
                    {
                        intAppearChars[index] = intAppearChars[index] + intAppearChars[index - 1];

                        currentLength = intAppearChars[index];

                        if (currentLength > maxLength)
                        {
                            maxLength = currentLength;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }

                char[] outputChars = input.ToCharArray();

                Array.Reverse(outputChars);

                outputChars = outputChars.Distinct().ToArray();

                Array.Reverse(outputChars);

                output = new String(outputChars);

                return maxLength;
            }
        }
    }
}
