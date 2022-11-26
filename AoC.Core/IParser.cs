namespace AoC.Core
{
    public interface IParser<T>
    {
        T[] ParseInput(string[] input);
    }
}
