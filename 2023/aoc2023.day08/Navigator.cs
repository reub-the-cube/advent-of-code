using aoc2023.day08.domain;

namespace aoc2023.day08
{
    public class Navigator
    {
        private readonly Dictionary<string, Node> _network;

        public Navigator(Dictionary<string, Node> network)
        {
            _network = network;
        }

        public int GetSteps(string fromNode, string toNode, char[] nodeSelectorSequence)
        {
            int steps = 0;
            int stepsInSequence = nodeSelectorSequence.Length;
            string currentNode = fromNode;

            while (toNode != currentNode)
            {
                var nextNode = GetNextNode(_network[currentNode], nodeSelectorSequence[steps % stepsInSequence]);
                currentNode = nextNode;
                steps += 1;
            }

            return steps;
        }

        private static string GetNextNode(Node currentNode, char nextNodeSelector)
        {
            return nextNodeSelector switch
            {
                'L' => currentNode.NodeToTheLeft,
                'R' => currentNode.NodeToTheRight,
                _ => throw new NotImplementedException()
            };
        }
    }
}
