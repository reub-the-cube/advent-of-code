using AoC.Core;
using AoC.Day02.Models;

namespace AoC.Day02;
public class Day2 : IDay
{
    private readonly IParser<Input> _parser;
    
    public Day2(IParser<Input> parser)
    {
        _parser = parser;
    }
    
    public (int AnswerOne, int AnswerTwo) CalculateAnswers(string[] input)
    {
        var plannedCourse = _parser.ParseInput(input);
        var calculationOne = JourneyPredictor.ProjectFinalHorizontalPositionAndDepth(plannedCourse);
        var calculationTwo = JourneyPredictor.ProjectFinalHorizontalPositionAndDepthUsingAim(plannedCourse);

        var answerOne = calculationOne.HorizontalChange * calculationOne.DepthChange;
        var answerTwo = calculationTwo.HorizontalChange * calculationTwo.DepthChange;
        return (answerOne, answerTwo);
    }
}
