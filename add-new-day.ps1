param([Parameter(Mandatory=$true)][int]$year,
      [Parameter(Mandatory=$true)][int]$day)

function Get-UnitTestContent() {
    $unitTestContent = @"
using FluentAssertions;

namespace aoc$($year).day$($day.ToString("00")).tests;

public class Day$($day.ToString("00"))SolverTests
{
    private readonly string[] INPUT = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "Inputs", "$($year)", "day$($day.ToString("00"))testinput.txt"));
    private const string EXPECTED_ANSWER_ONE = "not_implemented"; // <--------- solution from web page test example goes here
    private const string EXPECTED_ANSWER_TWO = "not_implemented"; // <--------- solution from web page test example goes here

    [Fact]
    public void InputLoadsCorrectly()
    {
        INPUT.Length.Should().BeGreaterThan(0);
    }

    [Fact]
    public void CalculatedAnswerOneMatchesTestCase()
    {
        var parser = new Parser();
        var day$($day.ToString("00")) = new Day$($day.ToString("00"))Solver(parser);

        var (answerOne, _) = day$($day.ToString("00")).CalculateAnswers(INPUT);

        answerOne.Should().Be(EXPECTED_ANSWER_ONE);
    }

    [Fact]
    public void CalculatedAnswerTwoMatchesTestCase()
    {
        var parser = new Parser();
        var day$($day.ToString("00")) = new Day$($day.ToString("00"))Solver(parser);

        var (_, answerTwo) = day$($day.ToString("00")).CalculateAnswers(INPUT);
        
        answerTwo.Should().Be(EXPECTED_ANSWER_TWO);
    }
}
"@
    return $unitTestContent
}

function Get-ServiceCollectionContentForNewYear([int]$year) {
    $serviceCollectionContent = @"
using AoC.Core;
using aoc$($year).day01;
using Microsoft.Extensions.DependencyInjection;

namespace AoC.Console
{
    public static class ServiceCollection$($year)
    {
        public static IServiceCollection Configure$($year)Services(this IServiceCollection services)
        {
            return services
                .ConfigureDay01Services();
        }

        public static IDaySolver ResolveDayFor$($year)(this IServiceProvider serviceProvider, int day)
        {
            return day switch
            {
                1 => serviceProvider.GetService<Day01Solver>() ?? throw new InvalidOperationException(),
                _ => throw new NotImplementedException($"Day service provider has not been configured for day {day} this year.")
            };
        }
    }
}
"@
    return $serviceCollectionContent
}

if (!(Test-Path -Path .\Inputs\$($year))) {
   New-Item .\Inputs\$($year) -ItemType Directory
}

if (!(Test-Path -Path .\Inputs\$($year)\day$($day.ToString("00"))input.txt)) {
   New-Item .\Inputs\$($year)\day$($day.ToString("00"))input.txt
}
if (!(Test-Path -Path .\Inputs\$($year)\day$($day.ToString("00"))testinput.txt)) {
   New-Item .\Inputs\$($year)\day$($day.ToString("00"))testinput.txt
}

if (!(Test-Path -Path .\$($year))) {
    New-Item .\$($year) -ItemType Directory
}

cd .\$($year)
if (!(Test-Path -Path "aoc-$($year).sln" -PathType Leaf)) {
    dotnet new sln --name "aoc-$($year)"
	dotnet sln add .\..\AoC.Console\
}

$projectName = "aoc$($year).day$($day.ToString("00"))"
$testProjectName = "$($projectName).tests"

if (Test-Path -Path .\$($projectName) -PathType Container) {
    Write-Host("$($projectName) folder already exists. You might want to try creating a different day, or maybe you have the wrong year.")
    cd ..
    Return;
}

dotnet new aoc-dayx -n $($projectName) -o $($projectName)
dotnet new xunit -n "$($testProjectName)" -o "$($testProjectName)"

dotnet sln add $($projectName)
dotnet sln add "$($testProjectName)"

dotnet add $(Join-Path . .. AoC.Console AoC.Console.csproj) reference $(Join-Path . $($projectName) $($projectName).csproj)
dotnet add $(Join-Path . $testProjectName) reference $(Join-Path . $($projectName) $($projectName).csproj)
dotnet add $(Join-Path . $testProjectName) package FluentAssertions

if (!(Test-Path -Path ..\AoC.Console\ServiceCollection$($year).cs)) {
    $newYearServiceCollectionContent = Get-ServiceCollectionContentForNewYear($year)
    Set-Content ..\AoC.Console\ServiceCollection$($year).cs $newYearServiceCollectionContent
}

New-Item .\$($testProjectName)\Day$($day.ToString("00"))SolverTests.cs
$testContent = Get-UnitTestContent
Set-Content .\$($testProjectName)\Day$($day.ToString("00"))SolverTests.cs $testContent
Remove-Item .\$($testProjectName)\UnitTest1.cs

$serviceCollectionContent = (Get-Content .\$($projectName)\ServiceCollection.cs)
$newServiceCollectionContent = $serviceCollectionContent -replace "DayX","Day$($day.ToString("00"))"
Set-Content .\$($projectName)\ServiceCollection.cs $newServiceCollectionContent

$dayXSolverContent = (Get-Content .\$($projectName)\DayXSolver.cs)
$newDayXSolverContent = $dayXSolverContent -replace "DayX","Day$($day.ToString("00"))"
Set-Content .\$($projectName)\Day$($day.ToString("00"))Solver.cs $newDayXSolverContent
Remove-Item .\$($projectName)\DayXSolver.cs

Write-Host("Now do the following:");
Write-Host("---	Update .\..\AoC.Console project:");
Write-Host("	a) ServiceCollection.cs - add new project services and update service resolver");
Write-Host("")

cd ..