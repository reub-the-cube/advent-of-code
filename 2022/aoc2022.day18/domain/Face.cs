namespace aoc2022.day18.domain
{
    public readonly record struct Face (int lowerX, int upperX, int lowerY, int upperY, int lowerZ, int upperZ, Cube FacingCube)
    {
        public static Face AddXYFace(int x, int y, int z, int zOffsetForCube)
        {
            return new(x, x + 1, y, y + 1, z, z, new Cube(x, y, z + zOffsetForCube));
        }

        public static Face AddXZFace(int x, int y, int z, int yOffsetForCube)
        {
            return new(x, x + 1, y, y, z, z + 1, new Cube(x, y + yOffsetForCube, z));
        }

        public static Face AddYZFace(int x, int y, int z, int xOffsetForCube)
        {
            return new(x, x, y, y + 1, z, z + 1, new Cube(x + xOffsetForCube, y, z));
        }
    }
}
