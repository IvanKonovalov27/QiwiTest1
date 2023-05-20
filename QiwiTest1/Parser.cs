//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace QiwiTest1
//{
//    public class Parser
//    {
//        const string HUNDRED = "hundred";
//        const string ANDCAPS = "AND";
//        const string AND = "and";
//        const string DOLLARS = "DOLLARS";
//        const string CENTS = "CENTS";
//        const string NOTHING = "zero DOLLARS AND zero CENTS";
//        const string INCORRECT_FORMAT = "Input was not in correct format";
//        char DecimalSeparator => System.Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
//        Dictionary<char, string> digitDictionary = new()
//        {
//            {'1', "one" },
//            {'2', "two" },
//            {'3', "three" },
//            {'4', "four" },
//            {'5', "five" },
//            {'6', "six" },
//            {'7', "seven" },
//            {'8', "eight" },
//            {'9', "nine" }
//        };
//        Dictionary<string, string> teensDictionary = new() {
//            {"10", "ten" },
//            {"11", "eleven" },
//            {"12", "twelve" },
//            {"13", "thirteen" },
//            {"14", "fourteen" },
//            {"15", "fifteen" },
//            {"16", "sixteen" },
//            {"17", "seventeen" },
//            {"18", "eighteen" },
//            {"19", "nineteen" }
//        };
//        Dictionary<char, string> tensDictionary = new()
//        {
//            {'2', "twenty" },
//            {'3', "thirty" },
//            {'4', "forty" },
//            {'5', "fifty" },
//            {'6', "sixty" },
//            {'7', "seventy" },
//            {'8', "eighty" },
//            {'9', "ninety" }
//        };
//        Dictionary<byte, string> magnitudesDictionary = new()
//        {
//            {1, "thousand" },
//            {2, "million" },
//            {3, "billion" }
//        };

//        public string Convert(string input)
//        {
//            if(string.IsNullOrEmpty(input))
//                return "Input string is empty";
//            StringBuilder sb = new StringBuilder();
//            List<string> reverseResultWords = new();

//            int charIndex = input.Length - 1;

//            string buffer;
//            byte orderOfMagnitude = 0;
//            charIndex = ParseCents(input, charIndex, out buffer);
//            bool needCentsAnd = false;
//            if (!string.IsNullOrEmpty(buffer))
//            {
//                reverseResultWords.Add(CENTS);
//                needCentsAnd = true;
//                reverseResultWords.Add(buffer);
//            }
//            bool hasDollars = false;
//            while (charIndex >= 0)
//            {
//                var triadWords = ParseDiad(input, charIndex);
//                if(triadWords.Any())
//                    triadWords.Add(AND);
//                charIndex -= 2;
//                if (charIndex >= 0)
//                {
//                    if (input[charIndex] != '0' && digitDictionary.TryGetValue(input[charIndex], out var hundredDigitWord))
//                    {
//                        triadWords.Add(HUNDRED);
//                        triadWords.Add(hundredDigitWord);
//                    }
//                }
//                if(!hasDollars && triadWords.Any())
//                {
//                    if (needCentsAnd)
//                        reverseResultWords.Add(ANDCAPS);
//                    reverseResultWords.Add(DOLLARS);
//                    hasDollars = true;
//                }
//                if (triadWords.Any() && magnitudesDictionary.TryGetValue(orderOfMagnitude, out string magnitude))
//                {
//                    if(reverseResultWords.Last() == AND
//                        || reverseResultWords.Last() == DOLLARS)
//                        reverseResultWords.Add($"{magnitude}");
//                    else
//                        reverseResultWords.Add($"{magnitude},");

//                }
//                reverseResultWords.AddRange(triadWords);
//                orderOfMagnitude++;
//                charIndex -= 1;
//            }

//            if (reverseResultWords.Any() 
//                && string.Compare(reverseResultWords.Last(), AND) == 0)
//                reverseResultWords.RemoveAt(reverseResultWords.Count - 1);
//            return reverseResultWords.Any()
//                ? sb.AppendJoin(' ', EnumerateBackwards(reverseResultWords))
//                     .ToString()
//                : NOTHING;
//        }

//        int ParseCents(string parsingString, int currentIndex, out string parsed)
//        {
//            parsed = string.Empty;
//            if (parsingString.Length < 2)
//                return currentIndex;
//            if (parsingString[currentIndex - 1] == DecimalSeparator)
//            {
//                parsed = tensDictionary[parsingString[currentIndex]];
//                return currentIndex - 2;
//            }
//            if (parsingString.Length < 3)
//                return currentIndex;
//            if (parsingString[currentIndex - 2] == DecimalSeparator)
//            {
//                var words = ParseDiad(parsingString, currentIndex);
//                parsed = new StringBuilder().AppendJoin(' ', EnumerateBackwards(words)).ToString();
//                return currentIndex - 3;
//            }
//            return currentIndex;
//        }

//        bool TryParseDiad(string parsingString, int currentIndex, out List<string> parsedWords)
//        {
//            if (currentIndex != 0 && parsingString[currentIndex - 1] == '1')
//            {
//                parsedWords = new() { teensDictionary[parsingString.Substring(currentIndex - 1, 2)] };
//                return true;
//            }

//            parsedWords = new();
//            if (parsingString[currentIndex] != '0')
//            {
//                //if(!digitDictionary.TryGetValue()
//                //parsedWords.Add(digitDictionary[parsingString[currentIndex]]);
//            }

//            if (currentIndex > 0 && parsingString[currentIndex - 1] != '0')
//                parsedWords.Add(tensDictionary[parsingString[currentIndex - 1]]);

//            return true;
//        }

//        IEnumerable<T> EnumerateBackwards<T>(List<T> list)
//        {
//            for (int i = list.Count - 1; i >= 0; i--)
//            {
//                yield return list[i];
//            }
//        }
//    }
//}
