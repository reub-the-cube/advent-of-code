namespace aoc2023.day07
{
    public interface IHandScoring
    {
        HandType GetHandType(string handId);

        string GetCardStrength(char cardValue);
    }
}
