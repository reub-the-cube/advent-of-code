namespace aoc2023.day07
{
    public class CamelCardsGame
    {
        private readonly IHandScoring _handScoring;
        private readonly Dictionary<string, Hand> Hands = new();
        private readonly Dictionary<string, int> Bids = new();
        private readonly Dictionary<string, int> Ranks = new();

        public CamelCardsGame(IHandScoring handScoring)
        {
            _handScoring = handScoring;
        }

        public void AddHand(string handId, int bid)
        {
            Hands.Add(handId, CreateNewHand(handId));
            Bids.Add(handId, bid);
            Ranks.Add(handId, -1);

            RankHands();
        }

        public long CalculateTotalWinnings()
        {
            var totalWinnings = Hands.Aggregate((long)0, (cumulativeValue, h) => cumulativeValue + (Bids[h.Key] * Ranks[h.Key]));
            return totalWinnings;
        }

        private void RankHands()
        {
            var orderedHands = Hands.OrderBy(x => x.Value.Strength).ToList();

            for (int i = 0; i < orderedHands.Count; i++)
            {
                Ranks[orderedHands[i].Key] = i + 1;
            }
        }

        private Hand CreateNewHand(string handId)
        {
            var handType = _handScoring.GetHandType(handId);
            var strength = GetHandStrength(handType, handId);

            return new Hand(strength, handType);
        }

        private long GetHandStrength(HandType handType, string handId)
        {
            /* 11-digit number where:
             * - first digit is the hand type strength (1-7)
             * - next two digits are the first card strength
             * - ...
             * - last two digits are the fifth cards strength
             */

            var handStrength = $"{GetHandTypeStrength(handType)}" +
                    $"{_handScoring.GetCardStrength(handId[0])}" +
                    $"{_handScoring.GetCardStrength(handId[1])}" +
                    $"{_handScoring.GetCardStrength(handId[2])}" +
                    $"{_handScoring.GetCardStrength(handId[3])}" +
                    $"{_handScoring.GetCardStrength(handId[4])}";
            return long.Parse(handStrength);
        }

        private static string GetHandTypeStrength(HandType handType) => $"{(int)handType}";
    }

    public record Hand(long Strength, HandType HandType)
    {
    }

    public enum HandType
    {
        HighCard = 1,
        OnePair = 2,
        TwoPair = 3,
        ThreeOfAKind = 4,
        FullHouse = 5,
        FourOfAKind = 6,
        FiveOfAKind = 7
    }

}
