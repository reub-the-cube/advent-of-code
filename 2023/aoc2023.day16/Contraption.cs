using System.Data;
using static aoc2023.day16.Enums;

namespace aoc2023.day16
{
    public class Contraption
    {
        private Tile[,] Tiles { get; set; }
        private readonly HashSet<(int Row, int Column, Direction Heading)> _energisedTiles = new();
        public HashSet<(int Row, int Column, Direction Heading)> EnergisedTiles => _energisedTiles;
        public HashSet<(int Row, int Column)> UniqueEnergisedTiles => _energisedTiles
            .GroupBy(t => (t.Row, t.Column))
            .Select(s => s.Key).ToHashSet();

        public Contraption(List<string> layout)
        {
            var rowCount = layout.Count;
            var columnCount = layout[0].Length;
            Tiles = new Tile[rowCount, columnCount];

            FillTiles(layout);
        }

        public void FillWithLight(int row, int column, Direction heading)
        {
            if (_energisedTiles.Contains((row, column, heading))) return;

            _energisedTiles.Add((row, column, heading));

            var nextDirections = Tiles[row, column].GetExitDirectionsOfTravel(heading);
            foreach (var direction in nextDirections)
            {
                MoveToNextTile(row, column, direction);
            }
        }

        public void MoveToNextTile(int row, int column, Direction heading)
        {
            (int NextRow, int NextColumn) = heading switch
            {
                Direction.Left => (row, column - 1),
                Direction.Up => (row - 1, column),
                Direction.Right => (row, column + 1),
                Direction.Down => (row + 1, column),
                _ => throw new NotSupportedException()
            };

            if (IsInBounds(NextRow, NextColumn))
            {
                FillWithLight(NextRow, NextColumn, heading);
            }
        }

        private bool IsInBounds(int row, int column)
        {
            if (row < 0 || row > Tiles.GetUpperBound(0))
            {
                return false;
            }

            if (column < 0 || column > Tiles.GetUpperBound(1))
            {
                return false;
            }

            return true;
        }

        private void FillTiles(List<string> layout)
        {
            var rowCount = layout.Count;
            var columnCount = layout[0].Length;
            Tiles = new Tile[rowCount, columnCount];

            for (var i = 0; i < rowCount; i++)
            {
                for (var j = 0; j < columnCount; j++)
                {
                    SetTile(i, j, layout[i][j]);
                }
            }
        }

        private void SetTile(int row, int column, char tileType)
        {
            Tiles[row, column] = tileType switch
            {
                '.' => new NothingTile(),
                '-' => new HorizontalSplitterTile(),
                '|' => new VerticalSplitterTile(),
                '/' => new ForwardSlashMirrorTile(),
                '\\' => new BackwardSlashMirrorTile(),
                _ => throw new NotImplementedException()
            };
        }
    }
}
