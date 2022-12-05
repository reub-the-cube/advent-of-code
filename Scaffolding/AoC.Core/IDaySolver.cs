namespace AoC.Core;

public interface IDaySolver<T>
{
    (T AnswerOne, T AnswerTwo) CalculateAnswers(string[] input);
}