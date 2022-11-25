// See https://aka.ms/new-console-template for more information

using AoC.Day01;

Console.WriteLine("Hello!");
Console.WriteLine("Which day's challenges would you like to run? Use a number from 1 to 25.");
var challengeNumberInput = Console.ReadLine();

var challengeNumber = ValidateChallengeNumber(challengeNumberInput);
if (challengeNumber.IsValid) InitialiseChallenge(challengeNumber.Value);

Console.WriteLine("Press any key to finish.");
Console.ReadKey();

void InitialiseChallenge(int day)
{
    var input = File.ReadAllLines($"day{day}input.txt");

    var sonarScannerReport = new SonarScannerReport(input);
    var numberOfIncreases = sonarScannerReport.GetIncreasesInDepthByDay();
    Console.WriteLine($"Final answer: {numberOfIncreases}");

    var numberOfSlidingIncreases = sonarScannerReport.GetIncreasesInDepthBySlidingWindow();
    Console.WriteLine($"Final answer: {numberOfSlidingIncreases}");
}

(bool IsValid, int Value) ValidateChallengeNumber(string? number)
{
    var isValid = int.TryParse(number, out var parsedNumber);
    
    switch (parsedNumber)
    {
        case 1:
            Console.WriteLine("This challenge is under construction.");
            break;
        case >= 2 and <= 25:
            Console.WriteLine("This challenge hasn't been implemented.");
            break;
        default:
            Console.WriteLine("This input was not valid. Please try again.");
            break;
    }

    return (isValid, parsedNumber);
}

