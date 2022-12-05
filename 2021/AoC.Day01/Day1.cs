using AoC.Core;

namespace AoC.Day01;

public class Day1 : IDaySolver
{
    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var sonarScannerReport = new SonarScannerReport(Array.ConvertAll(input, Parser.ParseLine));
        var answerOne = sonarScannerReport.GetIncreasesInDepthByDay();
        var answerTwo = sonarScannerReport.GetIncreasesInDepthBySlidingWindow();

        return (answerOne.ToString(), answerTwo.ToString());
    }
}