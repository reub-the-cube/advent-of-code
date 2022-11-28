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
        if (input == null) throw new ArgumentNullException(nameof(input));
        
        var parsedInput = _parser.ParseInput(input);
        var numberOfBits = input?.FirstOrDefault()?.Length ?? 0;
        var numberOfSetBitsByPosition = MostCommonBitFlagByPosition(
            parsedInput.Select(s => s.BinaryNumber).ToArray(), 
            numberOfBits, 
            null);
        
        var gammaRate = GetGammaRate(numberOfSetBitsByPosition);
        var epsilonRate = GetBitwiseComplement(gammaRate, numberOfBits); // Does this work if first character is 0?

        return (Convert.ToInt32(gammaRate * epsilonRate), 0);
    }

    public static IEnumerable<bool> MostCommonBitFlagByPosition(uint[] parsedInput, int numberOfBits, bool? tieBreaker)
    {
        var bitValueCountByPosition = new int[numberOfBits];

        foreach (var i in parsedInput)
        {
            for (var j = 0; j < numberOfBits; j++)
            {
                var bitValue = (i >> j) & 1;
                switch (bitValue)
                {
                    case 1:
                        bitValueCountByPosition[numberOfBits - j - 1] += 1;
                        break;
                }
            }
        }

        var thresholdCount = (double)parsedInput.Length / 2;
        return bitValueCountByPosition.Select(count => IsCountAboveThreshold(count, thresholdCount, tieBreaker));
    }

    private static bool IsCountAboveThreshold(int count, double threshold, bool? tieBreaker)
    { 
        if (count > threshold)
        {
            return true;
        }

        if (count < threshold)
        {
            return false;
        }

        return tieBreaker ?? throw new Exception("Number of set bits match number of unset bits. What do we do?");
    }

    public static uint GetGammaRate(IEnumerable<bool> mostCommonBitByPosition)
    {
        uint gammaRate = 0b_0;
        const uint setBit = 0b_1;

        foreach (var item in mostCommonBitByPosition)
        {
            // Shift left
            gammaRate <<= 1;

            if (item)
            {
                gammaRate ^= setBit;
            }
        }

        return gammaRate;
    }

    public static uint GetBitwiseComplement(uint original, int numberOfBits)
    {
        var invertedString = Convert.ToString(original, 2)
            .Replace('1', '2')
            .Replace('0', '1')
            .Replace('2', '0')
            .PadLeft(numberOfBits, '1');

        return Convert.ToUInt32(invertedString, 2);
    }

    public static uint GetOxygenGeneratorRating(uint[] ints, int numberOfBits)
    {
        var mostCommonByPosition = MostCommonBitFlagByPosition(ints, numberOfBits, true);
        
        while (ints.Length > 1)
        {
            ints.Where(i =>
            {
                // First character is most common
                throw new NotImplementedException();
            });
            throw new Exception();
        }
        throw new NotImplementedException();
    }
}
