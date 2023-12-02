using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using aoc2023.day02.domain;

namespace aoc2023.day02
{
    public class Game
    {
        public readonly int Id;

        private readonly Bag bag;
        private readonly List<Handful> handfulsTaken;

        public Game(Bag bag, int id)
        {
            this.bag = bag;
            handfulsTaken = new List<Handful>();
            Id = id;
        }

        public void TakeHandfulFromBag(Handful handful)
        {
            handfulsTaken.Add(handful);
        }

        public bool IsPossible()
        {
            var isPossible = true;

            foreach (Handful handful in handfulsTaken)
            {
                if (!BagContainsEnoughCubes(handful))
                {
                    isPossible = false;
                }
            }

            return isPossible;
        }

        public int PowerOfMinimumCubes()
        {
            var minimumNumberOfRedCubesForPossibleGame = handfulsTaken.Max(h => h.NumberOfRedCubes);
            var minimumNumberOfGreenCubesForPossibleGame = handfulsTaken.Max(h => h.NumberOfGreenCubes);
            var minimumNumberOfBlueCubesForPossibleGame = handfulsTaken.Max(h => h.NumberOfBlueCubes);

            return minimumNumberOfRedCubesForPossibleGame *
                minimumNumberOfGreenCubesForPossibleGame *
                minimumNumberOfBlueCubesForPossibleGame;
        }

        private bool BagContainsEnoughCubes(Handful handful)
        {
            return bag.ContainsEnoughRedCubes(handful.NumberOfRedCubes) &&
                bag.ContainsEnoughGreenCubes(handful.NumberOfGreenCubes) &&
                bag.ContainsEnoughBlueCubes(handful.NumberOfBlueCubes);
        }
    }
}
