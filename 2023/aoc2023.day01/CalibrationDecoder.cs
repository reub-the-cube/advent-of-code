using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace aoc2023.day01
{
    public static class CalibrationDecoder
    {
        public static (int firstDigit, int lastDigit) GetFirstAndLastDigit(string inputLine)
        {
            return GetFirstAndLastDigit(inputLine, false);
        }

        public static (int firstDigit, int lastDigit) GetFirstAndLastDigit(string inputLine, bool decodeWords)
        {
            var regexString = decodeWords ? "(?=(one|two|three|four|five|six|seven|eight|nine|[0-9]))" : "(?=([0-9]))";
            var decoderRegex = new Regex(regexString);

            var matches = decoderRegex.Matches(inputLine);
            var first = int.Parse(NumberTextToNumberDigit(matches.First().Groups[1].Value));
            var last = int.Parse(NumberTextToNumberDigit(matches.Last().Groups[1].Value));
            return (first, last);
        }

        private static string NumberTextToNumberDigit(string value)
        {
            return value switch
            {
                "one" => "1",
                "two" => "2",
                "three" => "3",
                "four" => "4",
                "five" => "5",
                "six" => "6",
                "seven" => "7",
                "eight" => "8",
                "nine" => "9",
                _ => value,
            };
        }
        public static int MakeCalibratedValue(int firstDigit, int lastDigit)
        {
            return int.Parse($"{firstDigit}{lastDigit}");
        }
    }
}
