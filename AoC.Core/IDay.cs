namespace AoC.Core;

public interface IDay
{
    (int AnswerOne, int AnswerTwo) CalculateAnswers(string[] input);
}