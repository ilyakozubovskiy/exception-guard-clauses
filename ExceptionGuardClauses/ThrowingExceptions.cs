using System;
using System.Globalization;

namespace ExceptionGuardClauses
{
    public static class ThrowingExceptions
    {
        public static int ConvertHexCharToInteger(char c)
        {
            if (int.TryParse($"{c}", NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int result))
            {
                return result;
            }

            throw new ArgumentException("c is not a hex char.", nameof(c));
        }

        public static char GetLastCharacter(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentNullException(nameof(str), $"{nameof(str)} is null.");
            }

            return str[^1];
        }

        public static string GenerateUserCode(string code, int day)
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException(nameof(code), $"{nameof(code)} is null.");
            }

            if (code.Length != 4)
            {
                throw new ArgumentException($"{nameof(code)} has {code.Length} chars.", nameof(code));
            }

            if (day <= 0 || day >= 100)
            {
                throw new ArgumentOutOfRangeException(nameof(day), $"{nameof(day)} should be greater than zero and less than 100");
            }

            return code + day.ToString(CultureInfo.InvariantCulture);
        }

        public static string GenerateGreeting(string hello, string[] addressee, int index)
        {
            if (string.IsNullOrEmpty(hello))
            {
                throw new ArgumentNullException(nameof(hello), $"{nameof(hello)} is null.");
            }

            if (addressee is null)
            {
                throw new ArgumentNullException(nameof(addressee), $"{nameof(addressee)} is null.");
            }

            if (addressee.Length == 0)
            {
                throw new ArgumentException($"array is empty", nameof(addressee));
            }

            if (index < 0 || index >= addressee.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"{index} is out of range");
            }

            return $"{hello}, {addressee[index]}!";
        }

        public static string GetArrayValue(int[] indexArray, int indexArrayPosition, string[] valueArray)
        {
            if (indexArray is null)
            {
                throw new ArgumentNullException(nameof(indexArray), $"{nameof(indexArray)} is null.");
            }

            if (indexArray.Length == 0)
            {
                throw new ArgumentException($"{nameof(indexArray)} is empty.", nameof(indexArray));
            }

            if (valueArray is null)
            {
                throw new ArgumentNullException(nameof(valueArray), $"{nameof(valueArray)} is null");
            }

            if (valueArray.Length == 0)
            {
                throw new ArgumentException($"{nameof(valueArray)} is empty.", nameof(valueArray));
            }

            if (indexArrayPosition < 0 || indexArrayPosition >= indexArray.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(indexArrayPosition), $"{nameof(indexArrayPosition)} is out of range.");
            }

            int position = indexArray[indexArrayPosition];

            if (position < 0 || position >= valueArray.Length)
            {
                 return valueArray[position];
            }

            return valueArray[position];
        }
    }
}
