namespace aoc2022.day18.domain
{
    public class Grid
    {
        private readonly HashSet<Cube> _cubes;
        private readonly Dictionary<Face, HashSet<Cube>> _faces;

        public Grid()
        {
            _cubes = new HashSet<Cube>();
            _faces = new Dictionary<Face, HashSet<Cube>>();
        }

        public void AddCube(Cube cube)
        {
            AddFace(Face.AddXYFace(cube.X, cube.Y, cube.Z), cube);
            AddFace(Face.AddXYFace(cube.X, cube.Y, cube.Z + 1), cube);
            AddFace(Face.AddXZFace(cube.X, cube.Y, cube.Z), cube);
            AddFace(Face.AddXZFace(cube.X, cube.Y + 1, cube.Z), cube);
            AddFace(Face.AddYZFace(cube.X, cube.Y, cube.Z), cube);
            AddFace(Face.AddYZFace(cube.X + 1, cube.Y, cube.Z), cube);
            _cubes.Add(cube);
        }

        public int GetUnconnectedFaces()
        {
            return _faces.Count(f => f.Value.Count == 1);
        }

        public int GetExposedFaces()
        {
            // Exposed faces = unconnected faces - exposed faces of internal shape(s)
            var unconnectedFaces = GetUnconnectedFaces();
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
                .Where(f => f.Value.Count == 1)
                .Select(f => f.Value.First())
                .Distinct()
                .ToList();

            var gridExplorer = new GridExplorer(_cubes);
            // This is mapping the grid, exploring for contained cubes, none of the parts of the shape
            // themselves are going to be air gaps
            singleFacedCubes.ForEach(gridExplorer.ExploreCubes);
            var internalCubes = gridExplorer.GetContainedCubes();

            return internalCubes.ToList();
        }

        private void AddFace(Face face, Cube belongsTo)
        {
            if (!_faces.ContainsKey(face))
            {
                _faces.Add(face, new HashSet<Cube>());
            }
            _faces[face].Add(belongsTo);
        }
    }
}