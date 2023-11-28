using System.Data;
using System.Runtime.InteropServices;
using AoC.Core;
using aoc2020.day04.domain;

namespace aoc2020.day04;

public class Day04Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day04Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);

        var answerOne = "TODO";
        try {
            var numberOfValidPassports = parsedInput.Passports.Count(IsPassportValidForSimpleCase);
            answerOne = $"{numberOfValidPassports}";
        }
        catch (Exception ex) {
            answerOne = ex.ToString();
        }

        var answerTwo = "Not implemented";
        try {
            var numberOfValidPassports = parsedInput.Passports.Count(IsPassportValidForComplexCase);
            answerTwo = $"{numberOfValidPassports}";
        }
        catch {
        }

        return (answerOne, answerTwo);
    }

    public static bool IsPassportValidForSimpleCase(Passport passport) {
        if (string.IsNullOrEmpty(passport.BirthYear)) {
            return false;
        }

        if (string.IsNullOrEmpty(passport.IssueYear)) {
            return false;
        }

        if (string.IsNullOrEmpty(passport.ExpirationYear)) {
            return false;
        }

        if (string.IsNullOrEmpty(passport.Height)) {
            return false;
        }

        if (string.IsNullOrEmpty(passport.HairColour)) {
            return false;
        }

        if (string.IsNullOrEmpty(passport.EyeColour)) {
            return false;
        }

        if (string.IsNullOrEmpty(passport.PassportId)) {
            return false;
        }

        return true;
    }

    public static bool IsPassportValidForComplexCase(Passport passport) {
        if (!YearIsValid(passport.BirthYear, 1920, 2002)) {
            return false;
        }

        if (!YearIsValid(passport.IssueYear, 2010, 2020)) {
            return false;
        }

        if (!YearIsValid(passport.ExpirationYear, 2020, 2030)) {
            return false;
        }

        if (!HeightIsValid(passport.Height)) {
            return false;
        }

        if (!HairColourIsValid(passport.HairColour)) {
            return false;
        }

        if (!EyeColourIsValid(passport.EyeColour)) {
            return false;
        }

        if (!PassportIdIsValid(passport.PassportId)) {
            return false;
        }

        return true;
    }

    private static bool YearIsValid(string? year, int minYear, int maxYear) 
    {
        if (year == null) {
            return false;
        }

        if (!year.All(char.IsDigit)) {
            return false;
        }

        if (!int.TryParse(year, out int yearValue)) {
            return false;
        }

        if (yearValue < minYear || yearValue > maxYear) {
            return false;
        }

        return true;
    }

    private static bool HeightIsValid(string? height) {
        var scaleMeasure = height?.Substring(height.Length - 2, 2);
        _ = int.TryParse(height?[..^2], out int heightValue);

        return scaleMeasure switch
        {
            "cm" => HeightIsValid(heightValue, 150, 193),
            "in" => HeightIsValid(heightValue, 59, 76),
            _ => false,
        };
    }

    private static bool HeightIsValid(int height, int min, int max) {
        if (height < min || height > max) {
            return false;
        }

        return true;
    }

    private static bool HairColourIsValid(string? hairColour) {
        if (hairColour == null) {
            return false;
        }

        if (hairColour[0] != '#') {
            return false;
        }

        if (!hairColour.Skip(1).All(char.IsAsciiHexDigit)) {
            return false;
        }

        return true;
    }

    private static bool EyeColourIsValid(string? eyeColour) {
        if (eyeColour == null) {
            return false;
        }

        var validEyeColours = new[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
        if (!validEyeColours.Contains(eyeColour)) {
            return false;
        }

        return true;
    }

    private static bool PassportIdIsValid(string? passportId) {
        if (passportId == null) {
            return false;
        }

        if (passportId.Length != 9) {
            return false;
        }

        if (!passportId.All(char.IsDigit)) {
            return false;
        }

        return true;
    }
}