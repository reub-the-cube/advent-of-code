namespace aoc2022.day18.domain
{
    public readonly record struct Cube(int X, int Y, int Z)
    {
        public List<Cube> GetAdjacentCubes()
        {
            return new List<Cube>
            {
                new Cube(X - 1, Y, Z),
                new Cube(X + 1, Y, Z),
                new Cube(X, Y - 1, Z),
                new Cube(X, Y + 1, Z),
                new Cube(X, Y, Z - 1),
                new Cube(X, Y, Z + 1)
            };
        }
    }
}
