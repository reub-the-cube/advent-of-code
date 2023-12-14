using aoc2023.day14.domain;
using System.ComponentModel;
using System.Data.Common;
using static aoc2023.day14.Enums;

namespace aoc2023.day14
{
    public class Platform
    {
        private RockPosition[,] Rocks { get; set; }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < Rocks.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < Rocks.GetUpperBound(1) + 1; j++)
                {
                    result += ((int)Rocks[i, j].RockType).ToString();
                }
            }
            return result;
        }

        public Platform(List<string> rockFormation)
        {
            var rowCount = rockFormation.Count;
            var columnCount = rockFormation[0].Length;

            Rocks = new RockPosition[rowCount, columnCount];

            FillRocks(rockFormation);
        }

        public void RunCycles(int numberOfCycles)
        {
            Dictionary<string, int> rockFormationIndexes = new()
            {
                { ToString(), 0 }
            };

            for (int i = 1; i < numberOfCycles + 1; i++)
            {
                TiltNorth();
                TiltWest();
                TiltSouth();
                TiltEast();

                if (!rockFormationIndexes.TryAdd(ToString(), i))
                {
                    // Repeated cycle
                    // Repeat sequence is from now to previous
                    var firstOccurence = rockFormationIndexes[ToString()];
                    var step = i - firstOccurence;
                    var targetOccurence = firstOccurence + ((numberOfCycles - i) % step);
                    var remainder = targetOccurence - firstOccurence;
                    RunCycles(remainder); // Get to 'numberOfCycles' state
                    break;
                }
            }
        }
        public void TiltNorth()
        {
            while (AnyRockCanRoll(Direction.North))
            {
                for (var i = 0; i < Rocks.GetUpperBound(0) + 1; i++)
                {
                    RollRowOfRocksNorth(i);
                }
            }
        }

        private void TiltWest()
        {
            while (AnyRockCanRoll(Direction.West))
            {
                for (var i = 0; i < Rocks.GetUpperBound(0) + 1; i++)
                {
                    RollRowOfRocksWest(i);
                }
            }
        }

        private void TiltSouth()
        {
            while (AnyRockCanRoll(Direction.South))
            {
                for (var i = 0; i < Rocks.GetUpperBound(0) + 1; i++)
                {
                    RollRowOfRocksSouth(i);
                }
            }
        }

        private void TiltEast()
        {
            while (AnyRockCanRoll(Direction.East))
            {
                for (var i = 0; i < Rocks.GetUpperBound(0) + 1; i++)
                {
                    RollRowOfRocksEast(i);
                }
            }
        }

        public RockType GetRockAtPosition(int row, int column)
        {
            return Rocks[row, column].RockType;
        }

        public long CalculateLoad()
        {
            var rowCount = Rocks.GetUpperBound(0);
            long load = 0;

            for (int i = 0; i < rowCount + 1; i++)
            {
                var roundedRocksOnRow = GetRoundedRocksOnRow(i);
                load += roundedRocksOnRow * (rowCount + 1 - i);
            }

            return load;
        }

        private void FillRocks(List<string> rockFormation)
        {
            // Build map
            var rowCount = rockFormation.Count;
            var columnCount = rockFormation[0].Length;

            Rocks = new RockPosition[rowCount, columnCount];

            for (var i = 0; i < rowCount; i++)
            {
                for (var j = 0; j < columnCount; j++)
                {
                    var rockType = GetRockType(rockFormation[i][j]);
                    SetRockPosition(i, j, rockType);
                }
            }
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

        private void RollRowOfRocksNorth(int row)
        {
            for (var j = 0; j < Rocks.GetUpperBound(1) + 1; j++)
            {
                if (RockCanRoll(row, j, Direction.North))
                {
                    SetRockPosition(row - 1, j, RockType.Rounded);
                    SetRockPosition(row, j, RockType.None);
                }
            }
        }

        private void RollRowOfRocksWest(int row)
        {
            for (var j = 0; j < Rocks.GetUpperBound(1) + 1; j++)
            {
                if (RockCanRoll(row, j, Direction.West))
                {
                    SetRockPosition(row, j - 1, RockType.Rounded);
                    SetRockPosition(row, j, RockType.None);
                }
            }
        }

        private void RollRowOfRocksSouth(int row)
        {
            for (var j = 0; j < Rocks.GetUpperBound(1) + 1; j++)
            {
                if (RockCanRoll(row, j, Direction.South))
                {
                    SetRockPosition(row + 1, j, RockType.Rounded);
                    SetRockPosition(row, j, RockType.None);
                }
            }
        }

        private void RollRowOfRocksEast(int row)
        {
            for (var j = 0; j < Rocks.GetUpperBound(1) + 1; j++)
            {
                if (RockCanRoll(row, j, Direction.East))
                {
                    SetRockPosition(row, j + 1, RockType.Rounded);
                    SetRockPosition(row, j, RockType.None);
                }
            }
        }

        private void SetRockPosition(int row, int column, RockType rockType)
        {
            Position thisPosition = new(row, column);
            Rocks[row, column] = new RockPosition(thisPosition, rockType);
        }

        private bool RockCanRoll(int row, int column, Direction direction)
        {
            var adjacentPosition = GetAdjacentPosition(row, column, direction);

            bool canRoll = Rocks[row, column].RockType == RockType.Rounded && adjacentPosition.HasValue;
            if (canRoll)
            {
                canRoll = Rocks[adjacentPosition.Value.Row, adjacentPosition.Value.Column].RockType == RockType.None;
            }

            return canRoll;
        }

        private Position? GetAdjacentPosition(int row, int column, Direction direction)
        {
            Position? adjacentPosition = null;

            if (direction == Direction.North)
            {
                if (row > 0)
                {
                    adjacentPosition = new Position(row - 1, column);
                }
            }

            if (direction == Direction.West)
            {
                if (column > 0)
                {
                    adjacentPosition = new Position(row, column - 1);
                }
            }

            if (direction == Direction.South)
            {
                if (row < Rocks.GetUpperBound(0))
                {
                    adjacentPosition = new Position(row + 1, column);
                }
            }

            if (direction == Direction.East)
            {
                if (column < Rocks.GetUpperBound(1))
                {
                    adjacentPosition = new Position(row, column + 1);
                }
            }

            return adjacentPosition;
        }

        private bool AnyRockCanRoll(Direction direction)
        {
            var anyRockCanRoll = false;

            for (int i = 0; i < Rocks.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < Rocks.GetUpperBound(1) + 1; j++)
                {
                    if (RockCanRoll(i, j, direction))
                    {
                        anyRockCanRoll = true;
                        break;
                    }
                }

                if (anyRockCanRoll) break;
            }

            return anyRockCanRoll;
        }

        private int GetRoundedRocksOnRow(int row)
        {
            var roundedRockCount = 0;

            for (var j = 0; j < Rocks.GetUpperBound(1) + 1; j++)
            {
                if (Rocks[row, j].RockType == RockType.Rounded) roundedRockCount++;
            }

            return roundedRockCount;
        }
    }
}
