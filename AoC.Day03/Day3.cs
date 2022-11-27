using AoC.Core;
using AoC.Day03.Models;

namespace AoC.Day03;
public class Day3 : IDay
{
    private readonly IParser<Input> _parser;

    public Day3(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (int AnswerOne, int AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);
        var numberOfBits = input?.FirstOrDefault()?.Length ?? 0;
        var numberOfSetBitsByPosition = CountSetBitsByPosition(parsedInput, numberOfBits);



        throw new NotImplementedException();
    }

    public static int[] CountSetBitsByPosition(Input[] parsedInput, int numberOfBits)
    {
        var bitValueCountByPosition = new int[numberOfBits];

        for (int i = 0; i < parsedInput?.Length; i++)
        {
            for (int j = 0; j < numberOfBits; j++)
            {
                var bitValue = ((parsedInput[i].BinaryNumber >> j) & 1);
                switch (bitValue)
                {
                    case 1:
                        bitValueCountByPosition[numberOfBits - j - 1] += 1;
                        break;
                    default:
                        break;
                }
            }
        }

        return bitValueCountByPosition;
    }

    public static uint GetGammaRate(int[] numberOfSetBitsByPosition, int threshold)
    {
        uint gammaRate;
        if (numberOfSetBitsByPosition[0] > threshold)
        {
            gammaRate = 0b_1;
        }
        else if (numberOfSetBitsByPosition[0] < threshold)
        {
            gammaRate = 0b_0;
        }
        else
        {
            throw new Exception("Number of bits match. What do we do?");
        }

        foreach (var item in numberOfSetBitsByPosition.Skip(1))
        {
            if (item > threshold)
            {
                gammaRate = (gammaRate << 1) & 1;

            }
            else if (item < threshold)
            {
                gammaRate <<= 1;
            }
            else
            {
                throw new Exception("Number of bits match. What do we do?");
            }
        }

        return gammaRate;
    }
}
