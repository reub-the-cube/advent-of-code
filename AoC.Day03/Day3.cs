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
        var numberOfSetBitsByPosition = CountSetBitsByPosition(parsedInput, numberOfBits);
        
        var gammaRate = GetGammaRate(numberOfSetBitsByPosition, input?.Length / 2 ?? 0);
        var epsilonRate = GetBitwiseComplement(gammaRate, numberOfBits); // Does this work if first character is 0?

        return (Convert.ToInt32(gammaRate * epsilonRate), 0);
    }

    public static int[] CountSetBitsByPosition(Input[] parsedInput, int numberOfBits)
    {
        var bitValueCountByPosition = new int[numberOfBits];

        for (var i = 0; i < parsedInput?.Length; i++)
        {
            for (var j = 0; j < numberOfBits; j++)
            {
                var bitValue = ((parsedInput[i].BinaryNumber >> j) & 1);
                switch (bitValue)
                {
                    case 1:
                        bitValueCountByPosition[numberOfBits - j - 1] += 1;
                        break;
                }
            }
        }

        return bitValueCountByPosition;
    }

    public static uint GetGammaRate(IEnumerable<int> numberOfSetBitsByPosition, int threshold)
    {
        uint gammaRate = 0b_0;
        const uint setBit = 0b_1;

        foreach (var item in numberOfSetBitsByPosition)
        {
            if (item == threshold)
            {
                throw new Exception("Number of set bits match number of unset bits. What do we do?");
            }
            
            // Shift left
            gammaRate <<= 1;

            if (item > threshold)
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
}
