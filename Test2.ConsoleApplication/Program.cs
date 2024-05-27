using System;
using Test2.Common.Helper;
using Test2.Common.Service;

namespace Test2.ConsoleApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter numbers separated by commas (,), newlines (\\n), or custom delimiters. Press Enter to calculate:");
                Console.WriteLine("Format for custom delimiters: //[delimiter]\\n[numbers...]");
                Console.WriteLine("Example: //;\\n1;2");
                Console.WriteLine("Enter numbers string (or 'q' to quit):");

                string input = Console.ReadLine();

                Console.Clear();

                if (input.Trim().ToLower() == "q")
                {
                    break;
                }

                input = ConvertToVerbatimStringHelper.ConvertToVerbatimString(input);

                Calculator calculator = new Calculator();

                try
                {
                    int result = calculator.Add(input);
                    Console.WriteLine($"====================================");
                    Console.WriteLine($"Result: {result}");
                    Console.WriteLine($"====================================");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }

            Console.ReadLine();
        }
    }
}