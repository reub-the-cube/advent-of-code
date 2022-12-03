using aoc._2022.day03.Domain;

namespace aoc._2022.day03.domain
{
    public readonly record struct Rucksack(string CompartmentOne, string CompartmentTwo)
    {
        public string AllItems => $"{CompartmentOne}{CompartmentTwo}";
        public char CommonItem => CompartmentChecker.FindFirstCommonItem(new string[] { CompartmentOne, CompartmentTwo });
    }
}