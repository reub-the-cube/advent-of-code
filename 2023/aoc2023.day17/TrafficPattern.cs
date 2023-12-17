using aoc2023.day17.domain;

namespace aoc2023.day17
{
    public class TrafficPattern
    {
        private CityBlock[,] CityBlocks { get; set; }
        
        private Dictionary<Position, long> MinimumHeatLosses { get; set; }
        private HashSet<Position> UnvisitedBlocks { get; set; }
        private Position Destination { get; set; }

        public TrafficPattern(List<List<int>> heatLoss)
        {
            CityBlocks = new CityBlock[0, 0];
            MinimumHeatLosses = new Dictionary<Position, long>();
            UnvisitedBlocks = new HashSet<Position>();
            Destination = new Position(0, 0);

            FillCityBlocks(heatLoss);
        }

        public long GetLeastHeatLossPath(Position from, Position to)
        {
            ResetShortestDistances();
            ResetUnvisitedBlocks();
            Destination = to;

            MinimumHeatLosses[from] = 0;

            ExploreBlockPath(from.Row, from.Column);

            var minimumHeatLoss = MinimumHeatLosses[to];
            return minimumHeatLoss;
        }
        private void ExploreBlockPath(int row, int column)
        {
            VisitBlock(row, column);

            if (UnvisitedBlocks.Contains(Destination))
            {
                // Haven't got there yet
                // Get unvisited node with smallest tentative distance
                var nextBlockOptions = MinimumHeatLosses.Where(m => UnvisitedBlocks.Contains(m.Key));
                if (nextBlockOptions.Any())
                {
                    KeyValuePair<Position, long> nextBlock = nextBlockOptions.First();
                    foreach (var nextBlockOption in nextBlockOptions.Skip(1))
                    {
                        if (nextBlockOption.Value < nextBlock.Value)
                        {
                            nextBlock = nextBlockOption;
                        }
                    }
                    ExploreBlockPath(nextBlock.Key.Row, nextBlock.Key.Column);
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }

        private void VisitBlock(int row, int column)
        {
            var currentBlock = new Position(row, column);

            var neighbours = CityBlocks[currentBlock.Row, currentBlock.Column].Neighbours;
            var unvisitedNeighbours = neighbours.Where(UnvisitedBlocks.Contains).ToList();

            MinimumHeatLosses.TryGetValue(currentBlock, out long startingHeatLoss);
            foreach (var unvisitedNeighbour in unvisitedNeighbours)
            {
                var newHeatLoss = startingHeatLoss + CityBlocks[unvisitedNeighbour.Row, unvisitedNeighbour.Column].HeatLoss;

                if (MinimumHeatLosses.TryGetValue(unvisitedNeighbour, out long value))
                {
                    MinimumHeatLosses[unvisitedNeighbour] = Math.Min(value, newHeatLoss);
                }
                else
                {
                    MinimumHeatLosses[unvisitedNeighbour] = newHeatLoss;
                }
            }

            UnvisitedBlocks.Remove(currentBlock);
        }

        private void FillCityBlocks(List<List<int>> heatLoss)
        {
            var rowCount = heatLoss.Count;
            var columnCount = heatLoss[0].Count;
            CityBlocks = new CityBlock[rowCount, columnCount];

            for (var i = 0; i < rowCount; i++)
            {
                for (var j = 0; j < columnCount; j++)
                {
                    SetCityBlock(i, j, heatLoss[i][j]);
                }
            }
        }

        private void SetCityBlock(int row, int column, int heatLoss)
        {
            var neighbours = GetNeighbouringBlocks(row, column);
            CityBlocks[row, column] = new CityBlock(new Position(row, column), neighbours, heatLoss);
        }

        private List<Position> GetNeighbouringBlocks(int row, int column)
        {
            var rowCount = CityBlocks.GetUpperBound(0);
            var columnCount = CityBlocks.GetUpperBound(1);

            var neighbours = new List<Position>();
            if (column > 0) neighbours.Add(new Position(row, column - 1));
            if (row > 0) neighbours.Add(new Position(row - 1, column));
            if (column < columnCount) neighbours.Add(new Position(row, column + 1));
            if (row < rowCount) neighbours.Add(new Position(row + 1, column));

            return neighbours;
        }

        private void ResetShortestDistances()
        {
            MinimumHeatLosses.Clear();
        }

        private void ResetUnvisitedBlocks()
        {
            UnvisitedBlocks.Clear();

            for (int i = 0; i < CityBlocks.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < CityBlocks.GetUpperBound(1) + 1; j++)
                {
                    UnvisitedBlocks.Add(new Position(i, j));
                }
            }
        }
    }
}
