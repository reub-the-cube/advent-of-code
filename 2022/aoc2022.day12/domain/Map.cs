namespace aoc2022.day12.domain;

public class Map
{
    private Square[,] Squares { get; set; }

    public Map(Square[,] squares)
    {
        Squares = squares;
    }

    public Stack<Position> GetPositionsOfCertainHeight(int targetHeight)
    {
        var startingPositions = new Stack<Position>();
        for (int i = 0; i <= Squares.GetUpperBound(0); i++)
        {
            for (int j = 0; j <= Squares.GetUpperBound(1); j++)
            {
                if (Squares[i, j].Height == targetHeight)
                {
                    startingPositions.Push(Squares[i, j].Position);
                }
            }
        }

        return startingPositions;
    }
    
    public List<Position> GetUnvisitedAvailableNeighbours(Position currentPosition)
    {
        return (from neighbour in Squares[currentPosition.Row, currentPosition.Column].Neighbours
            let neighbourUnvisited = !Squares[neighbour.Row, neighbour.Column].Visited
            let neighbourReachable =
                Squares[neighbour.Row, neighbour.Column].Height -
                Squares[currentPosition.Row, currentPosition.Column].Height < 2
            where neighbourUnvisited && neighbourReachable
            select neighbour).ToList();
    }

    public Map MarkAsVisited(Position position)
    {
        var currentSquare = Squares[position.Row, position.Column];
        Squares[position.Row, position.Column] = currentSquare with {Visited = true};
        return new Map(Squares);
    }

    public static Map Build(int[][] input)
    {
        var rowCount = input.Length;
        var columnCount = input[0].Length;
        var squares = new Square[rowCount, columnCount];
        
        for (var i = 0; i < rowCount; i++)
        {
            for (var j = 0; j < columnCount; j++)
            {
                var height = input[i][j];
                var neighbours = new List<Position>();
                // Add left, top, right, bottom neighbours - don't worry about whether they can be visited or not
                if (j > 0) neighbours.Add(new Position(i, j - 1));
                if (i > 0) neighbours.Add(new Position(i - 1, j));
                if (j < columnCount - 1) neighbours.Add(new Position(i, j + 1));
                if (i < rowCount - 1) neighbours.Add(new Position(i + 1, j));

                squares[i, j] = new Square(new Position(i, j), neighbours, false, height);
            }
        }

        return new Map(squares);
    }
}

public readonly record struct Position(int Row, int Column);

public readonly record struct Square(Position Position, List<Position> Neighbours, bool Visited, int Height);