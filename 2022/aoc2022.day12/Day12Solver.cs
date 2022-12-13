using AoC.Core;
using aoc2022.day12.domain;

namespace aoc2022.day12;

public class Day12Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day12Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);

        var shortestPath = FindShortestPath(parsedInput.StartingPosition, parsedInput.EndingPosition, parsedInput.Heights);
        var answerOne = shortestPath.HasValue ? $"{shortestPath.ToString()}" : "no answer";

        var map = Map.Build(parsedInput.Heights);
        var nodesToVisit = map.GetPositionsOfCertainHeight(1);
        shortestPath = 9999999;
        while (nodesToVisit.Count > 0)
        {
            var startingPosition = nodesToVisit.Pop();
            var thisShortestPath = FindShortestPath(startingPosition, parsedInput.EndingPosition, parsedInput.Heights);
            if (thisShortestPath.HasValue)
            {
                shortestPath = Math.Min(shortestPath.Value, thisShortestPath.Value);
            }
        }
        var answerTwo = $"{shortestPath.Value.ToString()}";

        return (answerOne, answerTwo);
    }

    private static int? FindShortestPath(Position startingPosition, Position endingPosition, int[][] heights)
    {
        var map = Map.Build(heights);

        var numberOfSteps = 0;
        var nodesToVisit = new List<Position> {startingPosition};
        map = map.MarkAsVisited(startingPosition);
        var nextNodesToVisit = new List<Position>();
        while (true)
        {
            if (nodesToVisit.Contains(endingPosition))
            {
                break;
            }

            if (!nodesToVisit.Any())
            {
                return null;
            }
            
            numberOfSteps++;

            foreach (var nodeToVisit in nodesToVisit)
            {
                // get neighbours
                var nextNeighbours = map.GetUnvisitedAvailableNeighbours(nodeToVisit);

                foreach (var neighbour in nextNeighbours)
                {
                    map = map.MarkAsVisited(neighbour);
                }

                nextNodesToVisit.AddRange(nextNeighbours);
            }

            nodesToVisit = nextNodesToVisit.Distinct().ToList();
            nextNodesToVisit.Clear();
        }

        return numberOfSteps;
    }
}
