using FluentAssertions;

namespace aoc2020.day04.tests;

public class Day04SolverTests
{
    private readonly string[] INPUT = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "Inputs", "2020", "day04testinput.txt"));
    private const string EXPECTED_ANSWER_ONE = "2"; // <--------- solution from web page test example goes here
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
        var day04 = new Day04Solver(parser);

        var (answerOne, _) = day04.CalculateAnswers(INPUT);

        answerOne.Should().Be(EXPECTED_ANSWER_ONE);
    }

    [Fact]
    public void CalculatedAnswerTwoMatchesTestCaseForInvalidPassports()
    {
        var parser = new Parser();
        var day04 = new Day04Solver(parser);

        string[] input = @"
eyr:1972 cid:100
hcl:#18171d ecl:amb hgt:170 pid:186cm iyr:2018 byr:1926

iyr:2019
hcl:#602927 eyr:1967 hgt:170cm
ecl:grn pid:012533040 byr:1946

hcl:dab227 iyr:2012
ecl:brn hgt:182cm pid:021572410 eyr:2020 byr:1992 cid:277

hgt:59cm ecl:zzz
eyr:2038 hcl:74454a iyr:2023
pid:3556412378 byr:2007".Split("\r\n");

        var (_, answerTwo) = day04.CalculateAnswers(input);
        
        answerTwo.Should().Be("0");
    }

    [Fact]
    public void CalculatedAnswerTwoMatchesTestCaseForValidPassports()
    {
        var parser = new Parser();
        var day04 = new Day04Solver(parser);

        string[] input = @"pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980
hcl:#623a2f

eyr:2029 ecl:blu cid:129 byr:1989
iyr:2014 pid:896056539 hcl:#a97842 hgt:165cm

hcl:#888785
hgt:164cm byr:2001 iyr:2015 cid:88
pid:545766238 ecl:hzl
eyr:2022

iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719".Split("\r\n");

        var (_, answerTwo) = day04.CalculateAnswers(input);
        
        answerTwo.Should().Be("4");
    }

    [Theory]
    [InlineData(2002, true)]
    [InlineData(2003, false)]
    public void CalculateAnswerTwoTestCasesForBirthYear(int birthYear, bool expectedIsValid)
    {
        var parser = new Parser();
        var day04 = new Day04Solver(parser);

        string[] input = $"pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:{birthYear} hcl:#623a2f".Split("\r\n");

        var (_, answerTwo) = day04.CalculateAnswers(input);
        
        var expectedNumberOfValidPassports = expectedIsValid ? 1 : 0;
        answerTwo.Should().Be($"{expectedNumberOfValidPassports}");
    }

    [Theory]
    [InlineData("60in", true)]
    [InlineData("190cm", true)]
    [InlineData("190in", false)]
    [InlineData("190", false)]
    public void CalculateAnswerTwoTestCasesForHeight(string height, bool expectedIsValid)
    {
        var parser = new Parser();
        var day04 = new Day04Solver(parser);

        string[] input = $"pid:087499704 hgt:{height} ecl:grn iyr:2012 eyr:2030 byr:1980 hcl:#623a2f".Split("\r\n");

        var (_, answerTwo) = day04.CalculateAnswers(input);
        
        var expectedNumberOfValidPassports = expectedIsValid ? 1 : 0;
        answerTwo.Should().Be($"{expectedNumberOfValidPassports}");
    }

// hcl valid:   #123abc
// hcl invalid: #123abz
// hcl invalid: 123abc

// ecl valid:   brn
// ecl invalid: wat

// pid valid:   000000001
// pid invalid: 0123456789
}
