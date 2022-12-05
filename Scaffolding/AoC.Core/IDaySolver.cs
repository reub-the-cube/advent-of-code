namespace AoC.Core;

public interface IDaySolver
{
    (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input);
}