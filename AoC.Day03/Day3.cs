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
        var numberOfSetBitsByPosition = MostCommonBitFlags(parsedInput.Select(s => s.BinaryNumber).ToArray(), numberOfBits);
        
        var gammaRate = GetGammaRate(numberOfSetBitsByPosition);
        var epsilonRate = GetBitwiseComplement(gammaRate, numberOfBits);

        var oxygenRating = GetOxygenGeneratorRating(parsedInput.Select(s => s.BinaryNumber).ToArray(), numberOfBits);
        var co2Rating = GetCO2ScrubberRating(parsedInput.Select(s => s.BinaryNumber).ToArray(), numberOfBits);

        return (Convert.ToInt32(gammaRate * epsilonRate), Convert.ToInt32(oxygenRating * co2Rating));
    }

    public static IEnumerable<bool> MostCommonBitFlags(uint[] parsedInput, int numberOfBits)
    {
        var bitValueCountByPosition = new int[numberOfBits];

        for (var j = 0; j < numberOfBits; j++)
        {
            bitValueCountByPosition[numberOfBits - j - 1] = GetSetBitCountByPosition(parsedInput, j);
        }

        var thresholdCount = (double)parsedInput.Length / 2;
        return bitValueCountByPosition.Select(count => IsCountAboveThreshold(count, thresholdCount, null));
    }

    private static int GetSetBitCountByPosition(uint[] parsedInput, int shiftRightCount)
    {
        int setBitCount = 0;

        foreach (var i in parsedInput)
        {
            var bitValue = (i >> shiftRightCount) & 1;
            switch (bitValue)
            {
                case 1:
                    setBitCount += 1;
                    break;
            }
        }

        return setBitCount;
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
        return ReduceRatingsForBitFlagsAgainstMostCommonFlagAtEachPosition(ints, numberOfBits, true);
    }


    public static uint GetCO2ScrubberRating(uint[] ints, int numberOfBits)
    {
        return ReduceRatingsForBitFlagsAgainstMostCommonFlagAtEachPosition(ints, numberOfBits, false);
    }

    private static uint ReduceRatingsForBitFlagsAgainstMostCommonFlagAtEachPosition(uint[] values, int numberOfBits, bool retainMostCommonlyOccurringBitFlag)
    {
        var remainingNumbers = new KeyValuePair<uint, int>[values.Length];
        for (int i = 0; i < values.Length; i++)
        {
            remainingNumbers[i] = new KeyValuePair<uint, int>(values[i], i);
        }

        while (remainingNumbers.Length > 1)
        {
            var setBitCount = GetSetBitCountByPosition(remainingNumbers.Select(k => k.Key).ToArray(), numberOfBits - 1);
            var setBitIsMostCommon = IsCountAboveThreshold(setBitCount, (double)remainingNumbers.Length / 2, true);

            remainingNumbers = remainingNumbers
                .Where(i =>
                {
                    // Get first value by shifting right
                    var bitValue = (i.Key >> numberOfBits - 1) & 1;
                    // Keep the item if its first value matches the most common bit value
                    return retainMostCommonlyOccurringBitFlag ? Convert.ToBoolean(bitValue) == setBitIsMostCommon : Convert.ToBoolean(bitValue) != setBitIsMostCommon;
                })
                .Select(i =>
                {
                    uint newValue = i.Key;

                    // Reduce number of bits by 1. Unset bit if set.
                    if (setBitIsMostCommon)
                    {
                        uint mask = Convert.ToUInt32(1 << numberOfBits - 1);
                        newValue &= ~mask;
                    }

                    return new KeyValuePair<uint, int>(newValue, i.Value);
                })
                .ToArray();

            numberOfBits -= 1;
        }

        if (remainingNumbers.Length == 0)
        {
            throw new Exception("D'oh, what's happened here?");
        }

        return values[remainingNumbers[0].Value];
    }
}
