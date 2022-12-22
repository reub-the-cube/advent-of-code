using System.Diagnostics;

namespace aoc2022.day18.domain
{
    public class GridExplorer
    {
        private readonly HashSet<Cube> _containedCubes;
        private readonly HashSet<Cube> _cubes;
        private readonly HashSet<Cube> _externalCubes;
        private readonly HashSet<Cube> _visitedCubes;

        private readonly int _xLower;
        private readonly int _xUpper;
        private readonly int _yLower;
        private readonly int _yUpper;
        private readonly int _zLower;
        private readonly int _zUpper;

        public GridExplorer(HashSet<Cube> cubes)
        {
            _containedCubes = new HashSet<Cube>();
            _cubes = cubes;
            _externalCubes = new HashSet<Cube>();
            _visitedCubes = new HashSet<Cube>();

            _xLower = _cubes.Min(c => c.X);
            _xUpper = _cubes.Max(c => c.X);
            _yLower = _cubes.Min(c => c.Y);
            _yUpper = _cubes.Max(c => c.Y);
            _zLower = _cubes.Min(c => c.Z);
            _zUpper = _cubes.Max(c => c.Z);
        }

        public void ExploreCubes(Cube cubeToInspect)
        {
            _visitedCubes.Add(cubeToInspect);

            while (true)
            {
                var cubeIsKnown = CubeStateIsKnown(cubeToInspect);
                if (cubeIsKnown.HasValue) break;

                var neighbours = cubeToInspect.GetAdjacentCubes().ToList();
                var neighboursNotVisited = neighbours
                    .Where(c => !_visitedCubes.Contains(c))
                    .ToList();

                foreach (var neighbour in neighboursNotVisited)
                {
                    AddNeighbouringCubeToKnownCubes(neighbour);
                }

                AddCubeToKnownCubesBasedOnNeighbours(cubeToInspect, neighbours);
                break;
            }

            _externalCubes.RemoveWhere(IsCubePastEdge);
        }

        public IEnumerable<Cube> GetContainedCubes()
        {
            Debug.Assert(CubeTotalsAreCorrect());
            return _containedCubes;
        }

        private bool CubeTotalsAreCorrect()
        {
            var expectedCubes = (_xUpper - _xLower + 1) * (_yUpper - _yLower + 1) * (_zUpper - _zLower + 1);
            var totalCubes = _containedCubes.Count + _cubes.Count + _externalCubes.Count;

            return totalCubes == expectedCubes;
        }
        
        private bool? CubeStateIsKnown(Cube cubeToInspect)
        {
            if (_externalCubes.Contains(cubeToInspect))
            {
                // If this is already known to be an external cube
                return false;
            }

            if (_containedCubes.Contains(cubeToInspect))
            {
                // If this is already known an internal cube
                return true;
            }

            return null;
        }

        private void AddCubeToKnownCubesBasedOnNeighbours(Cube cubeToInspect, IEnumerable<Cube> neighbours)
        {
            // If it's a part of the shape then it can't be external or contained
            if (_cubes.Contains(cubeToInspect)) return;

            // If any of the neighbours is external then there's a path to freedom
            if (neighbours.Any(_externalCubes.Contains))
            {
                _externalCubes.Add(cubeToInspect);
            }
            else
            {
                _containedCubes.Add(cubeToInspect);
            }
        }

        private void AddNeighbouringCubeToKnownCubes(Cube neighbour)
        {
            if (IsCubePastEdge(neighbour))
            {
                _externalCubes.Add(neighbour);
            }
            else
            {
                ExploreCubes(neighbour);
            }
        }

        private bool IsCubePastEdge(Cube cube)
        {
            return IsOutOfRange(cube.X, _xLower, _xUpper) || 
                   IsOutOfRange(cube.Y, _yLower, _yUpper) || 
                   IsOutOfRange(cube.Z, _zLower, _zUpper);
        }

        private static bool IsOutOfRange(int index, int indexLower, int indexUpper)
        {
            return index < indexLower || index > indexUpper;
        }
    }
}
