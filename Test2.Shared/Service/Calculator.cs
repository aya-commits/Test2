using System.Text;
using Test2.Shared.Extension;

namespace Test2.Shared.Service
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            var delimiters = new List<string> { ",", "\n" };
            var stringBuilder = new StringBuilder(numbers);

            // Check if the string specifies a custom delimiter
            if (stringBuilder.StartsWith("//"))
            {
                int delimiterLineEndIndex = stringBuilder.IndexOf("\n");
                if (delimiterLineEndIndex == -1)
                {
                    throw new Exception("Invalid input: Custom delimiter format is incorrect. Correct format: //[delimiter]\\n[numbers...]");
                }

                string delimiterLine = stringBuilder.ToString(2, delimiterLineEndIndex - 2);
                delimiters.Add(delimiterLine);
                stringBuilder.Remove(0, delimiterLineEndIndex + 1);
            }

            // Replace escaped newlines with actual newlines
            stringBuilder.Replace(@"\n", "\n");

            // Split the string by the delimiters
            var nums = stringBuilder.ToString().Split(delimiters.ToArray(), StringSplitOptions.None);

            // Convert the string numbers to integers
            var negatives = new List<int>();
            var result = 0;
            foreach (var num in nums)
            {
                if (string.IsNullOrWhiteSpace(num))
                {
                    throw new Exception("Invalid input: Delimiter cannot be followed by another delimiter without numbers in between.");
                }

                if (!int.TryParse(num, out int n))
                {
                    throw new Exception($"Invalid input: '{num}' is not a valid number.");
                }

                if (n < 0)
                {
                    negatives.Add(n);
                }
                else
                {
                    result += n;
                }
            }

            // Throw exception if there are negative numbers
            if (negatives.Any())
            {
                throw new Exception("Negatives not allowed: " + string.Join(", ", negatives));
            }

            return result;
        }
    }
}