using System.Diagnostics;
using AoC.Core;

namespace AoC.Day01;

public class Day1 : IDay
{
    public (int AnswerOne, int AnswerTwo) CalculateAnswers(string[] input)
    {
        var sonarScannerReport = new SonarScannerReport(Array.ConvertAll(input, Parser.ParseLine));
        var answerOne = sonarScannerReport.GetIncreasesInDepthByDay();
        var answerTwo = sonarScannerReport.GetIncreasesInDepthBySlidingWindow();

        return (answerOne, answerTwo);
    }
}