using System.Net;

namespace aoc2023.day09
{
    public class OasisHistoryPredictor
    {
        private readonly List<int> _history = new();
        private readonly Dictionary<int, List<int>> _listOfDifferences = new();

        public OasisHistoryPredictor(List<int> history)
        {
            _history = history;
        }

        public int GetNextValue()
        {
            GetListOfAllDifferencesFromInitialHistory();
            var nextValue = PredictNextValue();

            return nextValue;
        }

        public int GetPreviousValue()
        {
            GetListOfAllDifferencesFromInitialHistory();
            var previousValue = PredictPreviousValue();

            return previousValue;
        }

        private void GetListOfAllDifferencesFromInitialHistory()
        {
            var listOfDifferences = _history;
            var numberOfLevels = 1;

            while (!listOfDifferences.All(d => d == 0))
            {
                _listOfDifferences.Add(numberOfLevels, listOfDifferences);
                listOfDifferences = GetListOfDifferences(listOfDifferences);
                numberOfLevels++;
            }
        }

        private List<int> GetListOfDifferences(List<int> values)
        {
            var listOfDifferences = new List<int>();
            for (int i = 1; i < values.Count; i++)
            {
                listOfDifferences.Add(values[i] - values[i - 1]);
            }

            return listOfDifferences;
        }

        private int PredictNextValue()
        {
            return PredictEdgeValues().Next;
        }

        private int PredictPreviousValue()
        {
            return PredictEdgeValues().Previous;
        }

        private (int Previous, int Next) PredictEdgeValues()
        {
            var listOfPredictedValues = new Dictionary<int, (int Previous, int Next)>
            {
                { 0, (0, 0) } // Row of differences of 0 will have 0 as the next and previous value
            };

            var levels = _listOfDifferences.Max(d => d.Key);

            for (int i = 1; i <= levels; i++)
            {
                int previousValue = CalculateSequenceValue(_listOfDifferences[levels - i + 1].First(), listOfPredictedValues[i - 1].Previous, false);
                int nextValue = CalculateSequenceValue(_listOfDifferences[levels - i + 1].Last(), listOfPredictedValues[i - 1].Next, true);

                listOfPredictedValues.Add(i, (previousValue, nextValue));
            }

            return listOfPredictedValues[levels];
        }

        private int CalculateSequenceValue(int previousStartingValue, int step, bool stepForwards)
        {
            return stepForwards ? previousStartingValue + step : previousStartingValue - step;
        }
    }
}
