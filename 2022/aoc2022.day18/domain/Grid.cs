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

        public int GetUnconnectedFaces()
        {
            return _faceCounter.Where(f => f.Value == 1).Count();
        }

        public int GetExposedFaces()
        {
            var unconnectedFaces = _faceCounter.Where(f => f.Value == 1).ToList();
            var xLower = unconnectedFaces.Min(f => f.Key.lowerX);
            var xUpper = unconnectedFaces.Max(f => f.Key.upperX);
            var yLower = unconnectedFaces.Min(f => f.Key.lowerY);
            var yUpper = unconnectedFaces.Max(f => f.Key.upperY);
            var zLower = unconnectedFaces.Min(f => f.Key.lowerZ);
            var zUpper = unconnectedFaces.Max(f => f.Key.upperZ);

            var facesToCheck = unconnectedFaces
                .Where(f =>
                {
                    return f.Key.lowerX > xLower && f.Key.upperX < xUpper &&
                           f.Key.lowerY > yLower && f.Key.upperY < yUpper &&
                           f.Key.lowerZ > zLower && f.Key.upperZ < zUpper;
                }).ToList();

            foreach (var faceToCheck in facesToCheck)
            {
                // is there a path to freedom?
                // move out in each direction recursively until hitting another face or going past the extremities of the shape
            }

            throw new NotImplementedException();
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