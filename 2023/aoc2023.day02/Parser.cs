using AoC.Core;
using aoc2023.day02.domain;
using System.Runtime.CompilerServices;

namespace aoc2023.day02
{
    public class Parser : IParser<Input>
    {
        private readonly Bag bag = new(12, 13, 14);

        public Input ParseInput(string[] input)
        {
            var games = new List<Game>();

            for (int i = 0; i < input.Length; i++)
            {
                var game = new Game(bag, i + 1);

                var handfuls = input[i].Split(':')[1].Split(';');
                foreach (var handful in handfuls)
                {
                    game.TakeHandfulFromBag(GetHandfulItemFromString(handful));
                }

                games.Add(game);
            }

            return new Input(games);
        }

        private Handful GetHandfulItemFromString(string handfulInput)
        {
            var handfulParts = handfulInput.Split(' ');
            var handful = new Handful(0, 0, 0);

            for (int i = 0; i < handfulParts.Length; i += 2)
            {
                if (handfulParts[i].Contains("red"))
                {
                    handful = handful.AddRedCubes(int.Parse(handfulParts[i - 1]));
                }

                if (handfulParts[i].Contains("green"))
                {
                    handful = handful.AddGreenCubes(int.Parse(handfulParts[i - 1]));
                }


                if (handfulParts[i].Contains("blue"))
                {
                    handful = handful.AddBlueCubes(int.Parse(handfulParts[i - 1]));
                }
            }

            return handful;
        }
    }
}
