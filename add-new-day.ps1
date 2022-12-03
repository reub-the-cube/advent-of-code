param([Parameter(Mandatory=$true)][int]$year,
      [Parameter(Mandatory=$true)][int]$day)

function Get-UnitTestContent() {
    $unitTestContent = @"
using FluentAssertions;

namespace aoc._$($year).day$($day.ToString("00")).tests;

public class Day$($day.ToString("00"))SolverTests
{
    private readonly string[] INPUT = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"..\\..\\..\\..\\..\\Inputs\\$($year)\\day$($day.ToString("00"))testinput.txt"));
    private const int EXPECTED_DAY_ONE_ANSWER = -1; // <--------- solution from web page test example goes here
    private const int EXPECTED_DAY_TWO_ANSWER = -1; // <--------- solution from web page test example goes here

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

        answerOne.Should().Be(EXPECTED_DAY_ONE_ANSWER);
    }

    [Fact]
    public void CalculatedAnswerTwoMatchesTestCase()
    {
        var parser = new Parser();
        var day$($day.ToString("00")) = new Day$($day.ToString("00"))Solver(parser);

        var (_, answerTwo) = day$($day.ToString("00")).CalculateAnswers(INPUT);
        
        answerTwo.Should().Be(EXPECTED_DAY_TWO_ANSWER);
    }
}
"@
    return $unitTestContent
}

if (!(Test-Path -Path .\Inputs\$($year)\day$($day.ToString("00"))input.txt)) {
   New-Item .\Inputs\$($year)\day$($day.ToString("00"))input.txt
}
if (!(Test-Path -Path .\Inputs\$($year)\day$($day.ToString("00"))testinput.txt)) {
   New-Item .\Inputs\$($year)\day$($day.ToString("00"))testinput.txt
}

cd .\$($year)
if (!(Test-Path -Path "aoc-$($year).sln" -PathType Leaf)) {
    dotnet new sln --name "aoc-$($year)"
	dotnet sln add .\..\AoC.Console\
}

$projectName = "aoc.$($year).day$($day.ToString("00"))"

if (Test-Path -Path .\$($projectName) -PathType Container) {
    Write-Host("$($projectName) folder already exists. You might want to try creating a different day, or maybe you have the wrong year.")
    Return;
}

dotnet new aoc-dayx -n $($projectName) -o $($projectName)
dotnet new xunit -n "$($projectName).tests" -o "$($projectName).tests"

dotnet sln add $($projectName)
dotnet sln add "$($projectName).tests"

dotnet add .\..\AoC.Console\AoC.Console.csproj reference .\$($projectName)\$($projectName).csproj
dotnet add .\$($projectName).Tests\$($projectName).tests.csproj reference .\$($projectName)\$($projectName).csproj
dotnet add .\$($projectName).Tests\$($projectName).tests.csproj package FluentAssertions

New-Item .\$($projectName).Tests\Day$($day.ToString("00"))SolverTests.cs
$testContent = Get-UnitTestContent
Set-Content .\$($projectName).Tests\Day$($day.ToString("00"))SolverTests.cs $testContent
Remove-Item .\$($projectName).Tests\UnitTest1.cs

$serviceCollectionContent = (Get-Content .\$($projectName)\ServiceCollection.cs)
$newServiceCollectionContent = $serviceCollectionContent -replace "DayX","Day$($day.ToString("00"))"
Set-Content .\$($projectName)\ServiceCollection.cs $newServiceCollectionContent

Write-Host("Now do the following:");
Write-Host("1)	Update .\$($projectName) project:")
Write-Host("	a) DayX.cs - give it a new filename");
Write-Host("2)	Update .\..\AoC.Console project:");
Write-Host("	a) ServiceCollection.cs - add new project services and update service resolver");
Write-Host("")

cd ..