namespace aoc2023.day15.domain
{
    public class Input
    {
        public List<string> InitialisationSequenceSteps { get; init; }

        public Input(IEnumerable<string> initialisationSequenceSteps)
        {
            InitialisationSequenceSteps = initialisationSequenceSteps.ToList();
        }
    }
}