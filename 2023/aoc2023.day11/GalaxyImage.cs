using static aoc2023.day11.domain.Enums;

namespace aoc2023.day11
{
    public class GalaxyImage
    {
        private Dictionary<(int Row, int Column), SpaceMatter> _spaceMap;

        public GalaxyImage(Dictionary<(int Row, int Column), SpaceMatter> spaceMap)
        {
            _spaceMap = spaceMap;
        }

        public static GalaxyImage Build(List<string> galaxyImageInput)
        {
            // Build map
            var rowCount = galaxyImageInput.Count;
            var columnCount = galaxyImageInput[0].Length;
            var spaceMap = new Dictionary<(int Row, int Column), SpaceMatter>();

            for (var i = 0; i < rowCount; i++)
            {
                for (var j = 0; j < columnCount; j++)
                {
                    var spaceMatterValue = galaxyImageInput[i][j] == '.' ? SpaceMatter.EmptySpace : SpaceMatter.Galaxy;
                    spaceMap.Add((i, j), spaceMatterValue);
                }
            }

            return new GalaxyImage(spaceMap);
        }

        private List<int> GetEmptyColumns()
        {
            var emptySpaceColumns = new List<int>();

            // Expand horizontally
            for (int j = 0; j < _spaceMap.Max(s => s.Key.Column) + 1; j++)
            {
                if (_spaceMap.Where(s => s.Key.Column == j).All(g => g.Value == SpaceMatter.EmptySpace))
                {
                    emptySpaceColumns.Add(j);
                }
            }

            return emptySpaceColumns;
        }

        private List<int> GetEmptyRows()
        {
            var emptySpaceRows = new List<int>();

            // Expand vertically
            for (int i = 0; i < _spaceMap.Max(s => s.Key.Row) + 1; i++)
            {
                if (_spaceMap.Where(s => s.Key.Row == i).All(g => g.Value == SpaceMatter.EmptySpace))
                {
                    emptySpaceRows.Add(i);
                }
            }

            return emptySpaceRows;
        }

        public long GetSumOfShortestPaths(int emptySpaceMultiplier)
        {
            var allGalaxyLocations = new List<(int Row, int Column)>();
            for (int i = 0; i < _spaceMap.Keys.Max(k => k.Row) + 1; i++)
            {
                for (int j = 0; j < _spaceMap.Keys.Max(k => k.Column) + 1; j++)
                {
                    if (_spaceMap[(i, j)] == SpaceMatter.Galaxy)
                    {
                        allGalaxyLocations.Add((i, j));
                    }
                }
            }

            var emptySpaceColumns = GetEmptyColumns();
            var emptySpaceRows = GetEmptyRows();

            var shortestDistances = new Dictionary<(int RowFrom, int ColumnFrom, int RowTo, int ColumnTo), long>();
            for (int i = 0; i < allGalaxyLocations.Count; i++)
            {
                for (int j = i + 1; j < allGalaxyLocations.Count; j++)
                {
                    var rowFrom = allGalaxyLocations[i].Row;
                    var columnFrom = allGalaxyLocations[i].Column;
                    var rowTo = allGalaxyLocations[j].Row;
                    var columnTo = allGalaxyLocations[j].Column;
                    var rowSpaces = (emptySpaceMultiplier - 1) * emptySpaceRows.Where(r => r > Math.Min(rowFrom, rowTo) && r < Math.Max(rowFrom, rowTo)).Count();
                    var columnSpaces = (emptySpaceMultiplier - 1) * emptySpaceColumns.Where(c => c > Math.Min(columnFrom, columnTo) && c < Math.Max(columnFrom, columnTo)).Count();
                    long shortestDistance = Math.Abs(columnFrom - columnTo) + columnSpaces + Math.Abs(rowFrom - rowTo) + rowSpaces;
                    shortestDistances.Add((rowFrom, columnFrom, rowTo, columnTo), shortestDistance);
                }
            }

            return shortestDistances.Sum(kvp => kvp.Value);
        }
    }
}
