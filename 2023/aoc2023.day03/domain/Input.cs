namespace aoc2023.day03.domain
{
    public class Input
    {
        public List<EnginePart> EngineParts { get; init; }

        public Input(List<EnginePart> engineParts)
        {
            EngineParts = engineParts;
        }
    }
}