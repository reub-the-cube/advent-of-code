namespace aoc2023.day02
{
    public class Bag
    {
        private readonly int numberOfRedCubes;
        private readonly int numberOfGreenCubes;
        private readonly int numberOfBlueCubes;

        public Bag(int numberOfRedCubes, int numberOfGreenCubes, int numberOfBlueCubes)
        {
            this.numberOfRedCubes = numberOfRedCubes;
            this.numberOfGreenCubes = numberOfGreenCubes;
            this.numberOfBlueCubes = numberOfBlueCubes;
        }

        public bool ContainsEnoughRedCubes(int numberToCheck)
        {
            return numberOfRedCubes >= numberToCheck;
        }

        public bool ContainsEnoughGreenCubes(int numberToCheck)
        {
            return numberOfGreenCubes >= numberToCheck;
        }

        public bool ContainsEnoughBlueCubes(int numberToCheck)
        {
            return numberOfBlueCubes >= numberToCheck;
        }
    }
}