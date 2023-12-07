namespace aoc2023.day07
{
    public class JokerScoringRules : IHandScoring
    {
        public string GetCardStrength(char cardValue)
        {
            var strength = cardValue switch
            {
                'J' => 1,
                '2' => 2,
                '3' => 3,
                '4' => 4,
                '5' => 5,
                '6' => 6,
                '7' => 7,
                '8' => 8,
                '9' => 9,
                'T' => 10,
                'Q' => 11,
                'K' => 12,
                'A' => 13,
                _ => throw new NotImplementedException($"Card strength for card value '{cardValue}' cannot be calculated.")
            };

            return $"{strength}".PadLeft(2, '0');
        }

        public HandType GetHandType(string handId)
        {
            try
            {
                // With a joker, it can be any card to make the best hand.
                // The best hand will be jokers replacing the most frequently occuring card
                var groupedByLabel = handId.Where(c => c != 'J').GroupBy(c => c);

                var highestLabelCount = groupedByLabel.OrderByDescending(c => c.Count());
                var bestHand = highestLabelCount.Any() ? handId.Replace('J', highestLabelCount.First().Key) : handId;

                var bestHandGroupedByLabel = bestHand.GroupBy(c => c);
                var bestHandHighestLabelCount = bestHandGroupedByLabel.Max(c => c.Count());

                switch (bestHandGroupedByLabel.Count())
                {
                    case 5:
                        return HandType.HighCard;
                    case 4:
                        return HandType.OnePair;
                    case 3:
                        if (bestHandHighestLabelCount == 3)
                        {
                            return HandType.ThreeOfAKind;
                        }
                        else
                        {
                            return HandType.TwoPair;
                        }
                    case 2:
                        if (bestHandHighestLabelCount == 4)
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
            catch (Exception)
            {
                throw new Exception($"hand type for id '{handId}' could not be calculated.");
            }
        }
    }
}
