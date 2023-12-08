namespace aoc2023.day08.domain
{
    public class Input
    {
        public Dictionary<string, Node> NodeNetwork { get; init; }
        public char[] NodeSelectorSequence { get; init; }

        public Input(Dictionary<string, Node> nodeNetwork, char[] nodeSelectorSequence)
        {
            NodeNetwork = nodeNetwork;
            NodeSelectorSequence = nodeSelectorSequence;
        }
    }
}