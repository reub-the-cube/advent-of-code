﻿using AoC.Core;
using aoc2020.day01.domain;

namespace aoc2020.day01
{
    public class Parser : IParser<Input>
    {
        public Input ParseInput(string[] input)
        {
            return new Input(input.Select(int.Parse).ToList());
        }
    }
}
