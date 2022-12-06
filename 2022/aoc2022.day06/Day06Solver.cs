using AoC.Core;
using System.Diagnostics;

namespace aoc2022.day06;

public class Day06Solver : IDaySolver
{
    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var firstMarkerPositions = input.Select(s => GetFirstMarkerPosition(s, 4)).ToList();
        var answerOne = string.Join(',', firstMarkerPositions);

        firstMarkerPositions = input.Select(s => GetFirstMarkerPosition(s, 14)).ToList();
        var answerTwo = string.Join(",", firstMarkerPositions);

        return (answerOne, answerTwo);
    }

    public static int GetFirstMarkerPosition(string datastreamBuffer, int numberOfDistinctCharacters)
    {
        var startNotFound = true;
        var startingIndex = numberOfDistinctCharacters - 1;

        while (startNotFound)
        {
            string? activeSequence = datastreamBuffer.Substring(startingIndex - numberOfDistinctCharacters + 1, numberOfDistinctCharacters);
            if (activeSequence.Length == activeSequence.Distinct().Count())
            {
                startNotFound = false;
            }
            startingIndex++;
        }
        return startingIndex;
    }
}
