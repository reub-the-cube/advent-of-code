namespace aoc2023.day10
{
    public class Tile
    {
        private readonly char? pipeAbove;
        private readonly char? pipeRight;
        private readonly char? pipeBelow;
        private readonly char? pipeLeft;

        public Tile(char? pipeAbove, char? pipeRight, char? pipeBelow, char? pipeLeft)
        {
            this.pipeAbove = pipeAbove;
            this.pipeRight = pipeRight;
            this.pipeBelow = pipeBelow;
            this.pipeLeft = pipeLeft;
        }

        public int GetNumberOfConnectedNeighbours()
        {
            return NumberOfConnectionsAbove() + NumberOfConnectionsRight() + NumberOfConnectionsBelow() + NumberOfConnectionsLeft();
        }

        private int NumberOfConnectionsAbove()
        {
            return IsConnected(pipeAbove, new char[] {'7', '|', 'F'});
        }

        private int NumberOfConnectionsRight()
        {
            return IsConnected(pipeRight, new char[] { 'J', '-', '7' });
        }

        private int NumberOfConnectionsBelow()
        {
            return IsConnected(pipeBelow, new char[] { 'J', '|', 'L' });
        }

        private int NumberOfConnectionsLeft()
        {
            return IsConnected(pipeLeft, new char[] { 'L', '-', 'F' });
        }

        private static int IsConnected(char? adjacentPipe, char[] possibleConnections)
        {
            return Array.IndexOf(possibleConnections, adjacentPipe) > -1 ? 1 : 0;
        }
    }
}
