using AoC.Core;
using aoc2022.day20.domain;

namespace aoc2022.day20;

public class Day20Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day20Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);

        var workingListAnswerOne = Decryptor.MixListOfNumbers(parsedInput.OriginalNumbers, 1, 1);
        var workingListAnswerTwo = Decryptor.MixListOfNumbers(parsedInput.OriginalNumbers, 811589153, 10);

        var answerOne = GetAnswer(workingListAnswerOne);
        var answerTwo = GetAnswer(workingListAnswerTwo);

        return (answerOne.ToString(), answerTwo.ToString());
    }

    private static long GetAnswer(List<KeyValuePair<long, long>> coordinateCode)
    {
        var zeroItems = coordinateCode.Where(cc => cc.Value == 0);
        if (zeroItems.Count() > 1)
        {
            throw new Exception("Only expected one 0 entry.");
        }

        var indexOfZero = coordinateCode.IndexOf(zeroItems.First());

        var indexOf1000th = (1000 + indexOfZero + 1) % coordinateCode.Count;
        var indexOf2000th = (2000 + indexOfZero + 1) % coordinateCode.Count;
        var indexOf3000th = (3000 + indexOfZero + 1) % coordinateCode.Count;

        var valueAt1000th = coordinateCode[indexOf1000th - 1].Value;
        var valueAt2000th = coordinateCode[indexOf2000th - 1].Value;
        var valueAt3000th = coordinateCode[indexOf3000th - 1].Value;

        return valueAt1000th + valueAt2000th + valueAt3000th;
    }
}
