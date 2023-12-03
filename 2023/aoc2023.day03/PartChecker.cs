using aoc2023.day03.domain;

namespace aoc2023.day03
{
    public static class PartChecker
    {
        public static bool IsPartAdjacentToASymbol(EnginePart partBeingChecked, List<EnginePart> partsToCheckAgainst)
        {
            if (partBeingChecked.PartType == EnginePartType.Period || partBeingChecked.PartType == EnginePartType.Symbol) {
                return false;
            }

            var adjacentParts = GetAdjacentParts(partBeingChecked, partsToCheckAgainst, EnginePartType.Symbol);
            return adjacentParts.Any();
        }

        public static int GetGearRatio(EnginePart partBeingChecked, List<EnginePart> partsToCheckAgainst)
        {
            if (partBeingChecked.PartType == EnginePartType.Symbol && partBeingChecked.PartValue == "*")
            {
                var adjacentParts = GetAdjacentParts(partBeingChecked, partsToCheckAgainst, EnginePartType.Number);

                if (adjacentParts.Count == 2)
                {
                    return int.Parse(adjacentParts[0].PartValue) * int.Parse(adjacentParts[1].PartValue);
                }
            }

            return 0;
        }

        private static List<EnginePart> GetAdjacentParts(EnginePart partBeingChecked, List<EnginePart> partsToCheckAgainst, EnginePartType partTypeFilter)
        {
            return partsToCheckAgainst
                .Where(p => p.PartType == partTypeFilter)
                .Where(p => p != partBeingChecked)
                .Where(p => IsAdjacent(partBeingChecked, p))
                .ToList();
        }

        private static bool IsAdjacent(EnginePart partBeingChecked, EnginePart partToCheckAgainst)
        {
            return IsAdjacentVertically(partBeingChecked, partToCheckAgainst) &&
                IsAdjacentHorizontally(partBeingChecked, partToCheckAgainst);
        }

        private static bool IsAdjacentVertically(EnginePart partBeingChecked, EnginePart partToCheckAgainst)
        {
            return partToCheckAgainst.RowIndex <= partBeingChecked.RowIndex + 1 &&
                partToCheckAgainst.RowIndex >= partBeingChecked.RowIndex - 1;
        }

        private static bool IsAdjacentHorizontally(EnginePart partBeingChecked, EnginePart partToCheckAgainst)
        {
            return partToCheckAgainst.StartIndex <= partBeingChecked.EndIndex + 1 &&
                partToCheckAgainst.EndIndex >= partBeingChecked.StartIndex - 1;
        }
    }
}
