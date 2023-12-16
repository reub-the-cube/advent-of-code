using static aoc2023.day16.Enums;

namespace aoc2023.day16
{
    public abstract class Tile
    {
        protected abstract Dictionary<Direction, List<Direction>> EntryExitDirections { get; }

        public List<Direction> GetExitDirectionsOfTravel(Direction entryDirection)
        {
            return EntryExitDirections[entryDirection];
        }
    }

    public class NothingTile : Tile
    {
        protected override Dictionary<Direction, List<Direction>> EntryExitDirections => new()
        {
            { Direction.Left, new() { Direction.Left } },
            { Direction.Up, new() { Direction.Up } },
            { Direction.Right, new() { Direction.Right } },
            { Direction.Down, new() { Direction.Down } }
        };
    }

    public class HorizontalSplitterTile : Tile
    {
        protected override Dictionary<Direction, List<Direction>> EntryExitDirections => new()
        {
            { Direction.Left, new() { Direction.Left } },
            { Direction.Up, new() { Direction.Left, Direction.Right } },
            { Direction.Right, new() { Direction.Right } },
            { Direction.Down, new() { Direction.Left, Direction.Right } }
        };
    }

    public class VerticalSplitterTile : Tile
    {
        protected override Dictionary<Direction, List<Direction>> EntryExitDirections => new()
        {
            { Direction.Left, new() { Direction.Up, Direction.Down } },
            { Direction.Up, new() { Direction.Up } },
            { Direction.Right, new() { Direction.Up, Direction.Down } },
            { Direction.Down, new() { Direction.Down } }
        };
    }

    public class ForwardSlashMirrorTile : Tile
    {
        protected override Dictionary<Direction, List<Direction>> EntryExitDirections => new()
        {
            { Direction.Left, new() { Direction.Up } },
            { Direction.Up, new() { Direction.Right } },
            { Direction.Right, new() { Direction.Down } },
            { Direction.Down, new() { Direction.Left } }
        };
    }

    public class BackwardSlashMirrorTile : Tile
    {
        protected override Dictionary<Direction, List<Direction>> EntryExitDirections => new()
        {
            { Direction.Left, new() { Direction.Down } },
            { Direction.Up, new() { Direction.Left } },
            { Direction.Right, new() { Direction.Up } },
            { Direction.Down, new() { Direction.Right } }
        };
    }
}
