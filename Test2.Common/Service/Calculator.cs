using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace Test2.Common.Service
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            string delimiterPattern = ",|\n";
            string numberString = numbers;

            if (numbers.StartsWith("//"))
            {
                var match = Regex.Match(numbers, @"^//(\[.*\]|.)\n");
                if (match.Success)
                {
                    string delimiterSection = match.Groups[1].Value;
                    if (delimiterSection.StartsWith("[") && delimiterSection.EndsWith("]"))
                    {
                        // Handle multiple delimiters
                        var delimiters = delimiterSection.Trim('[', ']').Split(new[] { "][" }, StringSplitOptions.None);
                        delimiterPattern = string.Join("|", delimiters.Select(Regex.Escape));
                    }
                    else
                    {
                        // Handle single character delimiter
                        delimiterPattern = Regex.Escape(delimiterSection);
                    }
                    numberString = numbers.Substring(match.Length);
                }
            }

            // Split the numbers using the delimiter pattern
            string[] numberTokens = Regex.Split(numberString, delimiterPattern);

            // Validate the tokens to ensure no empty entries due to invalid delimiter placement
            for (int i = 0; i < numberTokens.Length - 1; i++)
            {
                if (string.IsNullOrEmpty(numberTokens[i]))
                {
                    throw new ArgumentException("Invalid input sequence.");
                }
            }

            List<int> numberList = new List<int>();
            List<int> negativeNumbers = new List<int>();

            foreach (string token in numberTokens)
            {
                if (int.TryParse(token, out int number))
                {
                    if (number < 0)
                    {
                        negativeNumbers.Add(number);
                    }
                    else
                    {
                        numberList.Add(number);
                    }
                }
            }

            if (negativeNumbers.Any())
            {
                throw new ArgumentException($"Negatives not allowed: {string.Join(", ", negativeNumbers)}");
            }

            return numberList.Sum();
        }
    }
}