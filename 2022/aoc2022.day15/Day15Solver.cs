using AoC.Core;
using aoc2022.day15.domain;
using System.Diagnostics;

namespace aoc2022.day15;

public class Day15Solver : IDaySolver
{
    private readonly IParser<Input> _parser;
    private readonly ISolverConfig _solverConfig;

    public Day15Solver(IParser<Input> parser, ISolverConfig solverConfig)
    {
        _parser = parser;
        _solverConfig = solverConfig;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);

        var columnsThatAreCovered = new List<int>();
        var positionsThatAreCoveredByASensor = parsedInput.Sensors
            .SelectMany(s => s.GetColumnCoordinatesCoveredBySensorOnARow(_solverConfig.RowToInspectForPartOne))
            .Distinct();
        var positionsThatAreAlreadyABeacon = parsedInput.Sensors
            .Where(s => s.ClosestBeacon.Row == _solverConfig.RowToInspectForPartOne)
            .Select(s => s.ClosestBeacon.Column)
            .Distinct();

        var takenRange = positionsThatAreCoveredByASensor.Except(positionsThatAreAlreadyABeacon).Count();

        var positionsThatAreJustOutOfRangeOfASensor = parsedInput.Sensors
            .SelectMany(s => s.GetPositionsJustOutOfRangeOfSensor(_solverConfig.MaxIndexForPartTwo, _solverConfig.MinIndexForPartTwo))
            .Distinct()
            .ToList();
        var positionsThatAreNotInRangeOfAnySensor = positionsThatAreJustOutOfRangeOfASensor
            .Where(p => parsedInput.Sensors.All(s => !s.CoversPosition(p)))
            .ToList();

        var missingPosition = positionsThatAreNotInRangeOfAnySensor.FirstOrDefault();

        //var chunkingStep = 25000;
        //Position? missingPosition = new Position(0, 0);
        //for (int minRowIndex = _solverConfig.MinIndexForPartTwo; minRowIndex < _solverConfig.MaxIndexForPartTwo + 1; minRowIndex += chunkingStep)
        //{
        //    for (int minColumnIndex = _solverConfig.MinIndexForPartTwo; minColumnIndex < _solverConfig.MaxIndexForPartTwo + 1; minColumnIndex += chunkingStep)
        //    {
        //        Debug.WriteLine($"Mapping block from (X={minColumnIndex}, Y={minRowIndex}) to (X={minColumnIndex + chunkingStep}, Y={minRowIndex + chunkingStep}).");
        //        var maxRowIndex = Math.Min(_solverConfig.MaxIndexForPartTwo, minRowIndex + chunkingStep - 1);
        //        var maxColumnIndex = Math.Min(_solverConfig.MaxIndexForPartTwo, minColumnIndex + chunkingStep - 1);

        //        var coveredCoordinates = GetCoveredCoordinatesForRange(parsedInput.Sensors, minRowIndex, maxRowIndex, minColumnIndex, maxColumnIndex);
        //        missingPosition = GetMissingCoordinate(coveredCoordinates, minColumnIndex, maxColumnIndex);
        //        if (missingPosition != null) break;
        //    }
        //    if (missingPosition != null) break;
        //}

        //Position? missingPosition = new Position(0, 0);
        //var sensorsOrderedByReach = parsedInput.Sensors.OrderByDescending(s => s.DistanceToClosestBeacon).ToList();
        //var stopwatch = new Stopwatch();
        //stopwatch.Start();
        //for (int rowIndex = _solverConfig.MinIndexForPartTwo; rowIndex < _solverConfig.MaxIndexForPartTwo + 1; rowIndex++)
        //{
        //    if (rowIndex % 50 == 0)
        //    {
        //        Debug.WriteLine($"Mapping row {rowIndex}, delta: {stopwatch.ElapsedMilliseconds}");
        //        stopwatch.Restart();
        //    }

        //    var coveredCoordinates = GetCoveredCoordinatesForRow(parsedInput.Sensors, rowIndex, _solverConfig.MinIndexForPartTwo, _solverConfig.MaxIndexForPartTwo);
        //    missingPosition = GetMissingCoordinateForRow(coveredCoordinates, rowIndex, _solverConfig.MinIndexForPartTwo, _solverConfig.MaxIndexForPartTwo);
        //    if (missingPosition != null) break;
        //}

        var tuningFrequency = (Convert.ToInt64(4000000) * missingPosition.Column) + missingPosition.Row;

        return (takenRange.ToString(), tuningFrequency.ToString());
    }

    private static Dictionary<int, List<int>> GetCoveredCoordinatesForRange(List<Sensor> sensors, int minRowIndex, int maxRowIndex, int minColumnIndex, int maxColumnIndex)
    {
        var coveredCoordinates = new Dictionary<int, List<int>>();
        foreach (var sensor in sensors)
        {
            var coordinatesCoveredBySensor = sensor.GetColumnAndRowCoordinatesCoveredBySensor(minRowIndex, maxRowIndex, minColumnIndex, maxColumnIndex);

            //Debug.WriteLine($"Got coords for sensor at position X={sensor.Position.Column}, Y={sensor.Position.Row}.");

            foreach (var item in coordinatesCoveredBySensor)
            {
                if (!coveredCoordinates.ContainsKey(item.Key))
                {
                    coveredCoordinates.Add(item.Key, new List<int>());
                }

                coveredCoordinates[item.Key].AddRange(item.Value);
                coveredCoordinates[item.Key] = coveredCoordinates[item.Key].Distinct().ToList();
            }
        }

        return coveredCoordinates;
    }

    private static List<int> GetCoveredCoordinatesForRow(List<Sensor> sensors, int rowIndex, int minColumnIndex, int maxColumnIndex)
    {
        var coveredCoordinates = new List<int>();
        foreach (var sensor in sensors)
        {
            var coordinatesCoveredBySensor = sensor.GetColumnCoordinatesCoveredBySensorOnARow(rowIndex, minColumnIndex, maxColumnIndex);
            coveredCoordinates.AddRange(coordinatesCoveredBySensor);
            coveredCoordinates = coveredCoordinates.Distinct().ToList();

            if (coveredCoordinates.Count == maxColumnIndex - minColumnIndex + 1)
            {
                break;
            }
        }

        return coveredCoordinates;
    }

    private static Position? GetMissingCoordinate(Dictionary<int, List<int>> covered, int minColumnIndex, int maxColumnIndex)
    {
        var maximumNumberOfColumns = maxColumnIndex - minColumnIndex + 1;
        var allPossibleColumns = Enumerable.Range(minColumnIndex, maximumNumberOfColumns).ToList();

        foreach (var item in covered)
        {
            if (item.Value.Count != maximumNumberOfColumns)
            {
                var missingColumn = allPossibleColumns.Except(item.Value).FirstOrDefault();
                return new Position(missingColumn, item.Key);
            }
        }

        return null;
    }

    private static Position? GetMissingCoordinateForRow(List<int> covered, int rowIndex, int minColumnIndex, int maxColumnIndex)
    {
        var maximumNumberOfColumns = maxColumnIndex - minColumnIndex + 1;

        if (covered.Count < maximumNumberOfColumns)
        {
            var allPossibleColumns = Enumerable.Range(minColumnIndex, maximumNumberOfColumns).ToList();
            var missingColumn = allPossibleColumns.Except(covered).FirstOrDefault();
            return new Position(missingColumn, rowIndex);
        }

        return null;
    }
}
