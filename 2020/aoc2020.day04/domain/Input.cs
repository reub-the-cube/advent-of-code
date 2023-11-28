using System;

namespace aoc2020.day04.domain
{
    public class Input
    {
        public List<Passport> Passports { get; }

        public Input()
        {
            Passports = new List<Passport>();
        }

        public void AddPassport(Passport passport) => Passports.Add(passport);
    }
}