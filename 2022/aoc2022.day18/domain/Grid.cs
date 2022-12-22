namespace aoc2022.day18.domain
{
    public class Grid
    {
        private readonly HashSet<Cube> _cubes;
        private readonly Dictionary<Face, int> _faces;

        public Grid()
        {
            _cubes = new HashSet<Cube>();
            _faces = new Dictionary<Face, int>();
        }

        public void AddCube(Cube cube)
        {
            AddFace(Face.AddXYFace(cube.X, cube.Y, cube.Z, -1));
            AddFace(Face.AddXYFace(cube.X, cube.Y, cube.Z + 1, 0));
            AddFace(Face.AddXZFace(cube.X, cube.Y, cube.Z, -1));
            AddFace(Face.AddXZFace(cube.X, cube.Y + 1, cube.Z, 0));
            AddFace(Face.AddYZFace(cube.X, cube.Y, cube.Z, -1));
            AddFace(Face.AddYZFace(cube.X + 1, cube.Y, cube.Z, 0));
            _cubes.Add(cube);
        }

        public int GetUnconnectedFaces()
        {
            return _faces.Where(f => f.Value == 1).Count();
        }

        public int GetExposedFaces()
        {
            // Exposed faces = unconnected faces - exposed faces of internal shape(s)
            var unconnectedFaces = _faces.Where(f => f.Value == 1).Count();

            var internalCubes = GetInternalCubes();
            var internalGrid = new Grid();
            if (internalCubes.Any())
            {
                internalCubes.ForEach(internalGrid.AddCube);
                return unconnectedFaces - internalGrid.GetExposedFaces();
            }
            else
            {
                return unconnectedFaces;
            }
        }

        private List<Cube> GetInternalCubes()
        {
            var singleFacedCubes = _faces
                .Where(f => f.Value == 1)
                .Select(f => f.Key.FacingCube)
                .Distinct()
                .ToHashSet();

            var gridExplorer = new GridExplorer(_cubes);
            var internalCubes = singleFacedCubes.Where(gridExplorer.IsContained).ToList();

            return internalCubes.ToList();
        }

        private void AddFace(Face face)
        {
            if (!_faces.ContainsKey(face))
            {
                _faces.Add(face, 0);
            }
            _faces[face]++;
        }
    }
}