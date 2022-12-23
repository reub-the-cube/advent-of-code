using System.Diagnostics;
using AoC.Core;
using aoc2022.day21.domain;
using System.Security.Cryptography;

namespace aoc2022.day21;

public class Day21Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day21Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);

        // Part 1
        var rootNumber = parsedInput.Riddle.GetMonkeyNumber("root");

        // Part 2
        // Wrong answers:   3782852515586 (too high)

        // Left monkey must equal right monkey, so change the operation to subtract and target the value 0
        parsedInput.Riddle.ChangeMonkeyOperation("root", parsedInput.Riddle.MonkeyOperations["root"].Left, parsedInput.Riddle.MonkeyOperations["root"].Right, "-");

        // Find a limit where the sign of the difference changes so we can start to split the difference
        var (humnLow, humnHigh, linearUp) = GetInitialMinMaxHumnValues(rootNumber, parsedInput.Riddle);

        // Hone in on the answer
        var nearHumnAnswer = FindHumnValueThatMakesRootZero(humnLow, humnHigh, parsedInput.Riddle, linearUp);
        var answerTwo = FindHumnValueWithPrecision(nearHumnAnswer, parsedInput.Riddle);

        Debug.Assert(parsedInput.Riddle.GetMonkeyNumber("root") == 0);
        Debug.Assert(parsedInput.Riddle.GetMonkeyNumber("humn") == answerTwo);
        Debug.Assert(parsedInput.Riddle.GetMonkeyNumber(parsedInput.Riddle.MonkeyOperations["root"].Left) ==
                     parsedInput.Riddle.GetMonkeyNumber(parsedInput.Riddle.MonkeyOperations["root"].Right));
        return (rootNumber.ToString(), answerTwo.ToString());
        //return (rootNumber.ToString(), 0.ToString());
    }

    private static (long HumnLow, long HumnHigh, bool LinearUp) GetInitialMinMaxHumnValues(long partOneAnswer, Riddle riddle)
    {
        var humnLow = (long)Math.Floor((double)partOneAnswer / 2);
        riddle.ChangeMonkeyNumber("humn", humnLow);
        var lowRootValue = riddle.GetMonkeyNumber("root");

        var humnHigh = partOneAnswer + humnLow;
        riddle.ChangeMonkeyNumber("humn", humnHigh);
        var highRootValue = riddle.GetMonkeyNumber("root");

        // Assume linear... as diff gets bigger, humn is bigger or vice versa
        var linearUp = lowRootValue < highRootValue;

        // Get a humn low that is below zero, and a humn high that is above zero (or vice versa)
        humnLow = GetHumnValueLimit(lowRootValue, linearUp, -partOneAnswer, riddle, humnLow);
        humnHigh = GetHumnValueLimit(highRootValue, !linearUp, partOneAnswer, riddle, humnHigh);

        return (humnLow, humnHigh, linearUp);
    }

    private static long GetHumnValueLimit(long targetValue, bool linearUp, long deltaStep, Riddle riddle, long humnValue)
    {
        while (targetValue > 0 && linearUp)
        {
            humnValue += deltaStep;
            riddle.ChangeMonkeyNumber("humn", humnValue);
            targetValue = riddle.GetMonkeyNumber("root");
        }

        while (targetValue < 0 && !linearUp)
        {
            humnValue += deltaStep;
            riddle.ChangeMonkeyNumber("humn", humnValue);
            targetValue = riddle.GetMonkeyNumber("root");
        }

        return humnValue;
    }

    private static long FindHumnValueThatMakesRootZero(long humnLow, long humnHigh, Riddle riddle, bool linearUp)
    {
        long humnValue = 0;
        long rootValue = -1;
        while (rootValue != 0)
        {
            humnValue = (long)Math.Round((double)(humnLow + humnHigh) / 2, MidpointRounding.ToEven);
            riddle.ChangeMonkeyNumber("humn", humnValue);
            rootValue = riddle.GetMonkeyNumber("root");

            if ((rootValue < 0 && linearUp) || (rootValue > 0 && !linearUp))
            {
                // increase lower bound
                humnLow = humnValue;
            }
            else
            {
                // decrease upper bound
                humnHigh = humnValue;
            }
        }

        return humnValue;
    }

    private static long FindHumnValueWithPrecision(long nearHumnAnswer, Riddle riddle)
    {
        long humnValue = nearHumnAnswer - 1;
        long rootValue = 0;
        bool success = false;
        while (rootValue == 0 && !success)
        {
            humnValue++;
            riddle.ChangeMonkeyNumber("humn", humnValue);
            
            try
            {
                rootValue = riddle.GetMonkeyNumberPrecisely("root");
                if (rootValue == 0) success = true;
            } 
            catch (MonkeyOperationException) { }
        }
        
        humnValue = nearHumnAnswer; 
        rootValue = 0;
        while (rootValue == 0 && !success)
        {
            humnValue--;
            riddle.ChangeMonkeyNumber("humn", humnValue);
            
            try
            {
                rootValue = riddle.GetMonkeyNumberPrecisely("root");
                if (rootValue == 0) success = true;
            } 
            catch (MonkeyOperationException) { }
        }

        return humnValue;
    }
}
