using System;

namespace aoc2023.day07
{
    public class CamelCardsGame
    {
        private readonly Dictionary<string, Hand> Hands = new();
        private readonly Dictionary<string, int> Bids = new();
        private readonly Dictionary<string, int> Ranks = new();

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

        private static Hand CreateNewHand(string handId)
        {
            var handType = GetHandType(handId);
            var strength = GetHandStrength(handType, handId);

            return new Hand(strength, handType);
        }

        private static HandType GetHandType(string handId)
        {
            var groupedByLabel = handId.GroupBy(c => c);
            var highestLabelCount = groupedByLabel.Max(c => c.Count());

            switch (groupedByLabel.Count())
            {
                case 5:
                    return HandType.HighCard;
                case 4:
                    return HandType.OnePair;
                case 3:
                    if (highestLabelCount == 3)
                    {
                        return HandType.ThreeOfAKind;
                    }
                    else
                    {
                        return HandType.TwoPair;
                    }
                case 2:
                    if (highestLabelCount == 4)
                    {
                        return HandType.FourOfAKind;
                    }
                    else
                    {
                        return HandType.FullHouse;
                    }
                case 1:
                    return HandType.FiveOfAKind;
            }

            throw new Exception($"Hand type could not be inferred for hand id '{handId}'.");
        }

        private static long GetHandStrength(HandType handType, string handId)
        {
            /* 11-digit number where:
             * - first digit is the hand type strength (1-7)
             * - next two digits are the first card strength
             * - ...
             * - last two digits are the fifth cards strenth
             */

            var handStrength = $"{GetHandTypeStrength(handType)}" +
                    $"{GetCardStrength(handId[0])}" +
                    $"{GetCardStrength(handId[1])}" +
                    $"{GetCardStrength(handId[2])}" +
                    $"{GetCardStrength(handId[3])}" +
                    $"{GetCardStrength(handId[4])}";
            return long.Parse(handStrength);
        }

        private static string GetHandTypeStrength(HandType handType) => $"{(int)handType}";

        private static string GetCardStrength(char cardValue)
        {
            var strength = cardValue switch
            {
                '2' => 1,
                '3' => 2,
                '4' => 3,
                '5' => 4,
                '6' => 5,
                '7' => 6,
                '8' => 7,
                '9' => 8,
                'T' => 9,
                'J' => 10,
                'Q' => 11,
                'K' => 12,
                'A' => 13,
                _ => throw new NotImplementedException($"Card strength for card value '{cardValue}' cannot be calculated.")
            };

            return $"{strength}".PadLeft(2, '0');
        }
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
