using AoC.Core;
using System.Diagnostics;

namespace aoc2022.day06;

public class Day06Solver : IDaySolver
{
    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var firstMarkerPositions = input.Select(GetFirstMarkerPosition).ToList();
        var answerOne = string.Join(',', firstMarkerPositions);

        return (answerOne, string.Empty);
    }

    public static int GetFirstMarkerPosition(string datastreamBuffer)
    {
        var startNotFound = true;
        var startingIndex = 3; // 4 characters in

        while (startNotFound)
        {
            string? activeSequence = datastreamBuffer.Substring(startingIndex - 3, 4);
            if (activeSequence.Length == activeSequence.Distinct().Count())
            {
                startNotFound = false;
            }
            startingIndex++;
        }
        return startingIndex;
    }
}
