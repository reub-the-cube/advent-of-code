namespace aoc2022.day18.domain
{
    public class Grid
    {
        private readonly Dictionary<Face, int> _faceCounter;

        public Grid()
        {
            _faceCounter = new Dictionary<Face, int>();
        }

        public void AddCube(Cube cube)
        {
            AddFace(Face.AddXYFace(cube.X, cube.Y, cube.Z));
            AddFace(Face.AddXYFace(cube.X, cube.Y, cube.Z + 1));
            AddFace(Face.AddXZFace(cube.X, cube.Y, cube.Z));
            AddFace(Face.AddXZFace(cube.X, cube.Y + 1, cube.Z));
            AddFace(Face.AddYZFace(cube.X, cube.Y, cube.Z));
            AddFace(Face.AddYZFace(cube.X + 1, cube.Y, cube.Z));
        }

        public int GetExposedFaces()
        {
            return _faceCounter.Where(f => f.Value == 1).Count();
        }

        private void AddFace(Face face)
        {
            if (!_faceCounter.ContainsKey(face))
            {
                _faceCounter.Add(face, 0);
            }
            _faceCounter[face]++;
        }
    }
}