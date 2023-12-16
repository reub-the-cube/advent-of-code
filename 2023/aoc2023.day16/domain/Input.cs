namespace aoc2023.day16.domain
{
    public class Input
    {
        public List<string> ContraptionLayout { get; init; } = new List<string>();

        public Input(List<string> contraptionLayout)
        {
            ContraptionLayout = contraptionLayout.ToList();
        }
    }
}