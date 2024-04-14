using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CommonLibs
{
    public static class ValidationData
    {
        public static bool ContainsNumber(string input)
        {
            if (input.Any(char.IsDigit))
            {
                return true;
            }
            else
                return false;
        }
        public static bool CheckContainSpecialChar(string input)
        {
            Regex specialCharRegex = new Regex(@"[~`!@#$%^&*()+=|\\{}':;,.<>?/""-]");
            if (specialCharRegex.IsMatch(input))
            {
                return true;
            }
            else
                return false;
        }
        public static bool CheckIsNullOrWhiteSpace(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return true;
            }
            else
                return false;
        }
        public static bool ContainsLetter(string input)
        {
            foreach (char c in input)
            {
                if (Char.IsLetter(c))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
