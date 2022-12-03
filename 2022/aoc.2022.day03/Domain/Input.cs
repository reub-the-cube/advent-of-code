using System;

namespace aoc._2022.day03.domain
{
    public class Input
    {
        public List<Rucksack> Rucksacks { get; set; }

        public Input(List<Rucksack> rucksacks)
        {
            Rucksacks = rucksacks;
        }
    }
}