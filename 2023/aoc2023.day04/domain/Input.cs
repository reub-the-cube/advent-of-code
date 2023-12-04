namespace aoc2023.day04.domain
{
    public class Input
    {
        public List<Scratchcard> Scratchcards { get; init; }

        public Input(List<Scratchcard> scratchcards)
        {
            Scratchcards = scratchcards;
        }
    }
}