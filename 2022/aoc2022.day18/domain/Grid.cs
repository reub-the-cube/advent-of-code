using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace aoc2022.day18.domain
{
    public class Grid
    {
        private readonly HashSet<Cube> _cubes;
        private readonly HashSet<Cube> _externalCubes;
        private readonly Dictionary<Face, HashSet<Cube>> _faces;

        public Grid()
        {
            _cubes = new HashSet<Cube>();
            _externalCubes = new HashSet<Cube>();
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

        public void SubmergeShape()
        {
            var xLower = _cubes.Min(c => c.X) - 1;
            var xUpper = _cubes.Max(c => c.X) + 1;
            var yLower = _cubes.Min(c => c.Y) - 1;
            var yUpper = _cubes.Max(c => c.Y) + 1;
            var zLower = _cubes.Min(c => c.Z) - 1;
            var zUpper = _cubes.Max(c => c.Z) + 1;

            Debug.WriteLine($"{(xUpper - xLower + 1) * (yUpper - yLower + 1) * (zUpper - zLower + 1)} cubes to fill.");

            var startingPoint = new Cube(xLower, yLower, zLower);

            var cubesSubmerged = new HashSet<Cube>();
            var cubesToSubmerge = new Queue<Cube>();
            cubesToSubmerge.Enqueue(startingPoint);
            while (cubesToSubmerge.Any())
            {
                var cube = cubesToSubmerge.Dequeue();

                var neighbours = GetNeighboursInRange(cube, xLower, xUpper, yLower, yUpper, zLower, zUpper);

                foreach (var neighbour in neighbours)
                {
                    if (!cubesSubmerged.Contains(neighbour) && !_cubes.Contains(neighbour) && !cubesToSubmerge.Contains(neighbour))
                    {
                        _externalCubes.Add(neighbour);
                        cubesToSubmerge.Enqueue(neighbour);
                    }
                }

                cubesSubmerged.Add(cube);

                if (cubesSubmerged.Count % 500 == 0)
                {
                    Debug.WriteLine($"Cubes submerged so far: {cubesSubmerged.Count}");
                    Debug.WriteLine($"Current queue length: {cubesToSubmerge.Count}");
                }
            }
        }

        private static HashSet<Cube> GetNeighboursInRange(Cube cube, int xLower, int xUpper, int yLower, int yUpper, int zLower, int zUpper)
        {
            return cube.GetAdjacentCubes()
                .Where(c =>
                {
                    return !GridExplorer.IsOutOfRange(c.X, xLower, xUpper) &&
                           !GridExplorer.IsOutOfRange(c.Y, yLower, yUpper) &&
                           !GridExplorer.IsOutOfRange(c.Z, zLower, zUpper);
                })
                .ToHashSet();
        }

        public int GetExternalFaces()
        {
            return _externalCubes
                .SelectMany(c => c.GetAdjacentCubes())
                .Count(_cubes.Contains);
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