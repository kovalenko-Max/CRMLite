using System;
using System.Text;

namespace CRMLite.CRMCore.Helper
{
    public static class StringGenerator
    {
        private static readonly Random _random;

        static StringGenerator()
        {
            _random = new Random();
        }

        public static string GenerateString(int minLength = 10, int maxLength = 20)
        {
            var messageLength = _random.Next(minLength, maxLength);
            var generatedString = new StringBuilder(string.Empty);
            for (int i = 0; i < messageLength; i++)
            {
                generatedString.Append(GetRandomChar());
            }

            return generatedString.ToString();
        }

        private static char GetRandomChar()
        {
            char result = ' ';
            switch (_random.Next(1, 5))
            {
                case 1:
                    result = (char)_random.Next('A', 'Z');
                    break;
                case 2:
                    result = (char)_random.Next('a', 'z');
                    break;
                case 3:
                    result = (char)_random.Next('0', '9');
                    break;
                case 4:
                    result = (char)_random.Next('!', '/');
                    break;
                case 5:
                    result = (char)_random.Next(':', '@');
                    break;
            }

            return result;
        }
    }
}
