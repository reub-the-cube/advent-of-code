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

            var springArrangements = SpringArrangements.GetPossibleArrangements(springConditions, contiguousGroups);

            springArrangements.Should().HaveCount(1);
            springArrangements.Should().Contain("#.#.###");
        }

        [Fact]
        public void SpringConditionsWithATwoUnknownsHasOneArrangement()
        {
            var springConditions = "#??.###";
            List<int> contiguousGroups = [1, 1, 3];

            var springArrangements = SpringArrangements.GetPossibleArrangements(springConditions, contiguousGroups);

            springArrangements.Should().HaveCount(1);
            springArrangements.Should().Contain("#.#.###");
        }

        [Fact]
        public void SpringConditionsWithATwoUnknownsHasTwoArrangements()
        {
            var springConditions = "#.??.###";
            List<int> contiguousGroups = [1, 1, 3];

            var springArrangements = SpringArrangements.GetPossibleArrangements(springConditions, contiguousGroups);

            springArrangements.Should().HaveCount(2);
            springArrangements.Should().Contain("#..#.###");
            springArrangements.Should().Contain("#.#..###");
        }

        [Fact]
        public void SpringConditionsWithAMultipleUnknownGroupsHasFourArrangements()
        {
            var springConditions = ".??..??...?##.";
            List<int> contiguousGroups = [1, 1, 3];

            var springArrangements = SpringArrangements.GetPossibleArrangements(springConditions, contiguousGroups);

            springArrangements.Should().HaveCount(4);
        }

        [Fact]
        public void SpringConditionsWithALongerUnknownGroupHasFourArrangements()
        {
            var springConditions = "????.######..#####.";
            List<int> contiguousGroups = [1, 6, 5];

            var springArrangements = SpringArrangements.GetPossibleArrangements(springConditions, contiguousGroups);

            springArrangements.Should().HaveCount(4);
        }

        [Fact]
        public void SpringConditionsWithAUnknownGroupBookendingAnOperationalGroupHasTenArrangements()
        {
            var springConditions = "?###????????";
            List<int> contiguousGroups = [3, 2, 1];

            var springArrangements = SpringArrangements.GetPossibleArrangements(springConditions, contiguousGroups);

            springArrangements.Should().HaveCount(10);
        }
    }
}
