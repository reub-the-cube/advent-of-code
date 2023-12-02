using aoc2023.day02.domain;
using FluentAssertions;

namespace aoc2023.day02.tests
{
    public class GameTests
    {
        private readonly int MaximumNumberOfRedCubes = 12;
        private readonly int MaximumNumberOfGreenCubes = 13;
        private readonly int MaximumNumberOfBlueCubes = 14;

        [Fact] 
        public void GameIsPossible()
        {
            var bag = new Bag(MaximumNumberOfRedCubes, MaximumNumberOfGreenCubes, MaximumNumberOfBlueCubes);
            var game = new Game(bag, 0);
            game.TakeHandfulFromBag(new Handful(4, 0, 3));
            game.TakeHandfulFromBag(new Handful(1, 2, 6));
            game.TakeHandfulFromBag(new Handful(0, 2, 0));

            var gameIsPossible = game.IsPossible();

            gameIsPossible.Should().BeTrue();
        }

        [Fact] public void GameIsNotPossible()
        {
            var bag = new Bag(MaximumNumberOfRedCubes, MaximumNumberOfGreenCubes, MaximumNumberOfBlueCubes);
            var game = new Game(bag, 0);
            game.TakeHandfulFromBag(new Handful(20, 8, 6));
            game.TakeHandfulFromBag(new Handful(4, 13, 5));
            game.TakeHandfulFromBag(new Handful(1, 5, 0));

            var gameIsPossible = game.IsPossible();

            gameIsPossible.Should().BeFalse();
        }

        [Fact]
        public void GamePowerIsCalculatedCorrectly()
        {
            var bag = new Bag(MaximumNumberOfRedCubes, MaximumNumberOfGreenCubes, MaximumNumberOfBlueCubes);
            var game = new Game(bag, 0);
            game.TakeHandfulFromBag(new Handful(4, 0, 3));
            game.TakeHandfulFromBag(new Handful(1, 2, 6));
            game.TakeHandfulFromBag(new Handful(0, 2, 0));

            var power = game.PowerOfMinimumCubes();

            power.Should().Be(48);
        }
    }
}
