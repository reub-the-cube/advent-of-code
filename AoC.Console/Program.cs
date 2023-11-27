// See https://aka.ms/new-console-template for more information

using AoC.Console;
using AoC.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services.ConfigureDayServices())
    .Build();

// Could do this intelligently with automation
var implementedYearsAndDays = new Dictionary<int, List<int>>()
{
    { 2020, new List<int> { 1, 2, 3 } },
    { 2021, new List<int> { 1, 2, 3, 4 } },
    { 2022, new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 20 } },
    { 2023, new List<int> { 1 } }
};

var deltaStopwatch = new Stopwatch();

ParseArgs();

void ParseArgs()
{
    int todayIndex = Array.IndexOf(args, "--today");
    int allIndex = Array.IndexOf(args, "--all");
    int yearArgIndex = Array.IndexOf(args, "--year");
    int dayArgIndex = Array.IndexOf(args, "--day");

    if (todayIndex > -1)
    {
        RunToday();
    }
    else if (allIndex > -1)
    {
        RunAll();
    }
    else if (yearArgIndex > -1)
    {
        RunYear(yearArgIndex, dayArgIndex);
    }
    else if (dayArgIndex > -1)
    {
        Console.WriteLine("Argument --day cannot be used without the --year argument.");
    }
    else
    {
        PromptForYearAndDay();
    }
}

void RunAll()
{
    if (args.Length > 1)
    {
        Console.WriteLine("Argument --all cannot be used with any other arguments.");
    }
    else
    {
        PrepareAll();
    }
}

void RunYear(int yearArgIndex, int dayArgIndex)
{
    string yearArg = yearArgIndex > -1 ? args[yearArgIndex + 1] : string.Empty;

    var (YearIsValid, YearValue) = ValidateNumber(yearArg, implementedYearsAndDays.Keys.Min(), implementedYearsAndDays.Keys.Max());

    if (YearIsValid)
    {
        if (dayArgIndex == -1)
        {
            // No --day arg, run the whole year
            PrepareYear(YearValue);
        }
        else
        {
            var (DayIsValid, DayValue) = ValidateNumber(args[dayArgIndex + 1], 1, 25);
            if (DayIsValid) PrepareDay(YearValue, DayValue);
        }
    }
}

void RunToday()
{
    int year = DateTime.Now.Year;
    int day = DateTime.Now.Day;
    PrepareDay(year, day);
}

void PromptForYearAndDay()
{
    Console.WriteLine($"Which year's challenges would you like to run? Use `all` or a number from {implementedYearsAndDays.Keys.Min()} to {implementedYearsAndDays.Keys.Max()}.");
    var yearNumberInput = Console.ReadLine();

    if (yearNumberInput == "all")
    {
        PrepareAll();
    }
    else
    {
        var (YearIsValid, YearValue) = ValidateNumber(yearNumberInput, implementedYearsAndDays.Keys.Min(), implementedYearsAndDays.Keys.Max());

        if (YearIsValid)
        {
            Console.WriteLine($"Which day's challenges would you like to run? Use `all` or a number from {implementedYearsAndDays[YearValue].Min()} to {implementedYearsAndDays[YearValue].Max()}.");
            var dayNumberInput = Console.ReadLine();

            if (dayNumberInput == "all")
            {
                PrepareYear(YearValue);
            }
            else
            {
                var (DayIsValid, DayValue) = ValidateNumber(dayNumberInput, implementedYearsAndDays[YearValue].Min(), implementedYearsAndDays[YearValue].Max());

                if (DayIsValid) PrepareDay(YearValue, DayValue);
            }

        }
    }

    Console.WriteLine("Press any key to finish, or press return to play again.");
    if (Console.ReadKey().Key == ConsoleKey.Enter)
    {
        Console.WriteLine();
        PromptForYearAndDay();
    }
}

void PrepareAll()
{
    Stopwatch stopwatch = Stopwatch.StartNew();
    foreach (var year in implementedYearsAndDays.Keys)
    {
        foreach (var day in implementedYearsAndDays[year])
        {
            SolveDay(year, day);
        }
    }
    stopwatch.Stop();
    Console.WriteLine($"Elapsed time (ms): {stopwatch.ElapsedMilliseconds}");
    Console.WriteLine($"Elapsed calculation time (ms): {deltaStopwatch.ElapsedMilliseconds}");
}

void PrepareYear(int year)
{
    Stopwatch stopwatch = Stopwatch.StartNew();
    foreach (var day in implementedYearsAndDays[year])
    {
        SolveDay(year, day);
    }
    stopwatch.Stop();
    Console.WriteLine($"Elapsed time (ms): {stopwatch.ElapsedMilliseconds}");
    Console.WriteLine($"Elapsed calculation time (ms): {deltaStopwatch.ElapsedMilliseconds}");
}

void PrepareDay(int year, int day)
{
    Stopwatch stopwatch = Stopwatch.StartNew();
    SolveDay(year, day);
    stopwatch.Stop();
    Console.WriteLine($"Elapsed time (ms): {stopwatch.ElapsedMilliseconds}");
    Console.WriteLine($"Elapsed calculation time (ms): {deltaStopwatch.ElapsedMilliseconds}");
}

void SolveDay(int year, int day)
{
    try
    {
        var dayServiceResolver = host.Services.GetService<Func<(int, int), IDaySolver>>() ?? throw new InvalidOperationException("Day service resolver not found.");
        var daySolver = dayServiceResolver((year, day));
        var dayFormatted = day.ToString("00");

        var input = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{year}", $"day{dayFormatted}input.txt"));
        deltaStopwatch.Start();
        var (AnswerOne, AnswerTwo) = daySolver.CalculateAnswers(input);
        deltaStopwatch.Stop();

        Console.WriteLine($"Final answer for year {year}, day {dayFormatted}, challenge 1: {AnswerOne}");
        Console.WriteLine($"Final answer for year {year}, day {dayFormatted}, challenge 2: {AnswerTwo}");
    }
    catch (NotImplementedException)
    {
        Console.WriteLine($"Year {year}, day {day} not implemented");
    }
}

(bool IsValid, int Value) ValidateNumber(string? number, int min, int max)
{
    var isValid = int.TryParse(number, out var parsedNumber);

    if ((parsedNumber < min) || (parsedNumber > max))
    {
        Console.WriteLine("This input was not valid. Please try again.");
        isValid = false;
    }

    return (isValid, parsedNumber);
}