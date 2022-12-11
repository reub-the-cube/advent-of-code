using AoC.Core;
using aoc2022.day11.domain;
using System.Data;
using System.Diagnostics;

namespace aoc2022.day11
{
    public class Parser : IParser<Input>
    {
        private static readonly DataTable _dataTable = new();

        public Input ParseInput(string[] input)
        {
            int rowIndex = 0;
            var monkeys = new List<Monkey>();
            while (rowIndex < input.Length)
            {
                if (input[rowIndex][..6] == "Monkey")
                {
                    if (input[rowIndex + 1].Length < 18) throw new NotImplementedException("Might not work with no starting items.");
                    var startingItems = ParseStartingItems(input[rowIndex + 1]);
                    var operation = ParseOperation(input[rowIndex + 2]);
                    (int TestDivisor, int TruthyMonkey, int FalseyMonkey) = ParseNextMonkeys(input[rowIndex + 3], input[rowIndex + 4], input[rowIndex + 5]);

                    var thisMonkey = new Monkey(operation, TestDivisor, TruthyMonkey, FalseyMonkey);
                    startingItems.ForEach(thisMonkey.AddItem);
                    
                    monkeys.Add(thisMonkey);

                    rowIndex += 7;
                }
            }

            return new Input(monkeys);
        }

        private static List<Item> ParseStartingItems(string startingItems)
        {
            return startingItems[18..].Split(", ").Select(s => new Item(int.Parse(s))).ToList();
        }

        private static string ParseOperation(string operation)
        {
            var parts = operation[13..].Split(' ');

            Debug.Assert(parts[0] == "new", "only expect 'new' on left hand side of operation.");
            Debug.Assert(parts[1] == "=", "only expect '=' on the second part of the operation.");

            return string.Join(' ', parts[2..]);
        }

        private static (int TestDivisor, int TruthyMonkey, int FalseyMonkey) ParseNextMonkeys(string testLine, string truthyLine, string falseyLine)
        {
            return (
                int.Parse(testLine[21..]),
                int.Parse(truthyLine[29..]),
                int.Parse(falseyLine[30..])
            );
        }

        internal static long CalculateNewWorryLevel(string equation, long currentWorryLevel)
        {
            return Convert.ToInt64(_dataTable.Compute(equation.Replace("old", $"{currentWorryLevel}.0"), string.Empty));
        }
    }
}
