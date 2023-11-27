using AoC.Core;
using aoc2020.day03.domain;

namespace aoc2020.day03
{
    public class Parser : IParser<Input>
    {
        public Input ParseInput(string[] input)
        {
            var numberOfRows = input.Length;
            var numberOfColumns = input[0].Length;
            var grid = new Square[numberOfRows, numberOfColumns];

            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    grid[i, j] = input[i][j] switch
                    {
                        '#' => Square.Tree,
                        _ => Square.Open,
                    };
                }
            }

            return new Input(grid);
        }
    }
}
