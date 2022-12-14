using AoC.Core;
using aoc2022.day14.domain;

namespace aoc2022.day14
{
    public class Parser : IParser<Input>
    {
        public Input ParseInput(string[] input)
        {
            // x represents distance to the right and y represents distance down

            int skipLastCount = 0;
            if (input.Last() == "row-of-rocks")
            {
                skipLastCount = 1;
            }

            var allIndexes = input
                .SkipLast(skipLastCount)
                .SelectMany(s => s.Split(" -> "))   // all coordinates
                .Select(s => s.Split(','))          // array of all coordinates
                .ToList();

            var xPositions = allIndexes.Select(s => Convert.ToInt32(s[0])).ToList();
            var yPositions = allIndexes.Select(s => Convert.ToInt32(s[1])).ToList();

            var additionalColumns = 0;
            var additionalRows = 0;
            if (skipLastCount == 1)
            {
                additionalColumns = 1000;
                additionalRows = 2;
            }

            var columnOffset = xPositions.Min();
            var numberOfFilledColumns = xPositions.Max() + additionalColumns + 1;
            var numberOfFilledRows = yPositions.Max() + additionalRows + 1;

            var tiles = new Tile[numberOfFilledRows, numberOfFilledColumns];

            for (var i = 0; i < numberOfFilledRows; i++)
            {
                for (var j = 0; j < numberOfFilledColumns; j++)
                {
                    tiles[i, j] = new Tile(new Position(i, j), TileState.Air);
                }
            }

            var cave = new CaveSlice(tiles);
            foreach (var inputRow in input)
            {
                if (inputRow == "row-of-rocks")
                {
                    cave = cave.AddLineOfRocksAcrossTheFloor();
                }
                else
                {
                    cave = cave.AddLineOfRocks(inputRow);
                }
            }

            return new Input(cave, columnOffset);
        }
    }
}
