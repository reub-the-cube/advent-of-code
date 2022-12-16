using System.Diagnostics;

namespace aoc2022.day15.domain;

public readonly record struct Sensor(Position Position, Position ClosestBeacon, int DistanceToClosestBeacon)
{
    public Sensor(Position Position, Position ClosestBeacon) : this(Position, ClosestBeacon, Position.GetManhattanDistance(ClosestBeacon))
    {
    }

    public bool CoversPosition(Position checkAgainst)
    {
        return Position.GetManhattanDistance(checkAgainst) <= DistanceToClosestBeacon;
    }

    public List<int> GetColumnCoordinatesCoveredBySensorOnARow(int row)
    {
        var columnsCoveredByTheSensor = new List<int>();
        
        // Check if row is in distance on the same column
        var gapFromSensorToTargetRow = DistanceToClosestBeacon - Math.Abs(Position.Row - row);
        if (gapFromSensorToTargetRow >= 0)
        {
            return Enumerable.Range(Position.Column - gapFromSensorToTargetRow, (gapFromSensorToTargetRow * 2) + 1).ToList();
        }

        return columnsCoveredByTheSensor;
    }

    public List<int> GetColumnCoordinatesCoveredBySensorOnARow(int row, int minColumnIndex, int maxColumnIndex)
    {
        var columnsCoveredByTheSensor = new List<int>();

        // Check if row is in distance on the same column
        var gapFromSensorToTargetRow = DistanceToClosestBeacon - Math.Abs(Position.Row - row);
        if (gapFromSensorToTargetRow >= 0)
        {
            var extremeLowerBound = Position.Column - gapFromSensorToTargetRow;
            var extremeUpperBound = Position.Column + gapFromSensorToTargetRow;
            if (extremeLowerBound <= maxColumnIndex && extremeUpperBound >= minColumnIndex)
            {
                var startIndex = Math.Max(extremeLowerBound, minColumnIndex);
                return Enumerable.Range(startIndex, Math.Min(extremeUpperBound, maxColumnIndex) - startIndex + 1).ToList();
            }
        }

        return columnsCoveredByTheSensor;
    }

    public List<Position> GetPositionsJustOutOfRangeOfSensor(int maxIndex, int minIndex)
    {
        var outOfRangePositions = new List<Position>();

        for (int rowIndex = Math.Max(Position.Row - DistanceToClosestBeacon - 1, minIndex); rowIndex < Math.Min(Position.Row + DistanceToClosestBeacon + 1, maxIndex) + 1; rowIndex++)
        {
            var columnOffsetForOutOfRange = DistanceToClosestBeacon + 1 - Math.Abs(Position.Row - rowIndex);
            if (columnOffsetForOutOfRange == 0)
            {
                if (Position.Column >= minIndex && Position.Column <= maxIndex)
                {
                    outOfRangePositions.Add(new Position(rowIndex, Position.Column));
                }
            }
            else if (columnOffsetForOutOfRange > 0)
            {
                if (Position.Column - columnOffsetForOutOfRange >= minIndex && Position.Column - columnOffsetForOutOfRange <= maxIndex)
                {
                    outOfRangePositions.Add(new Position(rowIndex, Position.Column - columnOffsetForOutOfRange));
                }
                if (Position.Column + columnOffsetForOutOfRange >= minIndex && Position.Column + columnOffsetForOutOfRange <= maxIndex)
                {
                    outOfRangePositions.Add(new Position(rowIndex, Position.Column + columnOffsetForOutOfRange));
                }
            }
        }

        return outOfRangePositions;
    }

    public Dictionary<int, List<int>> GetColumnAndRowCoordinatesCoveredBySensor(int minRowIndex, int maxRowIndex, int minColumnIndex, int maxColumnIndex)
    {
        var columnsCoveredByTheSensor = new Dictionary<int, List<int>>();

        // Check if row is in distance on the same column
        var startRow = Math.Max(minRowIndex, Position.Row - DistanceToClosestBeacon);
        var endRow = Math.Min(maxRowIndex, Position.Row + DistanceToClosestBeacon);

        for (int rowIndex = startRow; rowIndex < endRow + 1; rowIndex++)
        {
            var coveredColumnsForRow = new List<int>();
            var gapFromSensorToTargetRow = DistanceToClosestBeacon - Math.Abs(Position.Row - rowIndex);
            if (gapFromSensorToTargetRow >= 0)
            {
                var extremeLowerBound = Position.Column - gapFromSensorToTargetRow;
                var extremeUpperBound = Position.Column + gapFromSensorToTargetRow;
                if (extremeLowerBound <= maxColumnIndex && extremeUpperBound >= minColumnIndex)
                {
                    var startIndex = Math.Max(extremeLowerBound, minColumnIndex);
                    coveredColumnsForRow = Enumerable.Range(startIndex, Math.Min(extremeUpperBound, maxColumnIndex) - startIndex + 1).ToList();
                }
            }

            if (coveredColumnsForRow.Any())
            {
                columnsCoveredByTheSensor.Add(rowIndex, coveredColumnsForRow);
            }
        }

        return columnsCoveredByTheSensor;
    }
}