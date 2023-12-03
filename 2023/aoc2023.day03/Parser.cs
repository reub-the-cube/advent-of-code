using AoC.Core;
using aoc2023.day03.domain;

namespace aoc2023.day03
{
    public class Parser : IParser<Input>
    {
        public Input ParseInput(string[] input)
        {
            throw new NotImplementedException();
        }

        public static List<EnginePart> ParseRows(string[] inputRows)
        {
            var engineParts = new List<EnginePart>();

            for (int i = 0; i < inputRows.Length; i++)
            {
                engineParts.AddRange(ParseRow(inputRows[i], i));
            }
            
            return engineParts;
        }

        public static List<EnginePart> ParseRow(string inputRow)
        {
            return ParseRow(inputRow, 0);
        }

        private static List<EnginePart> ParseRow(string inputRow, int rowIndex)
        {
            var engineParts = new List<EnginePart>();

            var currentPartType = GetPartTypeFromSchematicCharacter(inputRow[0]);
            var currentPartStartIndex = 0;

            for (int i = 0; i < inputRow.Length; i++)
            {
                var partType = GetPartTypeFromSchematicCharacter(inputRow[i]);

                if (partType != currentPartType)
                {
                    engineParts.Add(new EnginePart(currentPartType, currentPartStartIndex, i - 1, rowIndex));

                    currentPartType = partType;
                    currentPartStartIndex = i;
                }
            }

            engineParts.Add(new EnginePart(currentPartType, currentPartStartIndex, inputRow.Length - 1, rowIndex));
            return engineParts;
        }

        private static EnginePartType GetPartTypeFromSchematicCharacter(char schematicCharacter)
        {
            if (char.IsDigit(schematicCharacter))
            {
                return EnginePartType.Number;
            }
            else if (schematicCharacter == '.')
            {
                return EnginePartType.Period;
            }
            else
            {
                return EnginePartType.Symbol;
            }
        }
    }
}
