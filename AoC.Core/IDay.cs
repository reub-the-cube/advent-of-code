namespace AoC.Core;

public interface IDay
{
    void Initialise(string[] input);
    int ChallengeOne();
    int ChallengeTwo();
}