using aoc2023.day14.domain;
using static aoc2023.day14.Enums;

namespace aoc2023.day14
{
    public class Platform
    {
        private RockPosition[,] Rocks { get; set; }

        public Platform(List<string> rockFormation)
        {
            Rocks = MapRockFormationToArray(rockFormation);
        }

        public void TiltNorth()
        {

        }

        public RockType GetRockAtPosition(int row, int column)
        {
            return Rocks[row, column].RockType;
        }

        private static RockPosition[,] MapRockFormationToArray(List<string> rockFormation)
        {
            // Build map
            var rowCount = rockFormation.Count;
            var columnCount = rockFormation[0].Length;

            var rocks = new RockPosition[rowCount, columnCount];

            for (var i = 0; i < rowCount; i++)
            {
                for (var j = 0; j < columnCount; j++)
                {
                    var rockType = GetRockType(rockFormation[i][j]);
                    Position? positionAbove = i > 0 ? new Position(i - 1, j) : null;
                    rocks[i, j] = new RockPosition(new Position(i, j), positionAbove, rockType);
                }
            }

            return rocks;
        }

        private static RockType GetRockType(char formationCharacter)
        {
            return formationCharacter switch
            {
                '#' => RockType.Cubed,
                'O' => RockType.Rounded,
                '.' => RockType.None,
                _ => throw new InvalidOperationException($"Formation character '{formationCharacter}' not recognised.")
            };
        }
    }
}
