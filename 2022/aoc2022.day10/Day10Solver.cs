using AoC.Core;
using aoc2022.day10.domain;
using System.Text;

namespace aoc2022.day10;

public class Day10Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day10Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);

        int cycleCounter = 0;
        int xRegisterValue = 1;
        List<int> signalStrengthDuringCycleAtCheckpoints = new ();
        StringBuilder answerTwo = new ();
        answerTwo.AppendLine();

        foreach (var instruction in parsedInput.Instructions)
        {
            while (!instruction.IsFinished())
            {
                instruction.IncreaseCycleCounter();

                cycleCounter++;
                if (cycleCounter % 40 == 20)
                {
                    if (cycleCounter > 220) throw new NotImplementedException();
                    signalStrengthDuringCycleAtCheckpoints.Add(cycleCounter * xRegisterValue);
                }

                var indexOfRow = (cycleCounter % 40);
                if ((indexOfRow >= xRegisterValue) && (indexOfRow <= xRegisterValue + 2))
                {
                    answerTwo.Append('#');
                }
                else
                {
                    answerTwo.Append('.');
                }

                if (indexOfRow == 0) answerTwo.AppendLine();
            }

            xRegisterValue += instruction.XRegisterIncreaseOnCompletion;
        }

        return (signalStrengthDuringCycleAtCheckpoints.Sum().ToString(), answerTwo.ToString());
    }
}
