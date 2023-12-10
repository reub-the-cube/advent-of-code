using System.Data.Common;
using System.Text;

namespace aoc2023.day10
{
    public class PipeField
    {
        private Tile[,] _tiles;

        public PipeField(Tile[,] tiles)
        {
            _tiles = tiles;
        }

        public override string ToString()
        {
            var stringRepresentation = new List<string>();
            
            for (var i = 0; i < _tiles.GetUpperBound(0) + 1; i++)
            {
                var lineBuilder = new StringBuilder();
                for (var j = 0; j < _tiles.GetUpperBound(1) + 1; j++)
                {
                    lineBuilder.Append(_tiles[i, j].PipeValue);
                }
                stringRepresentation.Add(lineBuilder.ToString());
            }

            return string.Join(Environment.NewLine, stringRepresentation);
        }

        public (bool Exists, int Row, int Column) FindStart()
        {
            for (var i = 0; i < _tiles.GetUpperBound(0) + 1; i++)
            {
                for (var j = 0; j < _tiles.GetUpperBound(1) + 1; j++)
                {
                    if (_tiles[i, j].PipeValue == 'S')
                    {
                        return (true, i, j);
                    }
                }
            }

            return (false, -1, -1);
        }

        public int GetFurthestDistance(int row, int column)
        {
            var visitedTiles = GetTilesInLoop(row, column);
            return visitedTiles.Max(kvp => kvp.Value);
        }

        public PipeField RemoveJunkPipes()
        {
            var start = FindStart();
            var tilesInLoop = GetTilesInLoop(start.Row, start.Column);

            var rowCount = _tiles.GetUpperBound(0) + 1;
            var columnCount = _tiles.GetUpperBound(1) + 1;
            var tiles = new Tile[rowCount, columnCount];

            for (var i = 0; i < rowCount; i++)
            {
                for (var j = 0; j < columnCount; j++)
                {
                    char thisPipe = tilesInLoop.ContainsKey((i, j)) ? _tiles[i, j].PipeValue : '.';
                    char? above = i > 0 ? _tiles[i - 1, j].PipeValue : null;
                    char? right = j < columnCount - 1 ? _tiles[i, j + 1].PipeValue : null;
                    char? below = i < rowCount - 1 ? _tiles[i + 1, j].PipeValue : null;
                    char? left = j > 0 ? _tiles[i, j - 1].PipeValue : null;

                    tiles[i, j] = new Tile(thisPipe, above, right, below, left);
                }
            }

            return new PipeField(tiles);
        }

        public int GetEnclosedTiles()
        {
            // Replace 'S' with the correct pipe
            // Find the highest top-left corner (F) and trace the shape
            // Keep perimeter on the right the whole time
            throw new NotImplementedException();
        }

        public static Tile[,] BuildField(char[][] pipeLayout)
        {
            var rowCount = pipeLayout.Length;
            var columnCount = pipeLayout[0].Length;
            var tiles = new Tile[rowCount, columnCount];

            for (var i = 0; i < rowCount; i++)
            {
                for (var j = 0; j < columnCount; j++)
                {
                    char? above = i > 0 ? pipeLayout[i - 1][j] : null;
                    char? right = j < columnCount - 1 ? pipeLayout[i][j + 1] : null;
                    char? below = i < rowCount - 1 ? pipeLayout[i + 1][j] : null;
                    char? left = j > 0 ? pipeLayout[i][j - 1] : null;

                    tiles[i, j] = new Tile(pipeLayout[i][j], above, right, below, left);
                }
            }

            return tiles;
        }

        private Dictionary<(int Row, int Column), int> GetTilesInLoop(int startRow, int startColumn)
        {
            var visitedTiles = new Dictionary<(int Row, int Column), int>
            {
                { (startRow, startColumn), 0 }
            };
            var numberOfSteps = 0;
            var connectedNeighbours = GetConnectingNeighbours(startRow, startColumn);

            while (connectedNeighbours.Count > 0)
            {
                numberOfSteps++;
                var nextNeighbours = new List<(int Row, int Column)>();

                foreach (var neighbour in connectedNeighbours)
                {
                    visitedTiles.Add(neighbour, numberOfSteps);
                    nextNeighbours.AddRange(GetConnectingNeighbours(neighbour.Row, neighbour.Column));
                }

                connectedNeighbours = nextNeighbours.Distinct().Where(n => !visitedTiles.ContainsKey(n)).ToList();
            }

            return visitedTiles;
        }

        private List<(int Row, int Column)> GetConnectingNeighbours(int row, int column)
        {
            var connectingNeighbours = new List<(int Row, int Column)>();
            
            if (IsConnectedFromAbove(row, column))
            {
                connectingNeighbours.Add((row - 1, column));
            }
            
            if (IsConnectedFromRight(row, column))
            {
                connectingNeighbours.Add((row, column + 1));
            }

            if (IsConnectedFromBelow(row, column))
            {
                connectingNeighbours.Add((row + 1, column));
            }

            if (IsConnectedFromLeft(row, column))
            {
                connectingNeighbours.Add((row, column - 1));
            }

            return connectingNeighbours;
        }

        private bool IsConnectedFromAbove(int row, int column)
        {
            char? pipeAbove = row > 0 ? _tiles[row - 1, column].PipeValue : null;
            return Tile.IsConnectedToAbove(_tiles[row, column].PipeValue, pipeAbove);
        }

        private bool IsConnectedFromRight(int row, int column)
        {
            int columnCount = _tiles.GetUpperBound(1);
            char? pipeRight = column < columnCount ? _tiles[row, column + 1].PipeValue : null;
            return Tile.IsConnectedToRight(_tiles[row, column].PipeValue, pipeRight);
        }

        private bool IsConnectedFromBelow(int row, int column)
        {
            int rowCount = _tiles.GetUpperBound(0);
            char? pipeBelow = row < rowCount ? _tiles[row + 1, column].PipeValue : null;
            return Tile.IsConnectedToBelow(_tiles[row, column].PipeValue, pipeBelow);
        }

        private bool IsConnectedFromLeft(int row, int column)
        {
            char? pipeLeft = column > 0 ? _tiles[row, column - 1].PipeValue : null;
            return Tile.IsConnectedToLeft(_tiles[row, column].PipeValue, pipeLeft);
        }
    }
}
