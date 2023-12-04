using AoC.Core;
using aoc2023.day04.domain;

namespace aoc2023.day04
{
    public class Parser : IParser<Input>
    {
        public Input ParseInput(string[] input)
        {
            var scratchcards = new List<Scratchcard>();

            for (int i = 0; i< input.Length; i++)
            {
                var cardDetail = input[i].Split(':', '|');
                var winningNumbers = cardDetail[1];
                var cardNumbers = cardDetail[2];

                scratchcards.Add(new Scratchcard(i + 1, ParseListOfNumbers(winningNumbers), ParseListOfNumbers(cardNumbers)));
            }

            return new Input(scratchcards);
        }

        private static List<int> ParseListOfNumbers(string numberString)
        {
            var arrayOfNumbers = numberString.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            return arrayOfNumbers.Select(int.Parse).ToList();
        }
    }
}
