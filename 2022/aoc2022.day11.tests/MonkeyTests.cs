using aoc2022.day11.domain;
using FluentAssertions;

namespace aoc2022.day11.tests
{
    public class MonkeyTests
    {
        private readonly string _simpleDoubleOperation = "old * 2";
        private readonly Func<long, decimal> _simpleDivideBy3Operation = (long worryLevel) => { return (decimal)worryLevel / 3; };

        [Fact]
        public void MonkeyCanAlterItemWorryLevelWhenInspecting()
        {
            var firstItem = new Item(23);
            var monkey = new Monkey(_simpleDoubleOperation, 0, 0, 0);
            
            monkey.AddItem(firstItem);
            var item = monkey.InspectItem(_simpleDivideBy3Operation);

            item.GetWorryLevel().Should().Be(15);
        }

        [Fact] 
        public void MonkeyCanGetWhoToNextPassItemTo()
        {
            var monkey = new Monkey(_simpleDoubleOperation, 7, 8, 12);

            var nextMonkeyId = monkey.GetNextMonkey(14);
            nextMonkeyId.Should().Be(8);

            nextMonkeyId = monkey.GetNextMonkey(8);
            nextMonkeyId.Should().Be(12);
        }
    }
}
