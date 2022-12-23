using System.Xml.Xsl;

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
            return GetMonkeyValue(name, false);
        }
        
        public long GetMonkeyNumberPrecisely(string name)
        {
            return GetMonkeyValue(name, true);
        }

        private long GetMonkeyValue(string name, bool withPrecision)
        {
            if (MonkeyNumbers.TryGetValue(name, out var value)) return value;

            value = EvaluateOperation(MonkeyOperations[name], withPrecision);

            return value;
        }

        private long EvaluateOperation(MathOperation monkeyOperation, bool withPrecision)
        {
            var left = ParseSide(monkeyOperation.Left, withPrecision);
            var right = ParseSide(monkeyOperation.Right, withPrecision);

            return monkeyOperation.Operation switch
            {
                "+" => left + right,
                "-" => left - right,
                "*" => left * right,
                "/" => withPrecision ? Divide(left, right) : left / right,
                _ => throw new NotImplementedException($"operation {monkeyOperation.Operation} not recognised.")
            };
        }

        private static long Divide(long left, long right)
        {
            if (left % right == 0) return left / right;

            throw new MonkeyOperationException($"Something smells monkey-like - {left} is not divisible by {right}");
        }

        private long ParseSide(string side, bool withPrecision)
        {
            if (long.TryParse(side, out var value)) return value;
            if (MonkeyNumbers.TryGetValue(side, out value)) return value;

            value = GetMonkeyValue(side, withPrecision);
            return value;
        }
    }

    public readonly record struct MathOperation(string Left, string Right, string Operation)
    {
    }

    public class MonkeyOperationException : Exception
    {
        public MonkeyOperationException(string message) : base(message)
        {
        }
    }
}
