namespace Test2.Common.Helper
{
    public static class ConvertToVerbatimStringHelper
    {
        public static string ConvertToVerbatimString(string input)
        {
            // Replace escaped newlines with actual newlines
            input = input.Replace("\\n", "\n");
            return input;
        }
    }
}
