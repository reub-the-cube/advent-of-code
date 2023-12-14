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
                RunCycle();

                if (!rockFormationIndexes.TryAdd(ToString(), i))
                {
                    GetFinishingStateForManyCycles(rockFormationIndexes[ToString()], i, numberOfCycles);
                    break;
                }
            }
        }

        public void TiltNorth()
        {
            Tilt(Direction.North);
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

        private void RunCycle()
        {
            Tilt(Direction.North);
            Tilt(Direction.West);
            Tilt(Direction.South);
            Tilt(Direction.East);
        }

        private void Tilt(Direction direction)
        {
            while (AnyRockCanRoll(direction))
            {
                for (var i = 0; i < Rocks.GetUpperBound(0) + 1; i++)
                {
                    RollRowOfRocks(i, direction);
                }
            }
        }

        private void GetFinishingStateForManyCycles(int firstOccurence, int currentCycle, int numberOfCycles)
        {
            // Repeated cycle
            // Repeat sequence is from now to previous
            var step = currentCycle - firstOccurence;
            var targetOccurence = firstOccurence + ((numberOfCycles - currentCycle) % step);
            var remainder = targetOccurence - firstOccurence;
            RunCycles(remainder); // Get to final 'numberOfCycles' state
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

        private void RollRowOfRocks(int row, Direction direction)
        {
            for (var j = 0; j < Rocks.GetUpperBound(1) + 1; j++)
            {
                var (CanRoll, AdjacentPosition) = RockCanRoll(row, j, direction);
                if (CanRoll && AdjacentPosition.HasValue)
                {
                    SetRockPosition(AdjacentPosition.Value.Row, AdjacentPosition.Value.Column, RockType.Rounded);
                    SetRockPosition(row, j, RockType.None);
                }
            }
        }

        private void SetRockPosition(int row, int column, RockType rockType)
        {
            Position thisPosition = new(row, column);
            Rocks[row, column] = new RockPosition(thisPosition, rockType);
        }

        private (bool CanRoll, Position? AdjacentPosition) RockCanRoll(int row, int column, Direction direction)
        {
            var adjacentPosition = GetAdjacentPosition(row, column, direction);

            bool canRoll = adjacentPosition.HasValue && 
                Rocks[row, column].RockType == RockType.Rounded &&
                Rocks[adjacentPosition.Value.Row, adjacentPosition.Value.Column].RockType == RockType.None;

            return (canRoll, adjacentPosition);
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
                    if (RockCanRoll(i, j, direction).CanRoll)
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
