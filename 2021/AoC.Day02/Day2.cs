﻿using AoC.Core;
using AoC.Day02.Models;

namespace AoC.Day02;
public class Day2 : IDaySolver
{
    private readonly IParser<MachineReadout> _parser;
    
    public Day2(IParser<MachineReadout> parser)
    {
        _parser = parser;
    }
    
    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var plannedCourse = _parser.ParseInput(input);
        var calculationOne = JourneyPredictor.ProjectFinalHorizontalPositionAndDepth(plannedCourse.Inputs);
        var calculationTwo = JourneyPredictor.ProjectFinalHorizontalPositionAndDepthUsingAim(plannedCourse.Inputs);

        var answerOne = calculationOne.HorizontalChange * calculationOne.DepthChange;
        var answerTwo = calculationTwo.HorizontalChange * calculationTwo.DepthChange;
        return (answerOne.ToString(), answerTwo.ToString());
    }
}
