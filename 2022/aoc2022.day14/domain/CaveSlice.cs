using System.Runtime.CompilerServices;
using System.Text;

namespace aoc2022.day14.domain
{
    public class CaveSlice
    {
        private Tile[,] Tiles { get; set; }
        private Position EntryPosition { get; set; }
        public int TotalGrainsOfSand { get; private set; }

        public CaveSlice(Tile[,] tiles)
        {
            Tiles = tiles;
        }

        public int GetNumberOfRows() => Tiles.GetUpperBound(0);
        public int GetNumberOfColumns() => Tiles.GetUpperBound(1);

        public CaveSlice AddLineOfRocks(string rockFormation, int columnOffset)
        {
            var coordinates = rockFormation
                .Split(" -> ")
                .Select(c =>
                {
                    var coordinateAsArray = c.Split(',');
                    return new Position(Convert.ToInt32(coordinateAsArray[1]), Convert.ToInt32(coordinateAsArray[0]) - columnOffset);
                })
                .ToList();

            for (int i = 0; i < coordinates.Count - 1; i++)
            {
                MakeRangeOfTilesARock(coordinates[i], coordinates[i + 1]);
            }

            return new CaveSlice(Tiles);
        }

        public Position? AddGrainOfSand()
        {
            var position = new Position(EntryPosition.Row, EntryPosition.Column);

            var nextTileWasAvailable = true;
            var nextTileState = NextTileState.Air;
            while (nextTileWasAvailable)
            {
                (nextTileState, position) = TryMove(position);
                nextTileWasAvailable = nextTileState == NextTileState.Air;
            }

            if (nextTileState == NextTileState.Abyss)
            {
                return null;
            }

            if (nextTileState == NextTileState.Blocked)
            {
                SetTileState(position.Row, position.Column, TileState.Sand);
            }

            TotalGrainsOfSand++;
            return position;
        }

        private (NextTileState NextTileState, Position NewPosition) TryMove(Position position)
        {
            (var nextTileState, position) = TryMoveDown(position);

            if (nextTileState == NextTileState.Blocked)
            {
                (nextTileState, position) = TryMoveDownAndLeft(position);
            }

            if (nextTileState == NextTileState.Blocked)
            {
                (nextTileState, position) = TryMoveDownAndRight(position);
            }

            return (nextTileState, position);
        }

        private (NextTileState nextTileState, Position position) TryMoveDown(Position position)
        {
            var nextTileStateDown = CanMoveDown(position);
            if (nextTileStateDown == NextTileState.Air)
            {
                position = position.MoveDown();
            }

            return (nextTileStateDown, position);
        }

        private (NextTileState nextTileState, Position position) TryMoveDownAndLeft(Position position)
        {
            var nextTileState = CanMoveDownAndLeft(position);
            if (nextTileState == NextTileState.Air)
            {
                position = position.MoveDownAndLeft();
            }

            return (nextTileState, position);
        }

        private (NextTileState nextTileState, Position position) TryMoveDownAndRight(Position position)
        {
            var nextTileState = CanMoveDownAndRight(position);
            if (nextTileState == NextTileState.Air)
            {
                position = position.MoveDownAndRight();
            }

            return (nextTileState, position);
        }

        private NextTileState CanMoveDown(Position position)
        {
            if (position.Row + 1 > Tiles.GetUpperBound(0)) return NextTileState.Abyss;

            return Tiles[position.Row + 1, position.Column].State switch
            {
                TileState.Air => NextTileState.Air,
                _ => NextTileState.Blocked
            };
        }

        private NextTileState CanMoveDownAndLeft(Position position)
        {
            if (position.Column - 1 < Tiles.GetLowerBound(1)) return NextTileState.Abyss;

            return Tiles[position.Row + 1, position.Column - 1].State switch
            {
                TileState.Air => NextTileState.Air,
                _ => NextTileState.Blocked
            };
        }

        private NextTileState CanMoveDownAndRight(Position position)
        {
            if (position.Column + 1 > Tiles.GetUpperBound(1)) return NextTileState.Abyss;
            
            return Tiles[position.Row + 1, position.Column + 1].State switch
            {
                TileState.Air => NextTileState.Air,
                _ => NextTileState.Blocked
            };
        }

        public CaveSlice Clone()
        {
            return new CaveSlice((Tile[,])Tiles.Clone());
        }

        public void SetSandDropPoint(int entryRow, int entryColumn)
        {
            EntryPosition = new Position(entryRow, entryColumn);
        }

        public override string ToString()
        {
            var caveState = new StringBuilder();
            for (int i = 0; i <= Tiles.GetUpperBound(0); i++)
            {
                caveState.AppendLine();

                var rowState = string.Empty;
                for (int j = 0; j <= Tiles.GetUpperBound(1); j++)
                {
                    switch (Tiles[i, j].State)
                    {
                        case TileState.Air:
                            rowState += '.';
                            break;
                        case TileState.Rock:
                            rowState += "#";
                            break;
                        case TileState.Sand:
                            rowState += "o";
                            break;
                        default:
                            break;
                    }
                }

                caveState.Append(rowState);
            }

            return caveState.ToString();
        }

        private void MakeRangeOfTilesARock(Position from, Position to)
        {
            (int RowMin, int RowMax) = (Math.Min(from.Row, to.Row), Math.Max(from.Row, to.Row));
            (int ColumnMin, int ColumnMax) = (Math.Min(from.Column, to.Column), Math.Max(from.Column, to.Column));

            for (int i = RowMin; i <= RowMax; i++)
            {
                for (int j = ColumnMin; j <= ColumnMax; j++)
                {
                    SetTileState(i, j, TileState.Rock);
                }
            }
        }

        private void SetTileState(int row, int column, TileState state)
        {
            var currentTile = Tiles[row, column];
            Tiles[row, column] = currentTile with { State = state };
        }
    }


    public readonly record struct Position(int Row, int Column);

    public readonly record struct Tile(Position Position, TileState State);

    public enum TileState
    {
        Air,
        Rock,
        Sand
    }

    public enum NextTileState
    {
        Air,
        Blocked,
        Abyss
    }
}
