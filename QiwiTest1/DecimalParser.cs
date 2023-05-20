using System.Text;

namespace QiwiTest1
{
    public class DecimalParser
    {
        public string Convert(string input)
        {
            if (string.IsNullOrEmpty(input))
                return "Input string is empty";

            if(!decimal.TryParse(input, out var inputNumber))
                return Dictionaries.INCORRECT_FORMAT;

            if (inputNumber > 2000000000)
                return Dictionaries.TOO_LARGE;

            if (inputNumber == 0m)
                return Dictionaries.NOTHING;

            if (inputNumber < 0)
                return Dictionaries.NON_NEGATIVE;

            List<string> reverseResultWords = new();
            if (inputNumber % 0.01m > 0)
                return Dictionaries.INCORRECT_FORMAT;

            var buffer = ParseCents(inputNumber).ToList();
            
            int intPart = (int)inputNumber;
            if (buffer.Any())
            {
                reverseResultWords.AddRange(buffer);
                if(intPart == 0)
                    return WordStackToString(reverseResultWords);
                reverseResultWords.Add(Dictionaries.ANDCAPS);
            }

            if (intPart == 1)
            {
                reverseResultWords.Add(Dictionaries.DOLLAR);
                reverseResultWords.Add(Dictionaries.digitDictionary[1]);
                return WordStackToString(reverseResultWords);
            }

            reverseResultWords.Add(Dictionaries.DOLLARS);
            byte magnitude = 0;
            while (intPart > 0)
            {
                var triadWords = ParseTriad(intPart % 1000).ToList();
                if (triadWords.Any()
                    && Dictionaries.magnitudesDictionary.TryGetValue(magnitude, out var magnitudeWord))
                    reverseResultWords.Add(reverseResultWords.Last() is not Dictionaries.AND and not Dictionaries.ANDCAPS and not Dictionaries.DOLLARS 
                                            ? $"{magnitudeWord},"
                                            : magnitudeWord);
                reverseResultWords.AddRange(triadWords);
                magnitude++;
                intPart /= 1000;
            }
            if (reverseResultWords.Last() is Dictionaries.AND or Dictionaries.ANDCAPS)
                reverseResultWords.RemoveAt(reverseResultWords.Count - 1);
            return WordStackToString(reverseResultWords);
        }

        private string WordStackToString(List<string> reverseResultWords) => 
            new StringBuilder().AppendJoin(' ', EnumerateBackwards(reverseResultWords))
                .ToString();

        IEnumerable<T> EnumerateBackwards<T>(List<T> list)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                yield return list[i];
            }
        }
        private IEnumerable<string> ParseCents(decimal input)
        {
            int diad = (int)((input % 1) * 100);
            if(diad == 1)
            {
                yield return Dictionaries.CENT;
                yield return Dictionaries.digitDictionary[1];
                yield break;
            }
            var diadWords = ParseDiad(diad);
            if (!diadWords.Any())
                yield break;
            yield return Dictionaries.CENTS;
            foreach (var word in diadWords)
                yield return word;
        }

        private IEnumerable<string> ParseTriad(int number)
        {
            if (number == 0)
                yield break;

            int smallDiad = number % 100;
            foreach (var word in ParseDiad(smallDiad))
                yield return word;
            if (smallDiad > 0)
                yield return Dictionaries.AND;
            if (number < 100)
                yield break;
            
            yield return Dictionaries.HUNDRED;
            yield return Dictionaries.digitDictionary[number / 100];
        }

        private IEnumerable<string> ParseDiad(int diad)
        {
            if (diad is >= 10 and < 20)
                yield return Dictionaries.teensDictionary[diad];
            else if (diad != 0)
            {
                int digit = diad % 10;
                if (digit > 0)
                    yield return Dictionaries.digitDictionary[digit];
                if (diad > 19)
                    yield return Dictionaries.tensDictionary[diad / 10];
            }
        }
    }
}
