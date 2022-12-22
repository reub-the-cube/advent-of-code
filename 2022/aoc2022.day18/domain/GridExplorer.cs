namespace aoc2022.day18.domain
{
    public class GridExplorer
    {
        private HashSet<Cube> ContainedCubes { get; init; }
        private HashSet<Cube> Cubes { get; init; }
        private HashSet<Cube> ExternalCubes { get; init; }
        private HashSet<Cube> VisitedCubes { get; init; }

        private int XLower { get; set; }
        private int XUpper { get; set; }
        private int YLower { get; set; }
        private int YUpper { get; set; }
        private int ZLower { get; set; }
        private int ZUpper { get; set; }

        public GridExplorer(HashSet<Cube> cubes)
        {
            ContainedCubes = new HashSet<Cube>();
            Cubes = cubes;
            ExternalCubes = new HashSet<Cube>();
            VisitedCubes = new HashSet<Cube>();

            XLower = Cubes.Min(c => c.X);
            XUpper = Cubes.Max(c => c.X);
            YLower = Cubes.Min(c => c.Y);
            YUpper = Cubes.Max(c => c.Y);
            ZLower = Cubes.Min(c => c.Z);
            ZUpper = Cubes.Max(c => c.Z);
        }

        public bool IsContained(Cube cubeToInspect)
        {
            VisitedCubes.Add(cubeToInspect);

            while (true)
            {
                if (ExternalCubes.Contains(cubeToInspect))
                {
                    // If this is already known to be an external cube
                    return false;
                }

                if (Cubes.Contains(cubeToInspect))
                {
                    // If this is already known to be a part of the shape
                    return false;
                }

                if (ContainedCubes.Contains(cubeToInspect))
                {
                    // If this is already known an internal cube
                    return true;
                }

                var neighbours = cubeToInspect.GetAdjacentCubes().ToList();
                var neighboursNotVisited = neighbours
                    .Where(c => !VisitedCubes.Contains(c))
                    .ToList();

                foreach (var neighbour in neighboursNotVisited)
                {
                    if (IsCubePastEdge(neighbour))
                    {
                        ExternalCubes.Add(neighbour);
                    }
                    else
                    {
                        if (IsContained(neighbour))
                        {
                            ContainedCubes.Add(neighbour);
                        }
                        else if (!Cubes.Contains(neighbour))
                        {
                            ExternalCubes.Add(neighbour);
                        }
                    }
                }

                if (neighbours.Any(ExternalCubes.Contains) && !Cubes.Contains(cubeToInspect))
                {
                    // If any neighbour is known to be external and this is not a part of the shape, it is also external
                    ExternalCubes.Add(cubeToInspect);
                    return false;
                }

                if (neighbours.Any(ExternalCubes.Contains))
                {
                    // If any neighbour is known to be external, this shape cannot be contained
                    return false;
                }

                if (neighbours.All(c => ContainedCubes.Contains(c) || Cubes.Contains(c)))
                {
                    // If all the neighbours are contained or a part of the shape
                    ContainedCubes.Add(cubeToInspect);
                    return true;
                }
                else
                {
                    throw new Exception("neighbours are not all contained or a part of the shape, none are external. What could it be?");
                }
            }
        }

        private bool IsCubePastEdge(Cube cube)
        {
            return cube.X < XLower || cube.X > XUpper || cube.Y < YLower || cube.Y > YUpper || cube.Z < ZLower || cube.Z > ZUpper;
        }
    }
}
