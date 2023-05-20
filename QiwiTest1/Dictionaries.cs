using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QiwiTest1
{
    internal class Dictionaries
    {
        public const string HUNDRED = "hundred";
        public const string ANDCAPS = "AND";
        public const string AND = "and";
        public const string DOLLARS = "DOLLARS";
        public const string DOLLAR = "DOLLAR";
        public const string CENTS = "CENTS";
        public const string CENT = "CENT";
        public const string NOTHING = "zero DOLLARS AND zero CENTS";
        public const string INCORRECT_FORMAT = "Input was not in correct format";
        public const string NON_NEGATIVE = "Input string must be non negative";
        public const string TOO_LARGE = "Input number must be less than 2000000000";
        public static char DecimalSeparator => System.Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
        public static Dictionary<int, string> digitDictionary = new()
        {
            {1, "one" },
            {2, "two" },
            {3, "three" },
            {4, "four" },
            {5, "five" },
            {6, "six" },
            {7, "seven" },
            {8, "eight" },
            {9, "nine" }
        };
        public static Dictionary<int, string> teensDictionary = new() {
            {10, "ten" },
            {11, "eleven" },
            {12, "twelve" },
            {13, "thirteen" },
            {14, "fourteen" },
            {15, "fifteen" },
            {16, "sixteen" },
            {17, "seventeen" },
            {18, "eighteen" },
            {19, "nineteen" }
        };
        public static Dictionary<int, string> tensDictionary = new()
        {
            {2, "twenty" },
            {3, "thirty" },
            {4, "forty" },
            {5, "fifty" },
            {6, "sixty" },
            {7, "seventy" },
            {8, "eighty" },
            {9, "ninety" }
        };
        public static Dictionary<byte, string> magnitudesDictionary = new()
        {
            {1, "thousand" },
            {2, "million" },
            {3, "billion" }
        };
    }
}
