using AoC.Core;
using aoc2023.day01.domain;

namespace aoc2023.day01;

public class Day01Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day01Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);

        var answerOne = CalculateAnswerOne(parsedInput.CalibrationValues);
        var answerTwo = CalculateAnswerTwo(parsedInput.CalibrationValues);

        return (answerOne, answerTwo);
    }

    private static string CalculateAnswerOne(string[] calibrationValues)
    {
        try
        {
            return $"{calibrationValues.Sum(c => CalculateCalibrationValue(c, false))}";
        }
        catch (Exception e)
        {
            return $"{e.Message}: {e.GetBaseException().Message}";
        }
    }

    private static string CalculateAnswerTwo(string[] calibrationValues)
    {
        try
        {
            return $"{calibrationValues.Sum(c => CalculateCalibrationValue(c, true))}";
        }
        catch (Exception e)
        {
            return $"{e.Message}: {e.GetBaseException().Message}";
        }
    }

    private static int CalculateCalibrationValue(string calibrationInput, bool decodeWords)
    {
        var (firstDigit, lastDigit) = CalibrationDecoder.GetFirstAndLastDigit(calibrationInput, decodeWords);
        var calibratedValue = CalibrationDecoder.MakeCalibratedValue(firstDigit, lastDigit);

        return calibratedValue;
    }
}
