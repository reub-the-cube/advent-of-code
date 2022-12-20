using aoc2022.day18.domain;
using FluentAssertions;

namespace aoc2022.day18.tests
{
    public class GridTests
    {
        [Theory]
        [InlineData(new[] { 2 }, new[] { 2 }, new[] { 2 }, 6)]
        [InlineData(new[] { 1, 2 }, new[] { 1, 1 }, new[] { 1, 1 }, 10)]
        [InlineData(new[] { 2, 1, 3, 2, 2, 2, 2, 2, 2, 1, 3, 2, 2 }, new[] { 2, 2, 2, 1, 3, 2, 2, 2, 2, 2, 2, 1, 3 }, new[] { 2, 2, 2, 2, 2, 1, 3, 4, 6, 5, 5, 5, 5 }, 64)]
        public void MappingCubesOntoGridReturnsExpectedNumberOfUnconnectedFaces(int[] x, int[] y, int[] z, int expectedNumberOfFaces)
        {
            // Check inputs are the same length
            x.Length.Should().Be(y.Length);
            y.Length.Should().Be(z.Length);

            var cubes = new List<Cube>();
            for (int i = 0; i < x.Length; i++)
            {
                cubes.Add(new Cube(x[i], y[i], z[i]));
            }
            var grid = new Grid();

            cubes.ForEach(grid.AddCube);

            var actualNumberOfFaces = grid.GetUnconnectedFaces();

            actualNumberOfFaces.Should().Be(expectedNumberOfFaces);
        }

        [Theory]
        [InlineData(new[] { 2, 1, 3, 2, 2, 2, 2, 2, 2, 1, 3, 2, 2 }, new[] { 2, 2, 2, 1, 3, 2, 2, 2, 2, 2, 2, 1, 3 }, new[] { 2, 2, 2, 2, 2, 1, 3, 4, 6, 5, 5, 5, 5 }, 58)]
        public void MappingCubesOntoGridReturnsExpectedNumberOfExposedFaces(int[] x, int[] y, int[] z, int expectedNumberOfFaces)
        {
            // Check inputs are the same length
            x.Length.Should().Be(y.Length);
            y.Length.Should().Be(z.Length);

            var cubes = new List<Cube>();
            for (int i = 0; i < x.Length; i++)
            {
                cubes.Add(new Cube(x[i], y[i], z[i]));
            }
            var grid = new Grid();

            cubes.ForEach(grid.AddCube);

            var actualNumberOfFaces = grid.GetExposedFaces();

            actualNumberOfFaces.Should().Be(expectedNumberOfFaces);
        }
    }
}
