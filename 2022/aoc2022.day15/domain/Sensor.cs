namespace aoc2022.day15.domain;

public readonly record struct Sensor(Position Position, Position ClosestBeacon)
{
    private int DistanceToClosestBeacon() => Position.GetManhattanDistance(ClosestBeacon);

    public List<int> GetColumnCoordinatesCoveredBySensorOnARow(int row)
    {
        var columnsCoveredByTheSensor = new List<int>();
        
        var distanceToClosestBeacon = DistanceToClosestBeacon();
        
        // Check if row is in distance on the same column
        var gapFromSensorToTargetRow = Math.Abs(Position.Row - row) - distanceToClosestBeacon;
        if (gapFromSensorToTargetRow < 0)
        {
            return Enumerable.Range(Position.Column - Math.Abs(gapFromSensorToTargetRow),
                Math.Abs(gapFromSensorToTargetRow) * 2 + 1).ToList();
        }

        return columnsCoveredByTheSensor;
    }
}