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
            return GetSteps(fromNode, new List<string> { toNode }, nodeSelectorSequence, 0).NumberOfSteps;
        }

        public int GetSteps(string fromNode, List<string> toNodes, char[] nodeSelectorSequence)
        {
            return GetSteps(fromNode, toNodes, nodeSelectorSequence, 0).NumberOfSteps;
        }

        private (int NumberOfSteps, string FinishingNode) GetSteps(string fromNode, List<string> toNodes, char[] nodeSelectorSequence, int startAt)
        {
            int steps = 0;
            int stepsInSequence = nodeSelectorSequence.Length;
            string currentNode = fromNode;

            while (!toNodes.Contains(currentNode) || (toNodes.Contains(currentNode) && steps == 0))
            {
                var nextNode = GetNextNode(_network[currentNode], nodeSelectorSequence[(startAt + steps) % stepsInSequence]);
                currentNode = nextNode;
                steps += 1;
            }

            return (steps, currentNode);
        }

        public List<(int NumberOfSteps, string FinishingNode)> GetStepsForMultipleReturnsToDestination(string fromNode, List<string> toNodes, char[] nodeSelectorSequence, int numberOfHits)
        {
            List<(int NumberOfSteps, string FinishingNode)> steps = new();
            var startSequenceAtIndex = 0;
            for (int i = 0; i < numberOfHits; i++)
            {
                steps.Add(GetSteps(fromNode, toNodes, nodeSelectorSequence, startSequenceAtIndex));
                fromNode = steps[i].FinishingNode;

                startSequenceAtIndex = steps.Sum(s => s.NumberOfSteps) % nodeSelectorSequence.Length;
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
