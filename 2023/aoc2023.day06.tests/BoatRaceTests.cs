using FluentAssertions;

namespace aoc2023.day06.tests
{
    public class BoatRaceTests
    {
        [Theory]
        [InlineData(7, 9, 4)]
        [InlineData(15, 40, 8)]
        [InlineData(30, 200, 9)]
        public void RaceReturnsDifferentOutcomes(int raceDuration, int distanceToBeat, int numberOfWinningOutcomes)
        {
            var race = new BoatRace(raceDuration);

            var numberOfWaysToWin = race.GetNumberOfScenariosToBeatADistance(distanceToBeat);

            numberOfWaysToWin.Should().Be(numberOfWinningOutcomes);
        }
    }
}
