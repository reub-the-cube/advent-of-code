namespace aoc2022.day21.domain
{
    public class Riddle
    {
        private Dictionary<string, long> MonkeyNumbers { get; set; }
        public Dictionary<string, MathOperation> MonkeyOperations { get; set; }

        public Riddle()
        {
            MonkeyNumbers = new Dictionary<string, long>();
            MonkeyOperations = new Dictionary<string, MathOperation>();
        }

        public void AddMonkey(string name, long number)
        {
            MonkeyNumbers.Add(name, number);
        }

        public void ChangeMonkeyNumber(string name, long number)
        {
            // monkey will only be in one of these but whatever
            MonkeyOperations.Remove(name);
            MonkeyNumbers.Remove(name);

            AddMonkey(name, number);
        }

        public void ChangeMonkeyOperation(string name, string leftMonkey, string rightMonkey, string operation)
        {
            // monkey will only be in one of these but whatever
            MonkeyOperations.Remove(name);
            MonkeyNumbers.Remove(name);

            AddMonkey(name, leftMonkey, rightMonkey, operation);
        }

        public void AddMonkey(string name, long leftNumber, string rightMonkey, string operation)
        {
            AddMonkey(name, leftNumber.ToString(), rightMonkey, operation);
        }

        public void AddMonkey(string name, string leftMonkey, string rightMonkey, string operation)
        {
            // If parse to number is possible 
            MonkeyOperations.Add(name, new MathOperation(leftMonkey, rightMonkey, operation));
        }

        public long GetMonkeyNumber(string name)
        {
            if (MonkeyNumbers.TryGetValue(name, out long value)) return value;

            value = EvaluateOperation(MonkeyOperations[name]);

            return value;
        }

        private long EvaluateOperation(MathOperation monkeyOperation)
        {
            var left = ParseSide(monkeyOperation.Left);
            var right = ParseSide(monkeyOperation.Right);

            return monkeyOperation.Operation switch
            {
                "+" => left + right,
                "-" => left - right,
                "*" => left * right,
                "/" => left / right,
                _ => throw new NotImplementedException($"operation {monkeyOperation.Operation} not recognised.")
            };
        }

        private long ParseSide(string side)
        {
            if (long.TryParse(side, out long value)) return value;
            if (MonkeyNumbers.TryGetValue(side, out value)) return value;

            value = GetMonkeyNumber(side);
            return value;
        }
    }

    public readonly record struct MathOperation(string Left, string Right, string Operation)
    {
    }
}
