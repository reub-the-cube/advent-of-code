using System.Data;
using System.Numerics;

namespace aoc2022.day11.domain
{
    public class Monkey
    {
        private readonly string _worryLevelOperation;

        private readonly int _testDivisor = 0;
        private readonly int _nextMonkeyOnTruthyTest;
        private readonly int _nextMonkeyOnFalseyTest;

        public Queue<Item> Items { get; private set; }
        public int InspectionCount { get; private set; }

        public Monkey(string worryLevelOperation, int testDivisor, int nextMonkeyOnTruthyTest, int nextMonkeyOnFalseyTest)
        {
            Items = new Queue<Item>();

            _worryLevelOperation = worryLevelOperation;
            _testDivisor = testDivisor;
            _nextMonkeyOnTruthyTest = nextMonkeyOnTruthyTest;
            _nextMonkeyOnFalseyTest = nextMonkeyOnFalseyTest;
        }
       
        public void AddItem(Item item)
        {
            Items.Enqueue(item);
        }

        public int GetNextMonkey(BigInteger worryLevel)
        {
            if (worryLevel % _testDivisor == 0)
            {
                return _nextMonkeyOnTruthyTest;
            }
            else
            {
                return _nextMonkeyOnFalseyTest;
            }
        }

        public int GetTestDivisor()
        {
            return _testDivisor;
        }

        public Item InspectItem(Func<long, decimal> worryLevelReducer)
        {
            var item = Items.Dequeue();
            var newWorryValue = Parser.CalculateNewWorryLevel(_worryLevelOperation, item.GetWorryLevel());
            item.UpdateWorryLevelOnInspection(newWorryValue);
            item.UpdateWorryLevelAfterInspection(worryLevelReducer);

            InspectionCount++;

            return item;
        }
    }
}
