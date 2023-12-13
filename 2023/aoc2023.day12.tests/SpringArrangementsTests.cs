using FluentAssertions;

namespace aoc2023.day12.tests
{
    public class SpringArrangementsTests
    {
        [Fact]
        public void SpringConditionsWithASingleUnknownHasOneArrangement()
        {
            var springConditions = "?.#.###";
            List<int> contiguousGroups = [1, 1, 3];

            var springArrangements = new SpringArrangements();
            var validArrangements = springArrangements.GetPossibleArrangements(springConditions, contiguousGroups);

            validArrangements.Should().Be(1);
        }

        [Fact]
        public void SpringConditionsWithATwoUnknownsHasOneArrangement()
        {
            var springConditions = "#??.###";
            List<int> contiguousGroups = [1, 1, 3];

            var springArrangements = new SpringArrangements();
            var validArrangements = springArrangements.GetPossibleArrangements(springConditions, contiguousGroups);

            validArrangements.Should().Be(1);
        }

        [Fact]
        public void SpringConditionsWithATwoUnknownsHasTwoArrangements()
        {
            var springConditions = "#.??.###";
            List<int> contiguousGroups = [1, 1, 3];

            var springArrangements = new SpringArrangements();
            var validArrangements = springArrangements.GetPossibleArrangements(springConditions, contiguousGroups);

            validArrangements.Should().Be(2);
        }

        [Fact]
        public void SpringConditionsWithAMultipleUnknownGroupsHasFourArrangements()
        {
            var springConditions = ".??..??...?##.";
            List<int> contiguousGroups = [1, 1, 3];

            var springArrangements = new SpringArrangements();
            var validArrangements = springArrangements.GetPossibleArrangements(springConditions, contiguousGroups);

            validArrangements.Should().Be(4);
        }

        [Fact]
        public void SpringConditionsWithALongerUnknownGroupHasFourArrangements()
        {
            var springConditions = "????.######..#####.";
            List<int> contiguousGroups = [1, 6, 5];

            var springArrangements = new SpringArrangements();
            var validArrangements = springArrangements.GetPossibleArrangements(springConditions, contiguousGroups);

            validArrangements.Should().Be(4);
        }

        [Fact]
        public void SpringConditionsWithAUnknownGroupBookendingAnOperationalGroupHasTenArrangements()
        {
            var springConditions = "?###????????";
            List<int> contiguousGroups = [3, 2, 1];

            var springArrangements = new SpringArrangements();
            var validArrangements = springArrangements.GetPossibleArrangements(springConditions, contiguousGroups);

            validArrangements.Should().Be(10);
        }

        [Fact]
        public void SpringArrangementCanBeUnfolded()
        {
            var springConditions = ".#";
            List<int> contiguousGroups = [1];

            var unfoldedRecord = SpringArrangements.Unfold(springConditions, contiguousGroups);

            unfoldedRecord.SpringConditions.Should().Be(".#?.#?.#?.#?.#");
            unfoldedRecord.ContiguousCount.Should().HaveCount(5);
            unfoldedRecord.ContiguousCount.All(c => c == 1).Should().BeTrue();
        }

        [Fact]
        public void SpringArrangementCanBeUnfoldedWithUnknowns()
        {
            var springConditions = "???.###";
            List<int> contiguousGroups = [1, 1, 3];

            var unfoldedRecord = SpringArrangements.Unfold(springConditions, contiguousGroups);

            unfoldedRecord.SpringConditions.Should().Be("???.###????.###????.###????.###????.###");
            unfoldedRecord.ContiguousCount.Should().HaveCount(15);
        }
    }
}
