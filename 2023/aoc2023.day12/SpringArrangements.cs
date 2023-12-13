using aoc2023.day12.domain;

namespace aoc2023.day12
{
    public class SpringArrangements
    {
        private Dictionary<(string Arrangement, string ContiguousGroups), bool> _arrangementValidityLookup = new();
        private int _validArrangementCount = 0;

        public int GetPossibleArrangements(string springConditions, List<int> contiguousGroups)
        {
            _validArrangementCount = 0;
            SplitIntoContiguousGroups(springConditions, contiguousGroups);

            return _validArrangementCount;
        }

        private void SplitIntoContiguousGroups(string arrangement, List<int> contiguousGroups)
        {
            if (_arrangementValidityLookup.ContainsKey((arrangement, string.Join(',', contiguousGroups))))
            {
                if (_arrangementValidityLookup[(arrangement, string.Join(',', contiguousGroups))])
                {
                    _validArrangementCount++;
                }
                return;
            }

            var splitArrangement = arrangement.Split('.', StringSplitOptions.RemoveEmptyEntries);
            if (splitArrangement.Length == 0 || contiguousGroups.Count == 0)
            {
                _arrangementValidityLookup.TryAdd((arrangement, string.Join(',', contiguousGroups)), false);
                return;
            }

            // ?.#.###              --->    ?       #       ###             |   1   1   3
            // #??.###              --->    #??     ###                     |   1   1   3
            // #.??.###             --->    #       ??      ###             |   1   1   3
            // .??..??...?##        --->    ??      ??      ?##             |   1   1   3
            // ????.######..#####.  --->    ????    ######  #####           |   1   6   5
            // ?###????????         --->    same                            |   3   2   1

            // Trim from start where springs are operational only
            var splitArrangementIndex = 0;
            var groupCountIndex = 0;
            while (!splitArrangement[splitArrangementIndex].Contains('?'))
            {
                if (groupCountIndex > contiguousGroups.Count - 1)
                {
                    _arrangementValidityLookup.TryAdd((arrangement, string.Join(',', contiguousGroups)), false);
                    return;
                }
                else if (splitArrangement[splitArrangementIndex].Length == contiguousGroups[groupCountIndex])
                {
                    splitArrangementIndex++;
                    groupCountIndex++;
                }
                else
                {
                    _arrangementValidityLookup.TryAdd((arrangement, string.Join(',', contiguousGroups)), false);
                    return;
                }

                if (splitArrangementIndex == splitArrangement.Length)
                {
                    if (splitArrangement.Length == contiguousGroups.Count)
                    {
                        _arrangementValidityLookup.TryAdd((arrangement, string.Join(',', contiguousGroups)), true);
                        _validArrangementCount++;
                    }
                    else
                    {
                        _arrangementValidityLookup.TryAdd((arrangement, string.Join(',', contiguousGroups)), false);
                    }
                    return;
                }
            }
            splitArrangement = splitArrangement.Skip(splitArrangementIndex).ToArray();
            var remainingContiguousGroups = contiguousGroups.Skip(groupCountIndex).ToList();

            // Trim from end where springs are operational only
            splitArrangementIndex = splitArrangement.Length - 1;
            groupCountIndex = remainingContiguousGroups.Count - 1;
            while (!splitArrangement[splitArrangementIndex].Contains('?'))
            {
                if (splitArrangement[splitArrangementIndex].Length == remainingContiguousGroups[groupCountIndex])
                {
                    splitArrangementIndex--;
                    groupCountIndex--;
                }
                else
                {
                    _arrangementValidityLookup.TryAdd((arrangement, string.Join(',', remainingContiguousGroups)), false);
                    return;
                }
            }
            splitArrangement = splitArrangement.Take(splitArrangementIndex + 1).ToArray();
            remainingContiguousGroups = remainingContiguousGroups.Take(groupCountIndex + 1).ToList();

            // Create possible strings from split arrangement
            var unknowns = string.Join('.', splitArrangement);
            ReplaceUnknowns(unknowns, remainingContiguousGroups);
        }

        private void ReplaceUnknowns(string springConditions, List<int> contiguousGroups)
        {
            if (contiguousGroups.Count == 0)
            {
                _validArrangementCount++;
            }
            else
            {
                ReplaceNextUnknown(springConditions, contiguousGroups, true);
            }
        }

        private void ReplaceNextUnknown(string springConditions, List<int> contiguousGroups, bool firstPass)
        {
            //if (!springConditions.Contains('?')) return new List<string> { springConditions };

            if (springConditions.Contains('.') && !firstPass)
            {
                SplitIntoContiguousGroups(springConditions, contiguousGroups);
                return;
            }

            if (!springConditions.Contains('?'))
            {
                // Must be all operational
                SplitIntoContiguousGroups(springConditions, contiguousGroups);
                return;
            }

            // replace first ? with a . and a #
            var indexOfFirstUnknown = springConditions.IndexOf('?');
            var operationalPath = $"{springConditions[..indexOfFirstUnknown]}#{springConditions[(indexOfFirstUnknown + 1)..]}";
            var brokenPath = $"{springConditions[..indexOfFirstUnknown]}.{springConditions[(indexOfFirstUnknown + 1)..]}";

            ReplaceNextUnknown(operationalPath, contiguousGroups, false);
            ReplaceNextUnknown(brokenPath, contiguousGroups, false);
        }

        public static SpringConditionsRecord Unfold(string springConditions, List<int> contiguousGroup)
        {
            var repeatedSpringConditions = Enumerable.Repeat(springConditions, 5);
            var unfoldedSpringConditions = string.Join('?', repeatedSpringConditions);

            var repeatedContiguousGroups = Enumerable.Repeat(contiguousGroup, 5);
            var unfoldedContiguousGroups = repeatedContiguousGroups.SelectMany(s => s).ToList();

            return new SpringConditionsRecord(unfoldedSpringConditions, unfoldedContiguousGroups);
        }
    }
}
