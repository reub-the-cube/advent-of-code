using aoc2023.day15.domain;

namespace aoc2023.day15
{
    public class FocusPower
    {
        public static long Calculate(int boxId, List<Lens> lenses)
        {
            return (boxId + 1) * CalculateLensFactor(lenses);
        }

        private static long CalculateLensFactor(List<Lens> lenses)
        {
            long aggregateFactor = 0;

            for (int i = 1; i < lenses.Count + 1; i++)
            {
                var lensMultiplier = i * lenses[i - 1].FocalLength;
                aggregateFactor += lensMultiplier;
            }

            return aggregateFactor;
        }
    }
}
