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
            var listOfDifferences = _history;
            var numberOfLevels = 1;

            while (!listOfDifferences.All(d => d == 0))
            {
                _listOfDifferences.Add(numberOfLevels, listOfDifferences);
                listOfDifferences = GetListOfDifferences(listOfDifferences);
                numberOfLevels++;
            }

            var nextValue = PredictNextValue();

            return nextValue;
        }

        public int GetPreviousValue()
        {
            var listOfDifferences = _history;
            var numberOfLevels = 1;

            while (!listOfDifferences.All(d => d == 0))
            {
                _listOfDifferences.Add(numberOfLevels, listOfDifferences);
                listOfDifferences = GetListOfDifferences(listOfDifferences);
                numberOfLevels++;
            }

            var previousValue = PredictPreviousValue();

            return previousValue;
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
            var listOfPredictedValues = new Dictionary<int, int>
            {
                { 0, 0 } // Row of differences of 0 will have 0 as the next value
            };

            var levels = _listOfDifferences.Max(d => d.Key);

            for (int i = 1; i <= levels; i++)
            {
                int previousValue = _listOfDifferences[levels - i + 1].Last();
                int differenceFromPrevious = listOfPredictedValues[i - 1];

                listOfPredictedValues.Add(i, previousValue + differenceFromPrevious);
            }

            return listOfPredictedValues[levels];
        }

        private int PredictPreviousValue()
        {
            var listOfPredictedValues = new Dictionary<int, int>
            {
                { 0, 0 } // Row of differences of 0 will have 0 as the next value
            };

            var levels = _listOfDifferences.Max(d => d.Key);

            for (int i = 1; i <= levels; i++)
            {
                int previousValue = _listOfDifferences[levels - i + 1].First();
                int differenceFromPrevious = listOfPredictedValues[i - 1];

                listOfPredictedValues.Add(i, previousValue - differenceFromPrevious);
            }

            return listOfPredictedValues[levels];
        }
    }
}
