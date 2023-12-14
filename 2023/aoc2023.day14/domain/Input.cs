namespace aoc2023.day14.domain
{
    public class Input
    {
        public List<string> RockFormation { get; init; } = new List<string>();

        public Input(List<string> rockFormation)
        {
            RockFormation = rockFormation.ToList();
        }
    }
}