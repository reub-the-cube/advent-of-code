namespace aoc2022.day09.domain
{
    public readonly record struct Knot(int X, int Y)
    {
        public Knot Follow(int x, int y)
        {
            var xDiff = x - X;
            var yDiff = y - Y;

            if (xDiff != 0 && yDiff != 0)
            {
                return MoveDiagonally(xDiff, yDiff);
            }
            if (yDiff != 0)
            {
                return MoveVertically(y);
            }
            if (xDiff != 0)
            {
                return MoveHorizontally(x);
            }

            return new(X, Y);
        }

        public Knot Move(int xShift, int yShift) => new Knot(X + xShift, Y + yShift);

        private Knot MoveVertically(int y)
        {
            if (y == Y + 2)
            {
                return new(X, Y + 1);
            }

            if (y == Y - 2)
            {
                return new(X, Y - 1);
            }

            if ((y < Y + 2) && (y > Y - 2))
            {
                return new(X, Y);
            }

            throw new ArgumentOutOfRangeException(nameof(y), "y position to follow is not in range");
        }

        private Knot MoveHorizontally(int x)
        {
            if (x == X + 2)
            {
                return new(X + 1, Y);
            }

            if (x == X - 2)
            {
                return new(X - 1, Y);
            }

            if ((x < X + 2) && (x > X - 2))
            {
                return new(X, Y);
            }

            throw new ArgumentOutOfRangeException(nameof(x), "x position to follow is not in range");
        }

        private Knot MoveDiagonally(int xDiff, int yDiff)
        {
            if ((xDiff == 2 && yDiff == 1) || (xDiff == 1 && yDiff == 2) || (xDiff == 2 && yDiff == 2))
            {
                return new(X + 1, Y + 1);
            }

            if ((xDiff == 2 && yDiff == -1) || (xDiff == 1 && yDiff == -2) || (xDiff == 2 && yDiff == -2))
            {
                return new(X + 1, Y - 1);
            }

            if ((xDiff == -1 && yDiff == 2) || (xDiff == -2 && yDiff == 1) || (xDiff == -2 && yDiff == 2))
            {
                return new(X - 1, Y + 1);
            }

            if ((xDiff == -1 && yDiff == -2) || (xDiff == -2 && yDiff == -1) || (xDiff == -2 && yDiff == -2))
            {
                return new(X - 1, Y - 1);
            }

            if (Math.Abs(xDiff) == 1 && Math.Abs(yDiff) == 1)
            {
                return new(X, Y);
            }

            throw new ArgumentOutOfRangeException($"x position (diff = {xDiff}) and y position (diff = {yDiff}) to follow is not in range");
        }
    }
}
