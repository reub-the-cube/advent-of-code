namespace aoc2023.day07.domain
{
    public class Input
    {
        public List<(string Cards, int Bid)> Hands { get; init; }

        public Input(List<(string Cards, int Bid)> hands)
        {
            Hands = hands;
        }
    }
}