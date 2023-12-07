using FluentAssertions;

namespace aoc2023.day07.tests
{
    public class CamelCardsGameTests
    {
        [Fact]
        public void TotalWinningsForAllSetsOfHandsAreAsExpected()
        {
            var standardRules = new StandardScoringRules();
            var game = new CamelCardsGame(standardRules);
            
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

        [Fact]
        public void TotalWinningsForHandsWithJokersAsExpected()
        {
            var rules = new JokerScoringRules();
            var game = new CamelCardsGame(rules);

            game.AddHand("JKKK2", 20);
            game.AddHand("QQQQ2", 50);
            // JKKK2 is rank 1, QQQQ2 is rank 2
            var totalWinnings = game.CalculateTotalWinnings();
            totalWinnings.Should().Be(120);
            // as opposed to 90 with opposite ranks
        }

        [Fact]
        public void TotalWinningsWithJokerRulesForAllSetsOfHandsAreAsExpected()
        {
            var jokerRules = new JokerScoringRules();
            var game = new CamelCardsGame(jokerRules);

            game.AddHand("32T3K", 765);
            // 32T3K is rank 1
            var totalWinnings = game.CalculateTotalWinnings();
            totalWinnings.Should().Be(765);

            game.AddHand("T55J5", 684);
            // 32T3K is rank 1, T55J5 (T5555) is rank 2
            totalWinnings = game.CalculateTotalWinnings();
            totalWinnings.Should().Be(2133);

            game.AddHand("KK677", 28);
            // 32T3K is rank 1, KK677 is rank 2, T55J5 (T5555) is rank 3
            totalWinnings = game.CalculateTotalWinnings();
            totalWinnings.Should().Be(2873);

            game.AddHand("KTJJT", 220);
            game.AddHand("QQQJA", 483);
            game.AddHand("JJJJJ", 0);
            // 32T3K is rank 1, KK677 is rank 2, T55J5 (T5555) is rank 3, QQQJA (QQQQA) is rank 4, KTJJT (KTTTT) is rank 5
            totalWinnings = game.CalculateTotalWinnings();
            totalWinnings.Should().Be(5905);
        }
    }
}
