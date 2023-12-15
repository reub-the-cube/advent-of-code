using AoC.Core;
using aoc2023.day15.domain;

namespace aoc2023.day15;

public class Day15Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day15Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);

        var answerOne = CalculateAnswerOne(parsedInput.InitialisationSequenceSteps);
        var answerTwo = CalculateAnswerTwo(parsedInput.InitialisationSequenceSteps);

        return (answerOne, answerTwo);
    }

    private static string CalculateAnswerOne(List<string> initialisationSequenceSteps)
    {
        try
        {
            var sumOfSequence = initialisationSequenceSteps.Sum(Hasher.HashString);
            return $"{sumOfSequence}";
        }
        catch (Exception e) when (e.GetType() != typeof(NotImplementedException))
        {
            return $"{e.Message}: {e.GetBaseException().Message}";
        }
    }

    private static string CalculateAnswerTwo(List<string> initialisationSequenceSteps)
    {
        try
        {
            var stepHandler = new StepHandler();
            foreach (var step in initialisationSequenceSteps)
            {
                stepHandler.ProcessStep(step);
            }

            long focusPower = 0;
            for (var boxNumber = 0; boxNumber < 256; boxNumber++)
            {
                var lenses = stepHandler.GetLenses(boxNumber);
                focusPower += FocusPower.Calculate(boxNumber, lenses);
            }
            return $"{focusPower}";

            // Wrong answers 
            // Too high 246309
            // Too low  242594
        }
        catch (Exception e) when (e.GetType() != typeof(NotImplementedException))
        {
            return $"{e.Message}: {e.GetBaseException().Message}";
        }
    }
}
