namespace aoc2022.day16.domain
{
    public class TunnelNetwork
    {
        private readonly Dictionary<string, List<string>> ValveTunnels;

        public TunnelNetwork(Dictionary<string, List<string>> valveTunnels)
        {
            ValveTunnels = valveTunnels;
        }

        public int GetShortestPath(string from, string to)
        {
            if (from == to) return 0;

            var visitedValves = new HashSet<string>() { from };
            var numberOfSteps = 0;
            var reachedDestination = false;
            var nodesToInspect = new List<string>() { from };
            var nextNodes = new List<string>();

            while (!reachedDestination)
            {
                foreach (var nodeToInspect in nodesToInspect)
                {
                    foreach (var neighbour in ValveTunnels[nodeToInspect])
                    {
                        visitedValves.Add(neighbour);
                        nextNodes.Add(neighbour);
                        if (neighbour == to)
                        {
                            reachedDestination = true;
                            break;
                        }
                    }

                    if (reachedDestination) break;
                }
                numberOfSteps++;

                nodesToInspect = nextNodes.ToList();
                nextNodes.Clear();
            }

            return numberOfSteps;
        }
    }
}
