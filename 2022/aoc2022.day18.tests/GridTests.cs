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
            for (var i = 0; i < x.Length; i++)
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
        
        /*
         *  Block in cube at 1,1,1 with one cube out in each direction
         *  0,1,1 - left
         *  2,1,1 - right
         *  1,0,1 - below
         *  1,2,1 - above
         *  1,1,0 - in
         *  1,1,2 - out
         *  Total unconnected faces = 36, exposed faces = 30
         *  Total cubes = (-1 to 3 on X, -1 to 3 on Y, -1 to 3 on Z) = 5 * 5 * 5 = 125
         *  Total cubes should equal = 6 on the shape + 1 contained + 118 external
         *
         *  Block in cube at 1,1,1 and 2,1,1 with one cube out in each direction
         *  0,1,1 - left
         *  3,1,1 - right
         *  1,0,1 - below
         *  2,0,1 - below
         *  1,2,1 - above
         *  2,2,1 - above
         *  1,1,0 - in
         *  2,1,0 - in
         *  1,1,2 - out
         *  2,1,2 - out
         *  Total unconnected faces = 60 - 8, exposed faces = 52 - 10
         *  Total cubes = (-1 to 4 on X, -1 to 3 on Y, -1 to 3 on Z) = 6 * 5 * 5 = 150
         *  Total cubes should equal = 10 on the shape + 2 contained + 138 external
         */
        [Theory]
        [InlineData(new[] { 0, 2, 1, 1, 1, 1 }, new[] { 1, 1, 0, 2, 1, 1 }, new[] { 1, 1, 1, 1, 0, 2 }, 30)]
        [InlineData(new[] { 0, 3, 1, 2, 1, 2, 1, 2, 1, 2 }, new[] { 1, 1, 0, 0, 2, 2, 1, 1, 1, 1 }, new[] { 1, 1, 1, 1, 1, 1, 0, 0, 2, 2 }, 42)]
        public void MappingCubesOntoGridReturnsExpectedNumberOfExposedFacesForSimpleCube(int[] x, int[] y, int[] z, int expectedNumberOfFaces)
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
