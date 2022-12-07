using FluentAssertions;
using System.ComponentModel.Design;

namespace aoc2022.day07.tests;

public class Day07SolverTests
{
    private readonly string[] INPUT = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"..\\..\\..\\..\\..\\Inputs\\2022\\day07testinput.txt"));
    private const string EXPECTED_ANSWER_ONE = "95437"; // <--------- solution from web page test example goes here
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
        var day07 = new Day07Solver(parser);

        var (answerOne, _) = day07.CalculateAnswers(INPUT);

        answerOne.Should().Be(EXPECTED_ANSWER_ONE);
    }

    [Fact]
    public void CalculatedAnswerTwoMatchesTestCase()
    {
        var parser = new Parser();
        var day07 = new Day07Solver(parser);

        var (_, answerTwo) = day07.CalculateAnswers(INPUT);
        
        answerTwo.Should().Be(EXPECTED_ANSWER_TWO);
    }

    [Fact] public void CanCreateNewDirectoryAndFilesInTree()
    {
        var command = new string[] { "$ ls", "dir a", "14848514 b.txt", "8504156 c.dat", "dir d", "1234 aa" };

        var parser = new Parser();
        
        var input = parser.ParseInput(command);

        var tree = input.Tree;

        tree.ContainsKey(("a", @".\")).Should().BeTrue();
        tree[("a", @".\")].ItemType.Should().Be(domain.Enums.TreeItemType.Directory);
        tree[("a", @".\")].Size.Should().Be(0);

        tree.ContainsKey(("b.txt", @".\")).Should().BeTrue();
        tree[("b.txt", @".\")].ItemType.Should().Be(domain.Enums.TreeItemType.File);
        tree[("b.txt", @".\")].Size.Should().Be(14848514);

        tree.ContainsKey(("c.dat", @".\")).Should().BeTrue();
        tree[("c.dat", @".\")].ItemType.Should().Be(domain.Enums.TreeItemType.File);
        tree[("c.dat", @".\")].Size.Should().Be(8504156);

        tree.ContainsKey(("d", @".\")).Should().BeTrue();
        tree[("d", @".\")].ItemType.Should().Be(domain.Enums.TreeItemType.Directory);
        tree[("d", @".\")].Size.Should().Be(0);

        tree.ContainsKey(("aa", @".\")).Should().BeTrue();
        tree[("aa", @".\")].ItemType.Should().Be(domain.Enums.TreeItemType.File);
        tree[("aa", @".\")].Size.Should().Be(1234);
    }

    [Fact]
    public void CanCreateNewSubDirectoryAndFilesInTree()
    {
        var command = new string[] { "$ ls", "dir a", "14848514 b.txt", "8504156 c.dat", "dir d", "$ cd a", "$ ls", "dir e", "29116 f", "2557 g", "62596 h.lst" };

        var parser = new Parser();

        var input = parser.ParseInput(command);

        var tree = input.Tree;
        tree.ContainsKey(("a", @".\")).Should().BeTrue();
        tree.ContainsKey(("b.txt", @".\")).Should().BeTrue();
        tree.ContainsKey(("c.dat", @".\")).Should().BeTrue();
        tree.ContainsKey(("d", @".\")).Should().BeTrue();
        tree.ContainsKey(("e", @".\a\")).Should().BeTrue();
        tree.ContainsKey(("f", @".\a\")).Should().BeTrue();
        tree.ContainsKey(("g", @".\a\")).Should().BeTrue();
        tree.ContainsKey(("h.lst", @".\a\")).Should().BeTrue();
    }

    [Fact]
    public void CanMoveUpDirectories()
    {
        var command = new string[] { "$ ls", "dir a", "dir b", "$ cd b", "$ ls", "dir c", "dir d", "$ cd c", "$ ls", "dir e", "$ cd ..", "dir f" };

        var parser = new Parser();

        var input = parser.ParseInput(command);

        var tree = input.Tree;
        tree.ContainsKey(("a", @".\")).Should().BeTrue();
        tree.ContainsKey(("b", @".\")).Should().BeTrue();
        tree.ContainsKey(("c", @".\b\")).Should().BeTrue();
        tree.ContainsKey(("d", @".\b\")).Should().BeTrue();
        tree.ContainsKey(("e", @".\b\c\")).Should().BeTrue();
        tree.ContainsKey(("f", @".\b\")).Should().BeTrue();
    }
}
