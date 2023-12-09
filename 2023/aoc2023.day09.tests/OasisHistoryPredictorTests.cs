using FluentAssertions;

namespace aoc2023.day09.tests
{
    public class OasisHistoryPredictorTests
    {
        [Fact]
        public void OasisHistoryWithNoLevelsOfDifferenceCanBePredicted()
        {
            var history = new List<int>() { 1, 1, 1, 1, 1 };

            var oasisHistoryPredictor = new OasisHistoryPredictor(history);

            var nextValue = oasisHistoryPredictor.GetNextValue();

            nextValue.Should().Be(1);
        }

        [Fact]
        public void OasisHistoryWithOneLevelOfDifferenceOfASingleUnitCanBePredicted()
        {
            var history = new List<int>() { 1, 2, 3, 4, 5 };

            var oasisHistoryPredictor = new OasisHistoryPredictor(history);

            var nextValue = oasisHistoryPredictor.GetNextValue();

            nextValue.Should().Be(6);
        }

        [Fact]
        public void OasisHistoryWithOneLevelOfDifferenceOfMultipleUnitsCanBePredicted()
        {
            var history = new List<int>() { 8, 5, 2, -1, -4 };

            var oasisHistoryPredictor = new OasisHistoryPredictor(history);

            var nextValue = oasisHistoryPredictor.GetNextValue();

            nextValue.Should().Be(-7);
        }

        [Fact]
        public void OasisHistoryWithTwoLevelsOfDifferenceCanBePredicted()
        {
            var history = new List<int>() { 1, 3, 6, 10, 15, 21 };

            var oasisHistoryPredictor = new OasisHistoryPredictor(history);

            var nextValue = oasisHistoryPredictor.GetNextValue();

            nextValue.Should().Be(28);
        }

        [Fact]
        public void OasisHistoryWithThreeLevelsOfDifferenceCanBePredicted()
        {
            var history = new List<int>() { 10, 13, 16, 21, 30, 45 };

            var oasisHistoryPredictor = new OasisHistoryPredictor(history);

            var nextValue = oasisHistoryPredictor.GetNextValue();

            nextValue.Should().Be(68);
        }
    }
}
