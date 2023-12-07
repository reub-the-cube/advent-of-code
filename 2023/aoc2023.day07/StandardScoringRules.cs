namespace aoc2023.day07
{
    public class StandardScoringRules : IHandScoring
    {
        public string GetCardStrength(char cardValue)
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

        public HandType GetHandType(string handId)
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
    }
}
