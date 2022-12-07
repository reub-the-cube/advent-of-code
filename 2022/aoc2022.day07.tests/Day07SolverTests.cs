using aoc2022.day07.domain;
using FluentAssertions;

namespace aoc2022.day07.tests;

public class Day07SolverTests
{
    private readonly string[] INPUT = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "Inputs", "2022", "day07testinput.txt"));
    private const string EXPECTED_ANSWER_ONE = "95437"; // <--------- solution from web page test example goes here
    private const string EXPECTED_ANSWER_TWO = "24933642"; // <--------- solution from web page test example goes here

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
        var command = new [] { "$ cd /", "$ ls", "dir a", "14848514 b.txt", "8504156 c.dat", "dir d", "1234 aa" };

        var parser = new Parser();
        
        var input = parser.ParseInput(command);

        var tree = input.Tree;

        tree.ContainsKey(("a", "/")).Should().BeTrue();
        tree[("a", "/")].ItemType.Should().Be(domain.Enums.TreeItemType.Directory);
        tree[("a", "/")].Size.Should().Be(0);

        tree.ContainsKey(("b.txt", "/")).Should().BeTrue();
        tree[("b.txt", "/")].ItemType.Should().Be(domain.Enums.TreeItemType.File);
        tree[("b.txt", "/")].Size.Should().Be(14848514);

        tree.ContainsKey(("c.dat", "/")).Should().BeTrue();
        tree[("c.dat", "/")].ItemType.Should().Be(domain.Enums.TreeItemType.File);
        tree[("c.dat", "/")].Size.Should().Be(8504156);

        tree.ContainsKey(("d", "/")).Should().BeTrue();
        tree[("d", "/")].ItemType.Should().Be(domain.Enums.TreeItemType.Directory);
        tree[("d", "/")].Size.Should().Be(0);

        tree.ContainsKey(("aa", "/")).Should().BeTrue();
        tree[("aa", "/")].ItemType.Should().Be(domain.Enums.TreeItemType.File);
        tree[("aa", "/")].Size.Should().Be(1234);
    }

    [Fact]
    public void CanCreateNewSubDirectoryAndFilesInTree()
    {
        var command = new [] { "$ cd /", "$ ls", "dir a", "14848514 b.txt", "8504156 c.dat", "dir d", "$ cd a", "$ ls", "dir e", "29116 f", "2557 g", "62596 h.lst" };

        var parser = new Parser();

        var input = parser.ParseInput(command);

        var tree = input.Tree;
        tree.ContainsKey(("a", "/")).Should().BeTrue();
        tree.ContainsKey(("b.txt", "/")).Should().BeTrue();
        tree.ContainsKey(("c.dat", "/")).Should().BeTrue();
        tree.ContainsKey(("d", "/")).Should().BeTrue();
        tree.ContainsKey(("e", "/a/")).Should().BeTrue();
        tree.ContainsKey(("f", "/a/")).Should().BeTrue();
        tree.ContainsKey(("g", "/a/")).Should().BeTrue();
        tree.ContainsKey(("h.lst", "/a/")).Should().BeTrue();
    }

    [Fact]
    public void GetDirectorySizeBasedOnFilesIncludingChildren()
    {
        var tree = new Dictionary<(string Name, string ParentPath), TreeItem>()
        {
            {("/", string.Empty), new TreeDirectoryItem()},
            {("a", "/"), new TreeFileItem(10)},
            {("b", "/"), new TreeDirectoryItem()},
            {("c", "/b"), new TreeDirectoryItem()},
            {("d", "/b"), new TreeFileItem(20)},
            {("e", "/b"), new TreeFileItem(30)},
            {("f", "/b"), new TreeDirectoryItem()},
            {("g", "/b/f"), new TreeFileItem(40)}
        };

        var input = new Input(tree);

        input.GetTotalSizeOfDirectoryFiles("/", string.Empty).Should().Be(100);
        input.GetTotalSizeOfDirectoryFiles("b", "/").Should().Be(90);
        input.GetTotalSizeOfDirectoryFiles("c", "/").Should().Be(0);
        input.GetTotalSizeOfDirectoryFiles("f", "/b").Should().Be(40);
    }
    
    [Fact]
    public void GetDirectoriesBySize()
    {
        var tree = new Dictionary<(string Name, string ParentPath), TreeItem>()
        {
            {("/", string.Empty), new TreeDirectoryItem()},
            {("a", "/"), new TreeFileItem(10)},
            {("b", "/"), new TreeDirectoryItem()},
            {("c", "/b"), new TreeDirectoryItem()},
            {("d", "/b"), new TreeFileItem(20)},
            {("e", "/b"), new TreeFileItem(30)},
            {("f", "/b"), new TreeDirectoryItem()},
            {("g", "/b/f"), new TreeFileItem(40)}
        };

        var input = new Input(tree);

        var directories = input.GetDirectoriesBySize();
        directories.Should().HaveCount(4);
        
        directories.ContainsKey("/").Should().BeTrue();
        directories["/"].Should().Be(100);
        
        directories.ContainsKey("/b").Should().BeTrue();
        directories["/b"].Should().Be(90);
        
        directories.ContainsKey("/b/c").Should().BeTrue();
        directories["/b/c"].Should().Be(0);
        
        directories.ContainsKey("/b/f").Should().BeTrue();
        directories["/b/f"].Should().Be(40);
    }
}
