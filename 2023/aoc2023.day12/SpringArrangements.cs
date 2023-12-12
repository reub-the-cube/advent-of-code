namespace aoc2023.day12
{
    public class SpringArrangements
    {
        public static List<string> GetPossibleArrangements(string springConditions, List<int> contiguousGroups)
        {
            var allPossibleArrangements = ReplaceUnknowns(springConditions);
            var possibleArrangements = CompareToContiguousGroups(allPossibleArrangements, contiguousGroups);

            return possibleArrangements;
        }

        private static List<string> ReplaceUnknowns(string springConditions)
        {
            if (!springConditions.Contains('?')) return new List<string> { springConditions };

            var possibleArrangements = new List<string>();
            if (springConditions.Contains('?'))
            {
                // replace first ? with a . and a #
                var indexOfFirstUnknown = springConditions.IndexOf('?');
                var operationalPath = $"{springConditions[..indexOfFirstUnknown]}#{springConditions[(indexOfFirstUnknown + 1)..]}";
                var brokenPath = $"{springConditions[..indexOfFirstUnknown]}.{springConditions[(indexOfFirstUnknown + 1)..]}";

                possibleArrangements.AddRange(ReplaceUnknowns(operationalPath));
                possibleArrangements.AddRange(ReplaceUnknowns(brokenPath));
            }

            return possibleArrangements;
        } 

        private static List<string> CompareToContiguousGroups(List<string> arrangements, List<int> contiguousGroups)
        {
            return arrangements.Where(a => IsArrangementValidForContiguousGroups(a, '.', contiguousGroups)).ToList();
        }

        private static bool IsArrangementValidForContiguousGroups(string arrangement, char charactrerToSplitBy, List<int> contiguousGroups)
        {
            var splitArrangement = arrangement.Split(charactrerToSplitBy, StringSplitOptions.RemoveEmptyEntries);
            var contiguousCountForArrangement = splitArrangement.Select(a => a.Length).ToList();

            return Enumerable.SequenceEqual(contiguousCountForArrangement, contiguousGroups);
        }
    }
}
