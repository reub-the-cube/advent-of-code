using AoC.Core;
using aoc2020.day02.domain;

namespace aoc2020.day02;

public class Day02Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day02Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);

        return (CalculateAnswerOne(parsedInput.PolicyPasswordPairs), CalculateAnswerTwo(parsedInput.PolicyPasswordPairs));
    }

    private static string CalculateAnswerOne(List<KeyValuePair<Policy, string>> passwords)
    {
        try
        {
            var validPasswords = passwords.Where(p => PasswordIsValidByOccurrence(p.Key, p.Value));
            return $"{validPasswords.Count()}";
        }
        catch (Exception ex)
        {
            return ex.ToString();
        }
    }

    private static string CalculateAnswerTwo(List<KeyValuePair<Policy, string>> passwords)
    {
        try
        {
            var validPasswords = passwords.Where(p => PasswordIsValidByIndex(p.Key, p.Value));
            return $"{validPasswords.Count()}";
        }
        catch (Exception ex)
        {
            return ex.ToString();
        }
    }

    private static bool PasswordIsValidByOccurrence(Policy policy, string password)
    {
        var characterCount = password.Where(p => p == policy.SearchFor).Count();
        return characterCount >= policy.Min && characterCount <= policy.Max;
    }

    private static bool PasswordIsValidByIndex(Policy policy, string password)
    {
        var characterAtMin = password[policy.Min - 1];
        var characterAtMax = password[policy.Max - 1];

        var characterOneMatch = characterAtMin == policy.SearchFor;
        var characterTwoMatch = characterAtMax == policy.SearchFor;

        return (characterOneMatch && !characterTwoMatch) || (characterTwoMatch && !characterOneMatch);
    }
}
