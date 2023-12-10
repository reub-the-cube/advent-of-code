namespace aoc2023.day10
{
    public class Tile
    {
        public readonly char PipeValue;
        private readonly char? pipeAbove;
        private readonly char? pipeRight;
        private readonly char? pipeBelow;
        private readonly char? pipeLeft;

        public Tile(char pipeValue, char? pipeAbove, char? pipeRight, char? pipeBelow, char? pipeLeft)
        {
            PipeValue = pipeValue;

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
            return IsConnectedToAbove(PipeValue, pipeAbove) ? 1 : 0;
        }

        private int NumberOfConnectionsRight()
        {
            return IsConnectedToRight(PipeValue, pipeRight) ? 1 : 0;
        }

        private int NumberOfConnectionsBelow()
        {
            return IsConnectedToBelow(PipeValue, pipeBelow) ? 1 : 0;
        }

        private int NumberOfConnectionsLeft()
        {
            return IsConnectedToLeft(PipeValue, pipeLeft) ? 1 : 0;
        }

        internal static bool IsConnectedToAbove(char pipeValue, char? pipeAbove)
        {
            return IsConnectedFromBelow(pipeValue) && IsConnectedFromAbove(pipeAbove);
        }

        internal static bool IsConnectedToRight(char pipeValue, char? pipeRight)
        {
            return IsConnectedFromLeft(pipeValue) && IsConnectedFromRight(pipeRight);
        }

        internal static bool IsConnectedToBelow(char pipeValue, char? pipeBelow)
        {
            return IsConnectedFromAbove(pipeValue) && IsConnectedFromBelow(pipeBelow);
        }

        internal static bool IsConnectedToLeft(char pipeValue, char? pipeLeft)
        {
            return IsConnectedFromRight(pipeValue) && IsConnectedFromLeft(pipeLeft);
        }

        private static bool IsConnectedFromAbove(char? pipe)
        {
            return IsConnected(pipe, new char[] { 'S', '7', '|', 'F' });
        }

        private static bool IsConnectedFromRight(char? pipe)
        {
            return IsConnected(pipe, new char[] { 'S', 'J', '-', '7' });
        }

        private static bool IsConnectedFromBelow(char? pipe)
        {
            return IsConnected(pipe, new char[] { 'S', 'J', '|', 'L' });
        }

        private static bool IsConnectedFromLeft(char? pipe)
        {
            return IsConnected(pipe, new char[] { 'S', 'L', '-', 'F' });
        }

        private static bool IsConnected(char? adjacentPipe, char[] possibleConnections)
        {
            return Array.IndexOf(possibleConnections, adjacentPipe) > -1;
        }
    }
}
