namespace aoc2023.day13
{
    public class Pattern
    {
        private readonly List<string> _pattern = new();
        private bool _checkForSmudges = false;
        private bool _smudgeFound = false;

        public Pattern(List<string> pattern)
        {
            _pattern = pattern;
        }

        public int NumberOfLinesAboveReflection(bool checkForSmudges)
        {
            _checkForSmudges = checkForSmudges;

            var mirroredRowIndex = FindMirroredRowIndex();
            return mirroredRowIndex;
        }

        public int NumberOfLinesAboveReflection()
        {
            return NumberOfLinesAboveReflection(false);
        }

        public int NumberOfLinesLeftOfReflection(bool checkForSmudges)
        {
            var transposedPattern = TransposePattern();
            var transpose = new Pattern(transposedPattern);
            return transpose.NumberOfLinesAboveReflection(checkForSmudges);
        }

        public int NumberOfLinesLeftOfReflection()
        {
            return NumberOfLinesLeftOfReflection(false);
        }

        public long SummarizeScore()
        {
            return SummarizeScore(false);
        }

        public long SummarizeScore(bool checkForSmudges)
        {
            long score;

            var numberOfLinesAboveReflection = NumberOfLinesAboveReflection(checkForSmudges);
            if (numberOfLinesAboveReflection == -1)
            {
                score = NumberOfLinesLeftOfReflection(checkForSmudges);
            }
            else
            {
                score = numberOfLinesAboveReflection * 100;
            }

            return score;
        }

        private List<string> TransposePattern()
        {
            var result = _pattern
                .SelectMany(inner => inner.Select((item, index) => new { item, index }))
                .GroupBy(i => i.index, i => i.item)
                .Select(g => string.Join(string.Empty, g))
                .ToList();

            return result;
        }

        private int FindMirroredRowIndex()
        {
            var adjacentRowIndex = 0;
            var fullyMirrored = false;
            var checkForSmudges = _checkForSmudges;

            while (!fullyMirrored && adjacentRowIndex > -1)
            {
                adjacentRowIndex = FindNextAdjacentRowIndex(adjacentRowIndex);
                if (adjacentRowIndex > -1)
                {
                    string? preSmudgeRowOne = _pattern[adjacentRowIndex - 1];
                    string? preSmudgeRowTwo = _pattern[adjacentRowIndex];
                    var indexOfDifference = IndexOfDifference(preSmudgeRowOne, preSmudgeRowTwo);
                    if (indexOfDifference > -1)
                    {
                        var newPattern = preSmudgeRowOne[..(indexOfDifference)] + "." + preSmudgeRowOne[(indexOfDifference + 1)..];
                        _pattern[adjacentRowIndex - 1] = newPattern;
                        _pattern[adjacentRowIndex] = newPattern;
                    }
                    fullyMirrored = IsFullyMirroredFromIndex(adjacentRowIndex);
                    if (!fullyMirrored || (checkForSmudges && !_smudgeFound))
                    {
                        _pattern[adjacentRowIndex - 1] = preSmudgeRowOne;
                        _pattern[adjacentRowIndex] = preSmudgeRowTwo;
                        _checkForSmudges = checkForSmudges;
                        fullyMirrored = false;
                        _smudgeFound = false;
                    }
                }
            }

            if (fullyMirrored && checkForSmudges && !_smudgeFound)
            {
                adjacentRowIndex = -1;
            }

            return adjacentRowIndex;
        }

        private int FindNextAdjacentRowIndex(int startIndex)
        {
            var matchingIndex = -1;

            for (int i = startIndex; i < _pattern.Count - 1; i++)
            {
                if (IsAdjacentRowMatching(_pattern[i], _pattern[i + 1]))
                {
                    matchingIndex = i + 1;
                    break;
                }
            }

            return matchingIndex;
        }

        private bool IsAdjacentRowMatching(string first, string second)
        {
            bool isMatch = first == second;
            if (!isMatch && _checkForSmudges)
            {
                isMatch = IndexOfDifference(first, second) > -1;
                if (isMatch) { _checkForSmudges = false; _smudgeFound = true; }
            }

            return isMatch;
        }

        private static int IndexOfDifference(string first, string second)
        {
            int differenceIndex = -1;

            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] != second[i])
                {
                    differenceIndex = i;
                    break;
                }
            }

            if (first[(differenceIndex + 1)..] != second[(differenceIndex + 1)..])
            {
                differenceIndex = -1;
            }

            return differenceIndex;
        }

        private bool IsFullyMirroredFromIndex(int adjacentRowIndex)
        {
            if (adjacentRowIndex < 0) return false;

            var aboveIndex = adjacentRowIndex - 2;
            var belowIndex = adjacentRowIndex + 1;
            var isFullyMirrored = true;

            while (aboveIndex >= 0 && belowIndex < _pattern.Count && isFullyMirrored)
            {
                if (!IsAdjacentRowMatching(_pattern[aboveIndex], _pattern[belowIndex]))
                {
                    isFullyMirrored = false;
                }
                aboveIndex--;
                belowIndex++;
            }

            return isFullyMirrored;
        }
    }
}