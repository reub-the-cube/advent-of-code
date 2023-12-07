using FluentAssertions;

namespace aoc2023.day07.tests
{
    public class CamelCardsGameTests
    {
        [Fact]
        public void TotalWinningsForAllSetsOfHandsAreAsExpected()
        {
            var game = new CamelCardsGame();
            
            game.AddHand("32T3K", 765);
            // 32T3K is rank 1
            var totalWinnings = game.CalculateTotalWinnings();
            totalWinnings.Should().Be(765);

            game.AddHand("T55J5", 684);
            // 32T3K is rank 1, T55J5 is rank 2
            totalWinnings = game.CalculateTotalWinnings();
            totalWinnings.Should().Be(2133);

            game.AddHand("KK677", 28);
            // 32T3K is rank 1, KK677 is rank 2, T55J5 is rank 3
            totalWinnings = game.CalculateTotalWinnings();
            totalWinnings.Should().Be(2873);

            game.AddHand("KTJJT", 220);
            game.AddHand("QQQJA", 483);
            // 32T3K is rank 1, KTJJT is rank 2, KK677 is rank 3, T55J5 is rank 4, QQQJA is rank 5
            totalWinnings = game.CalculateTotalWinnings();
            totalWinnings.Should().Be(6440);
        }
    }
}
