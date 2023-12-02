namespace aoc2023.day02.domain
{
    public record Handful(int NumberOfRedCubes, int NumberOfGreenCubes, int NumberOfBlueCubes)
    {
        public Handful AddRedCubes(int numberOfRedCubes)
        {
            return new Handful(NumberOfRedCubes + numberOfRedCubes, NumberOfGreenCubes, NumberOfBlueCubes);
        }

        public Handful AddGreenCubes(int numberOfGreenCubes)
        {
            return new Handful(NumberOfRedCubes, NumberOfGreenCubes + numberOfGreenCubes, NumberOfBlueCubes);
        }

        public Handful AddBlueCubes(int numberOfBlueCubes)
        {
            return new Handful(NumberOfRedCubes, NumberOfGreenCubes, NumberOfBlueCubes + numberOfBlueCubes);
        }
    }
}