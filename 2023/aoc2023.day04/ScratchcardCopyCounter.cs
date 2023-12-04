using aoc2023.day04.domain;

namespace aoc2023.day04
{
    public class ScratchcardCopyCounter
    {
        private readonly Dictionary<int, int> NumberOfCopiesCounter = new();

        public ScratchcardCopyCounter(List<int> scratchcardIds)
        {
            NumberOfCopiesCounter = scratchcardIds.ToDictionary(k => k, v => 1);
        }

        public void AddCopies(Scratchcard scratchcard)
        {
            var numberOfMatchingNumbers = scratchcard.CardNumbers.Intersect(scratchcard.WinningNumbers).Count();

            for (int i = 1; i < numberOfMatchingNumbers + 1; i++)
            {
                NumberOfCopiesCounter[scratchcard.Id + i] += NumberOfCopiesCounter[scratchcard.Id];
            }
        }

        public int TotalNumberOfScratchcards()
        {
            return NumberOfCopiesCounter.Sum(k => k.Value);
        }
    }
}
