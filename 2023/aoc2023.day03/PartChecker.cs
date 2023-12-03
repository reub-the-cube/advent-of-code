using aoc2023.day03.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2023.day03
{
    public static class PartChecker
    {
        public static bool IsPartAdjacentToASymbol(EnginePart partBeingChecked, List<EnginePart> partsToCheckAgainst)
        {
            if (partBeingChecked.PartType == EnginePartType.Period || partBeingChecked.PartType == EnginePartType.Symbol) {
                return false;
            }

            var adjacentParts = partsToCheckAgainst
                .Where(p => p.PartType == EnginePartType.Symbol)
                .Where(p => p != partBeingChecked)
                .Where(p => IsAdjacent(partBeingChecked, p));

            return adjacentParts.Any();
        }

        public static int GetGearRatio(EnginePart partBeingChecked, List<EnginePart> partsToCheckAgainst)
        {

            if (partBeingChecked.PartType == EnginePartType.Symbol && partBeingChecked.PartValue == "*")
            {
                var adjacentParts = partsToCheckAgainst
                    .Where(p => p.PartType == EnginePartType.Number)
                    .Where(p => p != partBeingChecked)
                    .Where(p => IsAdjacent(partBeingChecked, p))
                    .ToList();

                if (adjacentParts.Count == 2)
                {
                    return int.Parse(adjacentParts[0].PartValue) * int.Parse(adjacentParts[1].PartValue);
                }
            }

            return 0;
        }

        private static bool IsAdjacent(EnginePart partBeingChecked, EnginePart partToCheckAgainst)
        {
            return IsAdjacentAbove(partBeingChecked, partToCheckAgainst) ||
                IsAdjacentSameRow(partBeingChecked, partToCheckAgainst) ||
                IsAdjacentBelow(partBeingChecked, partToCheckAgainst);
        }

        private static bool IsAdjacentAbove(EnginePart partBeingChecked, EnginePart partToCheckAgainst)
        {
            return partToCheckAgainst.RowIndex == partBeingChecked.RowIndex - 1 &&
                partToCheckAgainst.StartIndex <= partBeingChecked.EndIndex + 1 &&
                partToCheckAgainst.EndIndex >= partBeingChecked.StartIndex - 1;
        }

        private static bool IsAdjacentSameRow(EnginePart partBeingChecked, EnginePart partToCheckAgainst)
        {
            return partToCheckAgainst.RowIndex == partBeingChecked.RowIndex &&
                partToCheckAgainst.StartIndex <= partBeingChecked.EndIndex + 1 &&
                partToCheckAgainst.EndIndex >= partBeingChecked.StartIndex - 1;
        }

        private static bool IsAdjacentBelow(EnginePart partBeingChecked, EnginePart partToCheckAgainst)
        {
            return partToCheckAgainst.RowIndex == partBeingChecked.RowIndex + 1 &&
                partToCheckAgainst.StartIndex <= partBeingChecked.EndIndex + 1 &&
                partToCheckAgainst.EndIndex >= partBeingChecked.StartIndex - 1;
        }
    }
}
