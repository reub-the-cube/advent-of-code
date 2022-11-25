// See https://aka.ms/new-console-template for more information

using AoC.Day01;

Console.WriteLine("Hello!");
Console.WriteLine("Which day's challenges would you like to run? Use a number from 1 to 25.");
var dayNumberInput = Console.ReadLine();

var dayNumber = ValidateDayNumber(dayNumberInput);
if (dayNumber.IsValid) InitialiseChallenge(dayNumber.Value);

Console.WriteLine("Press any key to finish.");
Console.ReadKey();

void InitialiseChallenge(int day)
{
    var input = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"day{day}input.txt"));

    var dayProcesser = new Day1();
    dayProcesser.Initialise(input);
    var challengeOneOuput = dayProcesser.ChallengeOne();
    Console.WriteLine($"Final answer for day {day}, challenge 1: {challengeOneOuput}");

    var challengeTwoOutput = dayProcesser.ChallengeTwo();
    Console.WriteLine($"Final answer for day {day}, challenge 2: {challengeTwoOutput}");
}

(bool IsValid, int Value) ValidateDayNumber(string? number)
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

