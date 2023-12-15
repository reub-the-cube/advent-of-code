using aoc2023.day15.domain;

namespace aoc2023.day15
{
    public class StepHandler
    {
        private readonly Dictionary<int, Dictionary<string, Lens>> _boxes = new();
        private readonly Dictionary<string, int> _labelToStepLink = new();
        private int _stepCounter = 1;

        public StepHandler()
        {
            for (int i = 0; i < 256; i++)
            {
                _boxes.Add(i, new Dictionary<string, Lens>());
            }
        }

        public int AddLens(Lens lens)
        {
            var boxId = Hasher.HashString(lens.Label);

            var isNewLabel = LinkLabelToStep(lens.Label);
            if (isNewLabel)
            {
                _boxes[boxId].Add(lens.Label, lens);
            }
            else
            {
                _boxes[boxId][lens.Label] = lens;
            }

            return boxId;
        }

        public int RemoveLens(Lens lens)
        {
            var boxId = Hasher.HashString(lens.Label);

            if (_labelToStepLink.ContainsKey(lens.Label))
            {
                _boxes[boxId].Remove(lens.Label);
                _labelToStepLink.Remove(lens.Label);
            }

            return boxId;
        }

        public List<Lens> GetLenses(int boxId) 
        {
            return _boxes[boxId].Values.OrderBy(k => _labelToStepLink[k.Label]).ToList();
        }

        public int ProcessStep(string input)
        {
            var step = StepParser.Parse(input);
            return ProcessStep(step);
        }

        private int ProcessStep(Step step)
        {
            if (step.Operator == Enums.StepOperator.Add)
            {
                return AddLens(step.Lens);
            }

            if (step.Operator == Enums.StepOperator.Remove)
            {
                return RemoveLens(step.Lens);
            }

            return -1;
        }

        private bool LinkLabelToStep(string label)
        {
            var isNewLabel = false;

            if (!_labelToStepLink.ContainsKey(label))
            {
                _labelToStepLink.Add(label, _stepCounter);
                isNewLabel = true;
            }

            _stepCounter++;
            return isNewLabel;
        }
    }

    public static class StepParser
    {
        public static Step Parse(string input)
        {
            if (input.EndsWith('-'))
            {
                return ParseRemoveStep(input);
            }

            if (input.Contains('='))
            {
                return ParseAddStep(input);
            }

            throw new NotImplementedException();
        }

        private static Step ParseRemoveStep(string input)
        {
            var lensLabel = input[..^1];
            var lens = new Lens(lensLabel, -1);
            return new(lens, Enums.StepOperator.Remove);
        }

        private static Step ParseAddStep(string input)
        {
            var lensConfiguration = input.Split('=');
            var lens = new Lens(lensConfiguration[0], int.Parse(lensConfiguration[1]));
            return new(lens, Enums.StepOperator.Add);
        }
    }
}
