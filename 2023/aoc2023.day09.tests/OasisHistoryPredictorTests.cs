using FluentAssertions;

namespace aoc2023.day09.tests
{
    public class OasisHistoryPredictorTests
    {
        [Fact]
        public void OasisHistoryWithNoLevelsOfDifferenceCanPredictNextValue()
        {
            var history = new List<int>() { 1, 1, 1, 1, 1 };

            var oasisHistoryPredictor = new OasisHistoryPredictor(history);

            var nextValue = oasisHistoryPredictor.GetNextValue();

            nextValue.Should().Be(1);
        }

        [Fact]
        public void OasisHistoryWithOneLevelOfDifferenceOfASingleUnitCanPredictNextValue()
        {
            var history = new List<int>() { 1, 2, 3, 4, 5 };

            var oasisHistoryPredictor = new OasisHistoryPredictor(history);

            var nextValue = oasisHistoryPredictor.GetNextValue();

            nextValue.Should().Be(6);
        }

        [Fact]
        public void OasisHistoryWithOneLevelOfDifferenceOfMultipleUnitsCanPredictNextValue()
        {
            var history = new List<int>() { 8, 5, 2, -1, -4 };

            var oasisHistoryPredictor = new OasisHistoryPredictor(history);

            var nextValue = oasisHistoryPredictor.GetNextValue();

            nextValue.Should().Be(-7);
        }

        [Fact]
        public void OasisHistoryWithTwoLevelsOfDifferenceCanPredictNextValue()
        {
            var history = new List<int>() { 1, 3, 6, 10, 15, 21 };

            var oasisHistoryPredictor = new OasisHistoryPredictor(history);

            var nextValue = oasisHistoryPredictor.GetNextValue();

            nextValue.Should().Be(28);
        }

        [Fact]
        public void OasisHistoryWithThreeLevelsOfDifferenceCanPredictNextValue()
        {
            var history = new List<int>() { 10, 13, 16, 21, 30, 45 };

            var oasisHistoryPredictor = new OasisHistoryPredictor(history);

            var nextValue = oasisHistoryPredictor.GetNextValue();

            nextValue.Should().Be(68);
        }

        [Fact]
        public void OasisHistoryWithNoLevelsOfDifferenceCanPredictPreviousValue()
        {
            var history = new List<int>() { 1, 1, 1, 1, 1 };

            var oasisHistoryPredictor = new OasisHistoryPredictor(history);

            var nextValue = oasisHistoryPredictor.GetPreviousValue();

            nextValue.Should().Be(1);
        }

        [Fact]
        public void OasisHistoryWithOneLevelOfDifferenceCanPredictPreviousValue()
        {
            var history = new List<int>() { 1, 3, 6, 10, 15, 21 };

            var oasisHistoryPredictor = new OasisHistoryPredictor(history);

            var nextValue = oasisHistoryPredictor.GetPreviousValue();

            nextValue.Should().Be(0);
        }

        [Fact]
        public void OasisHistoryWithThreeLevelsOfDifferenceCanPredictPreviousValue()
        {
            var history = new List<int>() { 10, 13, 16, 21, 30, 45 };

            var oasisHistoryPredictor = new OasisHistoryPredictor(history);

            var nextValue = oasisHistoryPredictor.GetPreviousValue();

            nextValue.Should().Be(5);
        }
    }
}
