using System.Text;

namespace Test2.Shared.Extension
{
    public static class StringBuilderExtensions
    {
        public static bool StartsWith(this StringBuilder sb, string value)
        {
            if (sb.Length < value.Length) return false;
            for (int i = 0; i < value.Length; i++)
            {
                if (sb[i] != value[i]) return false;
            }
            return true;
        }

        public static int IndexOf(this StringBuilder sb, string value)
        {
            for (int i = 0; i <= sb.Length - value.Length; i++)
            {
                int j;
                for (j = 0; j < value.Length; j++)
                {
                    if (sb[i + j] != value[j]) break;
                }
                if (j == value.Length) return i;
            }
            return -1;
        }
    }
}