namespace AoC.Core;

public interface IDaySolver
{
    (int AnswerOne, int AnswerTwo) CalculateAnswers(string[] input);
}