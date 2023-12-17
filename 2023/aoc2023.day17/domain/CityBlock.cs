namespace aoc2023.day17.domain
{
    public record CityBlock(Position Position, List<Position> Neighbours, int HeatLoss)
    {
    }
}
